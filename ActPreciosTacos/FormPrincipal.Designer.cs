namespace ActPreciosTacos
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioDeClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónDescargadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCargaArtSoftRe = new System.Windows.Forms.Button();
            this.btnCargaArti = new System.Windows.Forms.Button();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gcProductos = new DevExpress.XtraGrid.GridControl();
            this.productosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colseleccionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colclave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProdAct = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colseleccionado1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidProducto1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colclave1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproducto1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprecio1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnQuitarTodos = new System.Windows.Forms.Button();
            this.btnQuitarProd = new System.Windows.Forms.Button();
            this.btnAgregarProd = new System.Windows.Forms.Button();
            this.btnGuarda = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProdAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1237, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaUsuarioToolStripMenuItem,
            this.cambioDeClaveToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // altaUsuarioToolStripMenuItem
            // 
            this.altaUsuarioToolStripMenuItem.Name = "altaUsuarioToolStripMenuItem";
            this.altaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.altaUsuarioToolStripMenuItem.Text = "Alta Usuario";
            this.altaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.altaUsuarioToolStripMenuItem_Click);
            // 
            // cambioDeClaveToolStripMenuItem
            // 
            this.cambioDeClaveToolStripMenuItem.Name = "cambioDeClaveToolStripMenuItem";
            this.cambioDeClaveToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cambioDeClaveToolStripMenuItem.Text = "Cambio de Clave";
            this.cambioDeClaveToolStripMenuItem.Click += new System.EventHandler(this.cambioDeClaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informaciónDescargadaToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // informaciónDescargadaToolStripMenuItem
            // 
            this.informaciónDescargadaToolStripMenuItem.Name = "informaciónDescargadaToolStripMenuItem";
            this.informaciónDescargadaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.informaciónDescargadaToolStripMenuItem.Text = "Información Descargada";
            this.informaciónDescargadaToolStripMenuItem.Click += new System.EventHandler(this.informaciónDescargadaToolStripMenuItem_Click);
            // 
            // btnCargaArtSoftRe
            // 
            this.btnCargaArtSoftRe.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.btnCargaArtSoftRe.Location = new System.Drawing.Point(328, 30);
            this.btnCargaArtSoftRe.Name = "btnCargaArtSoftRe";
            this.btnCargaArtSoftRe.Size = new System.Drawing.Size(246, 33);
            this.btnCargaArtSoftRe.TabIndex = 17;
            this.btnCargaArtSoftRe.Text = "Carga Artículos de SoftRestaurant";
            this.btnCargaArtSoftRe.UseVisualStyleBackColor = true;
            this.btnCargaArtSoftRe.Click += new System.EventHandler(this.btnCargaArtSoftRe_Click);
            // 
            // btnCargaArti
            // 
            this.btnCargaArti.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.btnCargaArti.Location = new System.Drawing.Point(12, 75);
            this.btnCargaArti.Name = "btnCargaArti";
            this.btnCargaArti.Size = new System.Drawing.Size(135, 33);
            this.btnCargaArti.TabIndex = 16;
            this.btnCargaArti.Text = "Carga Artículos";
            this.btnCargaArti.UseVisualStyleBackColor = true;
            this.btnCargaArti.Click += new System.EventHandler(this.btnCargaArti_Click);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbBusqueda.Location = new System.Drawing.Point(236, 79);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(338, 25);
            this.tbBusqueda.TabIndex = 15;
            this.tbBusqueda.TextChanged += new System.EventHandler(this.tbBusqueda_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.Location = new System.Drawing.Point(158, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Búsqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Actualizar Precios Taquerías";
            // 
            // gcProductos
            // 
            this.gcProductos.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcProductos.DataSource = this.productosBindingSource;
            this.gcProductos.Location = new System.Drawing.Point(12, 114);
            this.gcProductos.MainView = this.gridView1;
            this.gcProductos.Name = "gcProductos";
            this.gcProductos.Size = new System.Drawing.Size(562, 345);
            this.gcProductos.TabIndex = 18;
            this.gcProductos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productosBindingSource
            // 
            this.productosBindingSource.DataSource = typeof(ActPreciosTacos.Modelos.Productos);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colseleccionado,
            this.colidProducto,
            this.colclave,
            this.colproducto,
            this.colprecio});
            this.gridView1.GridControl = this.gcProductos;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Productos";
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // colseleccionado
            // 
            this.colseleccionado.Caption = " ";
            this.colseleccionado.FieldName = "seleccionado";
            this.colseleccionado.Name = "colseleccionado";
            this.colseleccionado.Visible = true;
            this.colseleccionado.VisibleIndex = 0;
            this.colseleccionado.Width = 30;
            // 
            // colidProducto
            // 
            this.colidProducto.FieldName = "idProducto";
            this.colidProducto.Name = "colidProducto";
            // 
            // colclave
            // 
            this.colclave.Caption = "Clave";
            this.colclave.FieldName = "clave";
            this.colclave.Name = "colclave";
            this.colclave.OptionsColumn.AllowEdit = false;
            this.colclave.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colclave.Visible = true;
            this.colclave.VisibleIndex = 1;
            // 
            // colproducto
            // 
            this.colproducto.Caption = "Producto";
            this.colproducto.FieldName = "producto";
            this.colproducto.Name = "colproducto";
            this.colproducto.OptionsColumn.AllowEdit = false;
            this.colproducto.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colproducto.Visible = true;
            this.colproducto.VisibleIndex = 2;
            // 
            // colprecio
            // 
            this.colprecio.Caption = "Precio";
            this.colprecio.FieldName = "precio";
            this.colprecio.Name = "colprecio";
            this.colprecio.OptionsColumn.AllowEdit = false;
            this.colprecio.Visible = true;
            this.colprecio.VisibleIndex = 3;
            // 
            // gcProdAct
            // 
            this.gcProdAct.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcProdAct.DataSource = this.productosBindingSource;
            this.gcProdAct.Location = new System.Drawing.Point(646, 114);
            this.gcProdAct.MainView = this.gridView2;
            this.gcProdAct.Name = "gcProdAct";
            this.gcProdAct.Size = new System.Drawing.Size(581, 345);
            this.gcProdAct.TabIndex = 19;
            this.gcProdAct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colseleccionado1,
            this.colidProducto1,
            this.colclave1,
            this.colproducto1,
            this.colprecio1});
            this.gridView2.GridControl = this.gcProdAct;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowViewCaption = true;
            this.gridView2.ViewCaption = "Productos a Actualizar";
            this.gridView2.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView2_RowCellStyle);
            // 
            // colseleccionado1
            // 
            this.colseleccionado1.Caption = " ";
            this.colseleccionado1.FieldName = "seleccionado";
            this.colseleccionado1.Name = "colseleccionado1";
            this.colseleccionado1.Visible = true;
            this.colseleccionado1.VisibleIndex = 0;
            this.colseleccionado1.Width = 30;
            // 
            // colidProducto1
            // 
            this.colidProducto1.FieldName = "idProducto";
            this.colidProducto1.Name = "colidProducto1";
            // 
            // colclave1
            // 
            this.colclave1.Caption = "Clave";
            this.colclave1.FieldName = "clave";
            this.colclave1.Name = "colclave1";
            this.colclave1.OptionsColumn.AllowEdit = false;
            this.colclave1.Visible = true;
            this.colclave1.VisibleIndex = 1;
            // 
            // colproducto1
            // 
            this.colproducto1.Caption = "Producto";
            this.colproducto1.FieldName = "producto";
            this.colproducto1.Name = "colproducto1";
            this.colproducto1.OptionsColumn.AllowEdit = false;
            this.colproducto1.Visible = true;
            this.colproducto1.VisibleIndex = 2;
            // 
            // colprecio1
            // 
            this.colprecio1.Caption = "Precio";
            this.colprecio1.FieldName = "precio";
            this.colprecio1.Name = "colprecio1";
            this.colprecio1.Visible = true;
            this.colprecio1.VisibleIndex = 3;
            // 
            // btnQuitarTodos
            // 
            this.btnQuitarTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarTodos.Image")));
            this.btnQuitarTodos.Location = new System.Drawing.Point(580, 304);
            this.btnQuitarTodos.Name = "btnQuitarTodos";
            this.btnQuitarTodos.Size = new System.Drawing.Size(60, 60);
            this.btnQuitarTodos.TabIndex = 22;
            this.btnQuitarTodos.UseVisualStyleBackColor = true;
            this.btnQuitarTodos.Click += new System.EventHandler(this.btnQuitarTodos_Click);
            // 
            // btnQuitarProd
            // 
            this.btnQuitarProd.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarProd.Image")));
            this.btnQuitarProd.Location = new System.Drawing.Point(580, 238);
            this.btnQuitarProd.Name = "btnQuitarProd";
            this.btnQuitarProd.Size = new System.Drawing.Size(60, 60);
            this.btnQuitarProd.TabIndex = 21;
            this.btnQuitarProd.UseVisualStyleBackColor = true;
            this.btnQuitarProd.Click += new System.EventHandler(this.btnQuitarProd_Click);
            // 
            // btnAgregarProd
            // 
            this.btnAgregarProd.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarProd.Image")));
            this.btnAgregarProd.Location = new System.Drawing.Point(580, 172);
            this.btnAgregarProd.Name = "btnAgregarProd";
            this.btnAgregarProd.Size = new System.Drawing.Size(60, 60);
            this.btnAgregarProd.TabIndex = 20;
            this.btnAgregarProd.UseVisualStyleBackColor = true;
            this.btnAgregarProd.Click += new System.EventHandler(this.btnAgregarProd_Click);
            // 
            // btnGuarda
            // 
            this.btnGuarda.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.btnGuarda.Location = new System.Drawing.Point(1092, 75);
            this.btnGuarda.Name = "btnGuarda";
            this.btnGuarda.Size = new System.Drawing.Size(135, 33);
            this.btnGuarda.TabIndex = 23;
            this.btnGuarda.Text = "Guardar Cambios";
            this.btnGuarda.UseVisualStyleBackColor = true;
            this.btnGuarda.Click += new System.EventHandler(this.btnGuarda_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1237, 474);
            this.Controls.Add(this.btnGuarda);
            this.Controls.Add(this.btnQuitarTodos);
            this.Controls.Add(this.btnQuitarProd);
            this.Controls.Add(this.btnAgregarProd);
            this.Controls.Add(this.gcProdAct);
            this.Controls.Add(this.gcProductos);
            this.Controls.Add(this.btnCargaArtSoftRe);
            this.Controls.Add(this.btnCargaArti);
            this.Controls.Add(this.tbBusqueda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Precios Taquerías";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProdAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioDeClaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónDescargadaToolStripMenuItem;
        private System.Windows.Forms.Button btnCargaArtSoftRe;
        private System.Windows.Forms.Button btnCargaArti;
        private System.Windows.Forms.TextBox tbBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gcProductos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource productosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colseleccionado;
        private DevExpress.XtraGrid.Columns.GridColumn colidProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colclave;
        private DevExpress.XtraGrid.Columns.GridColumn colproducto;
        private DevExpress.XtraGrid.Columns.GridColumn colprecio;
        private DevExpress.XtraGrid.GridControl gcProdAct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Button btnQuitarTodos;
        private System.Windows.Forms.Button btnQuitarProd;
        private System.Windows.Forms.Button btnAgregarProd;
        private DevExpress.XtraGrid.Columns.GridColumn colseleccionado1;
        private DevExpress.XtraGrid.Columns.GridColumn colclave1;
        private DevExpress.XtraGrid.Columns.GridColumn colproducto1;
        private DevExpress.XtraGrid.Columns.GridColumn colprecio1;
        private DevExpress.XtraGrid.Columns.GridColumn colidProducto1;
        private System.Windows.Forms.Button btnGuarda;
    }
}

