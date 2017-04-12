using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DescargaPrecioTacos.Negocio;

namespace DescargaPrecioTacos
{
    public partial class FormPrincipal : Form
    {
        private IConsultasSSNegocio _consultasSSNegocio;
        private IConsultasMySqlNegocio _consultasMySqlNegocio;

        private List<Modelos.Productos> _productos;

        private bool _actualizacion = false;
        private string _sucursal;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this._sucursal = Modelos.Login.sucursal;
                string sucursal = Modelos.Login.sucursal.ToLower().Trim().Equals("MA?ANERO".ToLower()) ? "MAÑANERO" : Modelos.Login.sucursal;

                this.lbLeyenda.Text += " " + sucursal;

                this._consultasSSNegocio = new ConsultasSSNegocio();
                this._consultasMySqlNegocio = new ConsultasMySqlNegocio();

                this.verificarInformacionPendiente();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void verificarInformacionPendiente()
        {
            string sucursal = this._sucursal.ToLower().Trim().Equals("MA?ANERO".ToLower()) ? "mananero" : this._sucursal.ToLower();

            // verifica si se tienen descargas pendientes segun la sucursal definida
            bool pendientes = this._consultasMySqlNegocio.verifDescargas(sucursal);

            if (pendientes)
            {
                this.lbPendientes.Text = "ACTUALIZACIÓN PENDIENTE";
                this.lbPendientes.ForeColor = System.Drawing.Color.Red;
                this._actualizacion = true;
            }
            else
            {
                this.lbPendientes.Text = "ACTUALIZADO";
                this.lbPendientes.ForeColor = System.Drawing.Color.Green;
                this._actualizacion = false;
            }
        }

        private void btnVerifPendiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._actualizacion)
                {
                    // string sucursal = this._sucursal.ToLower().Equals("MAÑANERO".ToLower()) ? "mananero" : this._sucursal.ToLower();
                    string sucursal = this._sucursal.ToLower().Trim().Equals("MA?ANERO".ToLower()) ? "mananero" : this._sucursal.ToLower();

                    // cargar articulos a actualizar del primer bloque que se tenga
                    this._productos = this._consultasMySqlNegocio.getProductosActualizar(sucursal);

                    if (this._productos.Count == 0)
                        throw new Exception("Sin resultados");

                    this.gcProductos.DataSource = null;
                    this.gcProductos.DataSource = this._productos;

                    this.gridView1.BestFitColumns();

                    string fecha = getFechaSqlServer();

                    // bitacora
                    this._consultasMySqlNegocio.generaBitacora(
                        "Información pendiente consultada en '" + Modelos.Login.sucursal + "'", fecha);

                }
                else
                    throw new Exception("No hay actualizaciones pendientes");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnDescargarInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string sucursal = this._sucursal.ToLower().Trim().Equals("MA?ANERO".ToLower()) ? "mananero" : this._sucursal.ToLower();

                if (this._productos == null || this._productos.Count == 0)
                    throw new Exception("No se ha cargado la información");

                foreach (Modelos.Productos prd in this._productos)
                {
                    // buscar el producto
                    Modelos.ProductoSS prodAct = this._consultasSSNegocio.buscaProduc(prd.clave);

                    // existe
                    if (prodAct != null)
                    {
                        // P R E C I O
                        // se actualiza el registro SS
                        this._consultasSSNegocio.actPrecio(prd.clave, prodAct.impuesto, prd.precio);

                        string fecha = getFechaSqlServer();

                        // se libera la actualizacion del producto MS
                        bool resultado = this._consultasMySqlNegocio.liberaProducto(prd.clave, prd.bloque, sucursal.ToLower());

                        // bitacora
                        this._consultasMySqlNegocio.generaBitacora(
                        "Descarga completa del producto con clave '" + prd.clave +
                        "' en el bloque '" + prd.bloque + "' y en la sucursal '" + Modelos.Login.sucursal + "'", fecha);
                    }
                    else // no existe
                    {
                        MessageBox.Show("El producto '" + prd.producto +
                            "' no existe.\nEl proceso de actualización continuará pero este producto no se actualizará"
                            , "Actualizar Precios Taquerías"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string fecha = getFechaSqlServer();

                        // mandar mensaje y generar bitacora
                        this._consultasMySqlNegocio.generaBitacora(
                        "El producto '" + prd.producto + "' con clave '" + prd.clave +
                        "' en el bloque '" + prd.bloque + "' y en la sucursal '" + Modelos.Login.sucursal +
                        "' no existe en la sucursal", fecha);

                    }
                }

                // se libera el bloque de actualizacion MS
                bool resAct = this._consultasMySqlNegocio.liberaBloque(this._productos[0].bloque, sucursal.ToLower());
                int bloque = this._productos[0].bloque;

                if (resAct)
                {
                    string fecha = getFechaSqlServer();

                    // bitacora
                    this._consultasMySqlNegocio.generaBitacora(
                        "Bloque '" + this._productos[0].bloque + "' descargado completamente en la sucursal '" + Modelos.Login.sucursal, fecha);

                    MessageBox.Show("Proceso Concluido", "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // borrar registros a actualizar
                    this.gcProductos.DataSource = new List<Modelos.Productos>();
                    this._productos = new List<Modelos.Productos>();

                    this.lbPendientes.Text = "VERIFIQUE ACTUALIZACIONES ->";
                    this.lbPendientes.ForeColor = System.Drawing.Color.Blue;
                }

                // verifica si ya se ha descargado la informacion en todas las sucursales
                // de ser correcto, se actualizara el estatus general del articulo
                bool actTodosBloque = this._consultasMySqlNegocio.liberarBloques(bloque);

                string fecha2 = getFechaSqlServer();

                if (actTodosBloque)
                    // bitacora
                    this._consultasMySqlNegocio.generaBitacora(
                        "Bloque '" + bloque + "' descargado completamente en todas las sucursales", fecha2);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnActPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                this.verificarInformacionPendiente();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string fecha = getFechaSqlServer();

                // bitacora
                this._consultasMySqlNegocio.generaBitacora(
                    "Sesión cerrada por el usuario '" + Modelos.Login.nombre + "'" + " en sucursal '" + Modelos.Login.sucursal + "'", fecha);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
