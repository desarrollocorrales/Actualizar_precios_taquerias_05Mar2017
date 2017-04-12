using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DescargaPrecioTacos.Negocio;

namespace DescargaPrecioTacos.GUIs
{
    public partial class frmConfiguracion : Form
    {
        private string _path = string.Empty;
        private IConsultasSSNegocio _consultasSSNegocio;
        private IConsultasMySqlNegocio _consultasMySQLNegocio;

        public frmConfiguracion()
        {
            InitializeComponent();

            this.ActiveControl = this.tbServidorS;
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                string fileName = "config.dat";
                string pathConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\DescPrecTacos\";

                // si no existe el directorio, lo crea
                bool exists = System.IO.Directory.Exists(pathConfigFile);

                if (!exists) System.IO.Directory.CreateDirectory(pathConfigFile);

                // busca en el directorio si exite el archivo con el nombre dado
                var file = Directory.GetFiles(pathConfigFile, fileName, SearchOption.AllDirectories)
                        .FirstOrDefault();

                this._path = pathConfigFile + fileName;

                if (file != null)
                {
                    // si existe
                    // cargar los datos en los campos
                    FEncrypt.Respuesta result = FEncrypt.EncryptDncrypt.DecryptFile(this._path, "milagros");

                    if (result.status == FEncrypt.Estatus.ERROR)
                        throw new Exception(result.error);

                    if (result.status == FEncrypt.Estatus.OK)
                    {
                        string[] list = result.resultado.Split(new string[] { "||" }, StringSplitOptions.None);

                        if (list.Count() < 9)
                        {
                            foreach (Control x in this.Controls)
                            {
                                if (x is TextBox)
                                {
                                    ((TextBox)x).Text = string.Empty;
                                }
                            }
                        }
                        else
                        {
                            // SQLSERVER
                            this.tbServidorS.Text = list[0].Substring(2);               // SERVIDOR
                            this.tbBaseDatosS.Text = list[1].Substring(2);              // BASE DE DATOS
                            this.cmbAutenticacionS.SelectedItem = list[2].Substring(2); // AUTENTICACION
                            this.tbUsuarioS.Text = list[3].Substring(2);                // USUARIO
                            this.tbContraseniaS.Text = list[4].Substring(2);            // CONTRASEÑA

                            // MYSQL
                            this.tbServidorMs.Text = list[5].Substring(2);      // SERVIDOR
                            this.tbUsuarioMs.Text = list[6].Substring(2);       // USUARIO
                            this.tbContraseniaMs.Text = list[7].Substring(2);   // CONTRASEÑA
                            this.tbBaseDeDatosMs.Text = list[8].Substring(2);   // BASE 

                            // SUCURSAL
                            string sucursal = list[9].Substring(2).ToLower().Trim().Equals("MA?ANERO".ToLower()) ? "MAÑANERO" : list[9].Substring(2);
                            this.cmbSucursal.SelectedItem = sucursal;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnProbarConnSS_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoAu = (string)this.cmbAutenticacionS.SelectedItem;

                Modelos.ConectionString.connSS = string.Empty;

                if (tipoAu.ToLower().Equals("windows"))
                {
                    Modelos.ConectionString.connSS = string.Format(
                    "Data Source={0};Initial Catalog={1};Integrated Security=True;",
                    this.tbServidorS.Text,
                    this.tbBaseDatosS.Text);
                }

                if (tipoAu.ToLower().Equals("sql server"))
                {
                    Modelos.ConectionString.connSS = string.Format(
                    "Data Source={0};database={1};User Id={2};password={3};",
                    this.tbServidorS.Text,
                    this.tbBaseDatosS.Text,
                    this.tbUsuarioS.Text,
                    this.tbContraseniaS.Text);
                }

                this._consultasSSNegocio = new ConsultasSSNegocio();

                bool result = this._consultasSSNegocio.pruebaConn();

                if (!result)
                    throw new Exception("Error al conectar");

                MessageBox.Show("Conexión Exitosa!!!", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Falló la conexión a la base de datos", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnProbarConMysql_Click(object sender, EventArgs e)
        {
            try
            {
                Modelos.ConectionString.connMySQL = string.Format(
                            "Data Source={0};database={1};User Id={2};password={3};",
                            this.tbServidorMs.Text,
                            this.tbBaseDeDatosMs.Text,
                            this.tbUsuarioMs.Text,
                            this.tbContraseniaMs.Text);

                this._consultasMySQLNegocio = new ConsultasMySqlNegocio();

                bool pruebaConn = this._consultasMySQLNegocio.pruebaConn();

                if (pruebaConn)
                    MessageBox.Show("Conexión Exitosa!!!", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    throw new Exception("Falló la conexión a la base de datos del Microsip");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.tbServidorS.Text))
                    throw new Exception("Llene el campo Servidor de SoftRestaurant");

                if (string.IsNullOrEmpty(this.tbBaseDatosS.Text))
                    throw new Exception("Llene el campo Base de Datos de SoftRestaurant");

                if (this.cmbAutenticacionS.SelectedIndex == -1)
                    throw new Exception("Seleccione el tipo Autenticación de SoftRestaurant");

                string tipo = (string)this.cmbAutenticacionS.SelectedItem;

                if (tipo.ToLower().Equals("sql server"))
                {

                    if (string.IsNullOrEmpty(this.tbUsuarioS.Text))
                        throw new Exception("Llene el campo Usuario de SoftRestaurant");

                    if (string.IsNullOrEmpty(this.tbServidorS.Text))
                        throw new Exception("Llene el campo Contraseña de SoftRestaurant");
                }

                // validaciones
                foreach (Control x in this.groupBox2.Controls)
                {
                    if (x is TextBox)
                    {
                        if (string.IsNullOrEmpty(((TextBox)x).Text))
                            throw new Exception("Campos incompletos, Por favor verifique");
                    }
                }

                if (this.cmbSucursal.SelectedIndex == -1)
                    throw new Exception("Seleccione la sucursal a la que pertenece");

                // define texto del archivo
                string cadena = string.Empty;

                // SQLSERVER
                cadena += "S_" + this.tbServidorS.Text + "||";
                cadena += "B_" + this.tbBaseDatosS.Text + "||";
                cadena += "A_" + this.cmbAutenticacionS.SelectedItem + "||";
                cadena += "C_" + this.tbContraseniaS.Text + "||";
                cadena += "U_" + this.tbUsuarioS.Text + "||";

                // MYSQL
                cadena += "S_" + this.tbServidorMs.Text + "||";
                cadena += "U_" + this.tbUsuarioMs.Text + "||";
                cadena += "C_" + this.tbContraseniaMs.Text + "||";
                cadena += "B_" + this.tbBaseDeDatosMs.Text + "||";

                // SUCURSAL
                cadena += "S_" + this.cmbSucursal.SelectedItem + "||";

                // prosigue con la creación del archivo
                FEncrypt.Respuesta result = FEncrypt.EncryptDncrypt.EncryptFile("milagros", cadena, this._path);

                if (result.status == FEncrypt.Estatus.ERROR)
                    throw new Exception(result.error);

                if (result.status == FEncrypt.Estatus.OK)
                {
                    // SQLSERVER
                    string tipoAu = (string)this.cmbAutenticacionS.SelectedItem;

                    if (tipoAu.ToLower().Equals("windows"))
                    {
                        Modelos.ConectionString.connSS = string.Format(
                        "Data Source={0};Initial Catalog={1};Integrated Security=True;",
                        this.tbServidorS.Text,
                        this.tbBaseDatosS.Text);
                    }

                    if (tipoAu.ToLower().Equals("sql server"))
                    {
                        Modelos.ConectionString.connSS = string.Format(
                        "Data Source={0};database={1};User Id={2};password={3};Trusted_Connection=yes;",
                        this.tbServidorS.Text,
                        this.tbBaseDatosS.Text,
                        this.tbUsuarioS.Text,
                        this.tbContraseniaS.Text);
                    }

                    this._bloqueo(tipoAu);

                    // mysql
                    Modelos.ConectionString.connMySQL = string.Format(
                                "Data Source={0};database={1};User Id={2};password={3};",
                                this.tbServidorMs.Text,
                                this.tbBaseDeDatosMs.Text,
                                this.tbUsuarioMs.Text,
                                this.tbContraseniaMs.Text);

                    // sucursal
                    Modelos.Login.sucursal = (string)this.cmbSucursal.SelectedItem;

                    MessageBox.Show("Se cargó correctamente la información", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _bloqueo(string tipoAu)
        {

            if (tipoAu.ToLower().Equals("windows"))
            {
                this.tbUsuarioS.Text = string.Empty;
                this.tbContraseniaS.Text = string.Empty;

                this.tbUsuarioS.Enabled = false;
                this.tbContraseniaS.Enabled = false;
            }

            if (tipoAu.ToLower().Equals("sql server"))
            {
                this.tbUsuarioS.Text = string.Empty;
                this.tbContraseniaS.Text = string.Empty;

                this.tbUsuarioS.Enabled = true;
                this.tbContraseniaS.Enabled = true;
            }
        }

        private void cmbAutenticacionS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string tipoAu = (string)this.cmbAutenticacionS.SelectedItem;

                this._bloqueo(tipoAu);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
