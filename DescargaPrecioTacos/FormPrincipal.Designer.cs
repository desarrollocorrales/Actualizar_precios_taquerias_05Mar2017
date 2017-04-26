namespace DescargaPrecioTacos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.btnActPendientes = new System.Windows.Forms.Button();
            this.gcProductos = new DevExpress.XtraGrid.GridControl();
            this.productosBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colbloque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colclave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDescargarInfo = new System.Windows.Forms.Button();
            this.btnVerifPendiente = new System.Windows.Forms.Button();
            this.lbLeyenda = new System.Windows.Forms.Label();
            this.lbPendientes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActPendientes
            // 
            this.btnActPendientes.Image = ((System.Drawing.Image)(resources.GetObject("btnActPendientes.Image")));
            this.btnActPendientes.Location = new System.Drawing.Point(477, 53);
            this.btnActPendientes.Name = "btnActPendientes";
            this.btnActPendientes.Size = new System.Drawing.Size(40, 40);
            this.btnActPendientes.TabIndex = 23;
            this.btnActPendientes.UseVisualStyleBackColor = true;
            this.btnActPendientes.Click += new System.EventHandler(this.btnActPendientes_Click);
            // 
            // gcProductos
            // 
            this.gcProductos.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcProductos.DataSource = this.productosBindingSource;
            this.gcProductos.Location = new System.Drawing.Point(12, 99);
            this.gcProductos.MainView = this.gridView1;
            this.gcProductos.Name = "gcProductos";
            this.gcProductos.Size = new System.Drawing.Size(673, 323);
            this.gcProductos.TabIndex = 21;
            this.gcProductos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productosBindingSource
            // 
            this.productosBindingSource.DataSource = typeof(DescargaPrecioTacos.Modelos.Productos);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colbloque,
            this.colclave,
            this.colproducto,
            this.colprecio});
            this.gridView1.GridControl = this.gcProductos;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Artículos";
            // 
            // colbloque
            // 
            this.colbloque.Caption = "Bloque";
            this.colbloque.FieldName = "bloque";
            this.colbloque.Name = "colbloque";
            this.colbloque.Visible = true;
            this.colbloque.VisibleIndex = 0;
            // 
            // colclave
            // 
            this.colclave.Caption = "Clave";
            this.colclave.FieldName = "clave";
            this.colclave.Name = "colclave";
            this.colclave.Visible = true;
            this.colclave.VisibleIndex = 1;
            // 
            // colproducto
            // 
            this.colproducto.Caption = "Producto";
            this.colproducto.FieldName = "producto";
            this.colproducto.Name = "colproducto";
            this.colproducto.Visible = true;
            this.colproducto.VisibleIndex = 2;
            // 
            // colprecio
            // 
            this.colprecio.Caption = "Precio";
            this.colprecio.FieldName = "precio";
            this.colprecio.Name = "colprecio";
            this.colprecio.Visible = true;
            this.colprecio.VisibleIndex = 3;
            // 
            // btnDescargarInfo
            // 
            this.btnDescargarInfo.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.btnDescargarInfo.Location = new System.Drawing.Point(526, 56);
            this.btnDescargarInfo.Name = "btnDescargarInfo";
            this.btnDescargarInfo.Size = new System.Drawing.Size(159, 33);
            this.btnDescargarInfo.TabIndex = 20;
            this.btnDescargarInfo.Text = "Actualizar Precios";
            this.btnDescargarInfo.UseVisualStyleBackColor = true;
            this.btnDescargarInfo.Click += new System.EventHandler(this.btnDescargarInfo_Click);
            // 
            // btnVerifPendiente
            // 
            this.btnVerifPendiente.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.btnVerifPendiente.Location = new System.Drawing.Point(12, 56);
            this.btnVerifPendiente.Name = "btnVerifPendiente";
            this.btnVerifPendiente.Size = new System.Drawing.Size(161, 33);
            this.btnVerifPendiente.TabIndex = 19;
            this.btnVerifPendiente.Text = "Cargar Información";
            this.btnVerifPendiente.UseVisualStyleBackColor = true;
            this.btnVerifPendiente.Click += new System.EventHandler(this.btnVerifPendiente_Click);
            // 
            // lbLeyenda
            // 
            this.lbLeyenda.AutoSize = true;
            this.lbLeyenda.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lbLeyenda.Location = new System.Drawing.Point(12, 11);
            this.lbLeyenda.Name = "lbLeyenda";
            this.lbLeyenda.Size = new System.Drawing.Size(300, 29);
            this.lbLeyenda.TabIndex = 18;
            this.lbLeyenda.Text = "Descargar Precios Sucursal";
            // 
            // lbPendientes
            // 
            this.lbPendientes.BackColor = System.Drawing.Color.Transparent;
            this.lbPendientes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbPendientes.Location = new System.Drawing.Point(180, 61);
            this.lbPendientes.Name = "lbPendientes";
            this.lbPendientes.Size = new System.Drawing.Size(291, 20);
            this.lbPendientes.TabIndex = 22;
            this.lbPendientes.Text = "VERIFIQUE ACTUALIZACIONES ->";
            this.lbPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 434);
            this.Controls.Add(this.btnActPendientes);
            this.Controls.Add(this.gcProductos);
            this.Controls.Add(this.btnDescargarInfo);
            this.Controls.Add(this.btnVerifPendiente);
            this.Controls.Add(this.lbLeyenda);
            this.Controls.Add(this.lbPendientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descarga Información de Precios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActPendientes;
        private DevExpress.XtraGrid.GridControl gcProductos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnDescargarInfo;
        private System.Windows.Forms.Button btnVerifPendiente;
        private System.Windows.Forms.Label lbLeyenda;
        private System.Windows.Forms.Label lbPendientes;
        private System.Windows.Forms.BindingSource productosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colbloque;
        private DevExpress.XtraGrid.Columns.GridColumn colclave;
        private DevExpress.XtraGrid.Columns.GridColumn colproducto;
        private DevExpress.XtraGrid.Columns.GridColumn colprecio;


    }
}

