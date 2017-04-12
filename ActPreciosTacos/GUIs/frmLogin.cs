using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ActPreciosTacos.Negocio;

namespace ActPreciosTacos.GUIs
{
    public partial class frmLogin : Form
    {
        private bool _defConfig;
        private IConsultasMySQLNegocio _consultasMySQLNegocio;
        private IConsultasSSNegocio _consultasSSNegocio;

        public frmLogin()
        {
            InitializeComponent();

            this.ActiveControl = this.tbUsuario;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // valida si ya tiene alguna clave guardada para el archivo
                string cveActual = Properties.Settings.Default.accesoConfig;

                if (string.IsNullOrEmpty(cveActual))
                {
                    string acceso = Modelos.Utilerias.Transform("p4ssw0rd");

                    Properties.Settings.Default.accesoConfig = acceso;
                    Properties.Settings.Default.Save();
                }

                string fileName = "config.dat";
                string pathConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\ActPrecTacos\";

                // si no existe el directorio, lo crea
                bool exists = System.IO.Directory.Exists(pathConfigFile);

                if (!exists) System.IO.Directory.CreateDirectory(pathConfigFile);

                // busca en el directorio si exite el archivo con el nombre dado
                var file = Directory.GetFiles(pathConfigFile, fileName, SearchOption.AllDirectories)
                        .FirstOrDefault();

                if (file == null)
                {
                    // no existe
                    // abrir el formulario para llenar la configuracion de conexion 
                    frmConfiguracion form = new frmConfiguracion();
                    var resultado = form.ShowDialog();

                    if (resultado != System.Windows.Forms.DialogResult.OK)
                    {
                        this._defConfig = false;
                        throw new Exception("No se ha definido la configuración");
                    }
                }

                file = Directory.GetFiles(pathConfigFile, fileName, SearchOption.AllDirectories)
                        .FirstOrDefault();

                // si existe
                // obtener la cadena de conexion del archivo
                FEncrypt.Respuesta result = FEncrypt.EncryptDncrypt.DecryptFile(file, "milagros");

                if (result.status == FEncrypt.Estatus.ERROR)
                    throw new Exception(result.error);

                if (result.status == FEncrypt.Estatus.OK)
                {
                    string[] list = result.resultado.Split(new string[] { "||" }, StringSplitOptions.None);

                    // SQLSERVER
                    string servidorS = list[0].Substring(2);    // servidor sqlserver
                    string baseDatosS = list[1].Substring(2);   // base de datos sqlserver
                    string tipoAu = list[2].Substring(2);       // tipo de autenticacion sqlserver
                    string usuarioS = list[3].Substring(2);     // usuario  sqlserver
                    string contraS = list[4].Substring(2);      // contraseña  sqlserver

                    if (tipoAu.ToLower().Equals("windows"))
                    {
                        Modelos.ConectionString.connSS = string.Format(
                        "Data Source={0};Initial Catalog={1};Integrated Security=True;",
                        servidorS,
                        baseDatosS);
                    }

                    if (tipoAu.ToLower().Equals("sql server"))
                    {
                        Modelos.ConectionString.connSS = string.Format(
                        "Data Source={0};database={1};User Id={2};password={3};Trusted_Connection=yes;",
                        servidorS,
                        baseDatosS,
                        usuarioS,
                        contraS);
                    }

                    // MySQL
                    string servidorMs = list[5].Substring(2);   // servidor mysql
                    string usuarioMs = list[6].Substring(2);    // usuario mysql
                    string contraMs = list[7].Substring(2);     // contraseña mysql
                    string baseDatosMs = list[8].Substring(2);  // base de datos mysql

                    Modelos.ConectionString.connMySQL = string.Format(
                                "Data Source={0};database={1};User Id={2};password={3};",
                                servidorMs,
                                baseDatosMs,
                                usuarioMs,
                                contraMs);
                }

                this._defConfig = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmAcceso formA = new frmAcceso();

            var respuesta = formA.ShowDialog();

            if (respuesta == System.Windows.Forms.DialogResult.OK)
            {
                frmConfiguracion form = new frmConfiguracion();
                var resultado = form.ShowDialog();

                if (resultado == System.Windows.Forms.DialogResult.OK)
                    this.frmLogin_Load(null, null);
            }
        }

        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            this.tbUsuario.SelectAll();
        }

        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnAcceder_Click(null, null);
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                this._consultasMySQLNegocio = new ConsultasMySQLNegocio();
                this._consultasSSNegocio = new ConsultasSSNegocio();

                // validaciones
                if (string.IsNullOrEmpty(this.tbUsuario.Text))
                    throw new Exception("Llene el campo Usuario");

                if (string.IsNullOrEmpty(this.tbPass.Text))
                    throw new Exception("Llene el campo Clave");

                if (this.cmbSucursal.SelectedIndex == -1)
                    throw new Exception("Seleccione una sucursal");

                Modelos.Response resp = this._consultasMySQLNegocio.validaAcceso(this.tbUsuario.Text, this.tbPass.Text);

                if (resp.status == Modelos.Estatus.OK)
                {
                    // almacenar credeniales
                    Modelos.Login.idUsuario = resp.usuario.idUsuario;
                    Modelos.Login.nombre = resp.usuario.nombreCompleto;
                    Modelos.Login.usuario = resp.usuario.usuario;

                    string fecha = getFechaSqlServer();

                    // bitacora
                    this._consultasMySQLNegocio.generaBitacora(
                        "Nuevo Acceso a usuario '" + Modelos.Login.nombre + "'", fecha);

                    Modelos.Login.taqueria = (string)this.cmbSucursal.SelectedItem;

                    this.Hide();
                    new FormPrincipal().ShowDialog();
                    this.Close();
                }
                else throw new Exception(resp.error);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public string getFechaSqlServer()
        {
            string result = string.Empty;

            try
            {
                result = this._consultasSSNegocio.getFecha();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }
    }
}
