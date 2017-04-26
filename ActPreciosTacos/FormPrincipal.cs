using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActPreciosTacos.Negocio;
using DevExpress.XtraEditors.Repository;
using ActPreciosTacos.GUIs;

namespace ActPreciosTacos
{
    public partial class FormPrincipal : Form
    {
        private IConsultasSSNegocio _consultasSSNegocio;
        private IConsultasMySQLNegocio _consultasMySQLNegocio;
        private List<Modelos.Productos> _productos = new List<Modelos.Productos>();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this._consultasSSNegocio = new ConsultasSSNegocio();
                this._consultasMySQLNegocio = new ConsultasMySQLNegocio();

                this.gcProdAct.DataSource = new List<Modelos.Productos>();
                this.gcProductos.DataSource = new List<Modelos.Productos>();

                // Create the ToolTip and associate with the Form container.
                ToolTip toolTip1 = new ToolTip();

                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;

                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip1.ShowAlways = true;

                // Set up the ToolTip text for the Button and Checkbox.
                toolTip1.SetToolTip(this.btnCargaArti, "Carga los Productos con sus precios desde SoftRestaurant");
                toolTip1.SetToolTip(this.btnAgregarProd, "Agregar los seleccionados a la lista de Productos a Actualizar");
                toolTip1.SetToolTip(this.btnQuitarProd, "Quitar los seleccionados de la lista de Productos a Actualizar");
                toolTip1.SetToolTip(this.btnQuitarTodos, "Limpiar la lista de Productos a Actualizar");
                toolTip1.SetToolTip(this.btnGuarda, "Guarda todos los cambios realizados a los Productos");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCargaArtSoftRe_Click(object sender, EventArgs e)
        {
            try
            {
                // consulta productos de softrestaurant
                this._productos = this._consultasSSNegocio.obtieneProductos();

                this.gcProductos.DataSource = this._productos;

                this.gridView1.BestFitColumns();

                // insertar productos en mysql
                this._consultasMySQLNegocio.insertaProductos(this._productos);

                string fecha = getFechaSqlServer();

                // bitacora
                this._consultasMySQLNegocio.generaBitacora(
                    "Articulos cargados de softRestaurant: sucursal - " + Modelos.Login.taqueria + " - ", fecha);

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

        private void btnCargaArti_Click(object sender, EventArgs e)
        {
            try
            {
                this._productos = this._consultasMySQLNegocio.obtieneProductos();

                this.gcProductos.DataSource = this._productos;

                this.gridView1.BestFitColumns();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this._productos.Count == 0)
                    return;

                List<Modelos.Productos> seleccion = new List<Modelos.Productos>();

                string texto = this.tbBusqueda.Text;

                seleccion = this._productos.Where(w => w.producto.ToUpper().Contains((texto.ToUpper())) || w.clave.Contains(texto)).ToList();

                this.gcProductos.DataSource = null;
                this.gcProductos.DataSource = seleccion;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            try
            {
                // obtiene los Productos seleccionadas del grid de Productos
                List<Modelos.Productos> seleccionados = ((List<Modelos.Productos>)this.gridView1.DataSource).Where(w => w.seleccionado == true).Select(s => s).ToList();

                if (seleccionados.Count == 0) return;

                // obtiene los Productos agregados
                List<Modelos.Productos> agregados = ((List<Modelos.Productos>)this.gridView2.DataSource).ToList();

                foreach (Modelos.Productos prod in seleccionados)
                {
                    if (agregados.Where(w => w.clave == prod.clave).ToList().Count == 0)
                    {
                        agregados.Add(new Modelos.Productos
                        {
                            precio = prod.precio,
                            clave = prod.clave,
                            producto = prod.producto,
                            seleccionado = false
                        });
                    }
                }

                this.gcProdAct.DataSource = null;
                this.gcProdAct.DataSource = agregados;

                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.Mask.EditMask = "#,###,##0.00";
                this.gcProdAct.RepositoryItems.Add(edit);
                gridView2.Columns[4].ColumnEdit = edit;

                this.gridView2.BestFitColumns();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnQuitarProd_Click(object sender, EventArgs e)
        {
            try
            {
                // obtiene los articulos seleccionadas del grid de articulos
                List<Modelos.Productos> seleccionados = ((List<Modelos.Productos>)this.gridView2.DataSource).Where(w => w.seleccionado == false).Select(s => s).ToList();

                if (seleccionados.Count == 0)
                    if (((List<Modelos.Productos>)this.gridView2.DataSource).Count > 1) return;
                    else
                        this.gcProdAct.DataSource = new List<Modelos.Productos>();

                this.gcProdAct.DataSource = null;
                this.gcProdAct.DataSource = seleccionados;

                this.gridView2.BestFitColumns();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnQuitarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.gcProdAct.DataSource = new List<Modelos.Productos>();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E86C1");
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E86C1");
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string fecha = getFechaSqlServer();

                // bitacora
                this._consultasMySQLNegocio.generaBitacora(
                    "Sesión cerrada por el usuario '" + Modelos.Login.nombre + "'", fecha);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void altaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAltaUsuario child = new frmAltaUsuario();

                child.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cambioDeClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCambiaClave form = new frmCambiaClave(Modelos.Login.usuario, Modelos.Login.idUsuario);

                form.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea salir de la aplicación?", "Actualizar Precios Taquerías", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void informaciónDescargadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDescargaInfo form = new frmDescargaInfo();

                form.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuarda_Click(object sender, EventArgs e)
        {
            try
            {
                // obtiene los articulos seleccionadas del grid de productos
                List<Modelos.Productos> seleccionados = ((List<Modelos.Productos>)this.gridView2.DataSource).Select(s => s).ToList();

                if (seleccionados.Count == 0) throw new Exception("No se han cargado los productos a actualizar");

                List<decimal?> nulos = seleccionados.Where(w => w.precio == null).Select(s => s.precio).ToList();

                if(nulos.Count > 0)
                    throw new Exception("Ningún precio debe de estar vacío.\nFavor de verificar");

                string fecha1 = getFechaSqlServer();

                int respuesta = this._consultasMySQLNegocio.guardaActualizacion(seleccionados, fecha1);

                if (respuesta < 0)
                    throw new Exception("Problemas al guardar los cambios");
                else
                {
                    // lista de productos a actualizar
                    string lista = string.Empty;

                    foreach (Modelos.Productos productos in seleccionados)
                    {
                        lista += productos.clave + " - " + productos.producto + "; ";
                    }

                    string fecha = getFechaSqlServer();

                    // bitacora
                    long resultado = this._consultasMySQLNegocio.generaBitacora(
                        "Bloque de actualización creado '" + respuesta + "': " + lista.Trim(),
                        fecha);

                    // guarda bitacora detalle
                    // lista de precios anteriores
                    List<Modelos.Productos> anteriores =
                        this._productos.Where(w => seleccionados.Any(a => a.clave == w.clave)).ToList();

                    this._consultasMySQLNegocio.guardaBitacora(anteriores, seleccionados, resultado);

                    MessageBox.Show("Proceso concluido", "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.gcProdAct.DataSource = new List<Modelos.Productos>();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Actualizar Precios Taquerías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
