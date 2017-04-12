namespace ActPreciosTacos.GUIs
{
    partial class frmDescargaInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescargaInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCargarBloques = new System.Windows.Forms.Button();
            this.cbMostrarBloques = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBloques = new System.Windows.Forms.ComboBox();
            this.gcActualizaciones = new DevExpress.XtraGrid.GridControl();
            this.actualizacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidActualizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnumBloque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colclaveArticulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpalmas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldolores = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colheroico = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmananero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbRealizados = new System.Windows.Forms.CheckBox();
            this.cbPendientes = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcActualizaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualizacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCargarBloques);
            this.panel1.Controls.Add(this.cbMostrarBloques);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbBloques);
            this.panel1.Location = new System.Drawing.Point(302, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 44);
            this.panel1.TabIndex = 22;
            // 
            // btnCargarBloques
            // 
            this.btnCargarBloques.Enabled = false;
            this.btnCargarBloques.Image = ((System.Drawing.Image)(resources.GetObject("btnCargarBloques.Image")));
            this.btnCargarBloques.Location = new System.Drawing.Point(171, 6);
            this.btnCargarBloques.Name = "btnCargarBloques";
            this.btnCargarBloques.Size = new System.Drawing.Size(30, 30);
            this.btnCargarBloques.TabIndex = 11;
            this.btnCargarBloques.UseVisualStyleBackColor = true;
            this.btnCargarBloques.Click += new System.EventHandler(this.btnCargarBloques_Click);
            // 
            // cbMostrarBloques
            // 
            this.cbMostrarBloques.AutoSize = true;
            this.cbMostrarBloques.Location = new System.Drawing.Point(16, 12);
            this.cbMostrarBloques.Name = "cbMostrarBloques";
            this.cbMostrarBloques.Size = new System.Drawing.Size(149, 21);
            this.cbMostrarBloques.TabIndex = 10;
            this.cbMostrarBloques.Text = "Mostrar por Bloques";
            this.cbMostrarBloques.UseVisualStyleBackColor = true;
            this.cbMostrarBloques.CheckedChanged += new System.EventHandler(this.cbMostrarBloques_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label4.Location = new System.Drawing.Point(212, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bloques";
            // 
            // cmbBloques
            // 
            this.cmbBloques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBloques.Enabled = false;
            this.cmbBloques.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cmbBloques.FormattingEnabled = true;
            this.cmbBloques.Location = new System.Drawing.Point(270, 10);
            this.cmbBloques.Name = "cmbBloques";
            this.cmbBloques.Size = new System.Drawing.Size(52, 24);
            this.cmbBloques.TabIndex = 6;
            // 
            // gcActualizaciones
            // 
            this.gcActualizaciones.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcActualizaciones.DataSource = this.actualizacionBindingSource;
            this.gcActualizaciones.Location = new System.Drawing.Point(12, 164);
            this.gcActualizaciones.MainView = this.gridView1;
            this.gcActualizaciones.Name = "gcActualizaciones";
            this.gcActualizaciones.Size = new System.Drawing.Size(698, 248);
            this.gcActualizaciones.TabIndex = 21;
            this.gcActualizaciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // actualizacionBindingSource
            // 
            this.actualizacionBindingSource.DataSource = typeof(ActPreciosTacos.Modelos.Actualizacion);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidActualizacion,
            this.colnumBloque,
            this.colfecha,
            this.colclaveArticulo,
            this.colproducto,
            this.colpalmas,
            this.coldolores,
            this.colheroico,
            this.colmananero,
            this.colprecio,
            this.colstatus});
            this.gridView1.GridControl = this.gcActualizaciones;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // colidActualizacion
            // 
            this.colidActualizacion.FieldName = "idActualizacion";
            this.colidActualizacion.Name = "colidActualizacion";
            // 
            // colnumBloque
            // 
            this.colnumBloque.AppearanceCell.Options.UseTextOptions = true;
            this.colnumBloque.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colnumBloque.Caption = "Bloque";
            this.colnumBloque.FieldName = "numBloque";
            this.colnumBloque.Name = "colnumBloque";
            this.colnumBloque.Visible = true;
            this.colnumBloque.VisibleIndex = 0;
            this.colnumBloque.Width = 40;
            // 
            // colfecha
            // 
            this.colfecha.Caption = "Fecha";
            this.colfecha.FieldName = "fecha";
            this.colfecha.Name = "colfecha";
            this.colfecha.Visible = true;
            this.colfecha.VisibleIndex = 1;
            this.colfecha.Width = 120;
            // 
            // colclaveArticulo
            // 
            this.colclaveArticulo.Caption = "Clave";
            this.colclaveArticulo.FieldName = "claveArticulo";
            this.colclaveArticulo.Name = "colclaveArticulo";
            this.colclaveArticulo.Visible = true;
            this.colclaveArticulo.VisibleIndex = 2;
            this.colclaveArticulo.Width = 50;
            // 
            // colproducto
            // 
            this.colproducto.Caption = "Producto";
            this.colproducto.FieldName = "producto";
            this.colproducto.Name = "colproducto";
            this.colproducto.Visible = true;
            this.colproducto.VisibleIndex = 3;
            this.colproducto.Width = 250;
            // 
            // colpalmas
            // 
            this.colpalmas.AppearanceCell.Options.UseTextOptions = true;
            this.colpalmas.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colpalmas.AppearanceHeader.Options.UseTextOptions = true;
            this.colpalmas.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colpalmas.Caption = "Palmas";
            this.colpalmas.FieldName = "palmas";
            this.colpalmas.Name = "colpalmas";
            this.colpalmas.Visible = true;
            this.colpalmas.VisibleIndex = 4;
            this.colpalmas.Width = 100;
            // 
            // coldolores
            // 
            this.coldolores.AppearanceCell.Options.UseTextOptions = true;
            this.coldolores.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldolores.AppearanceHeader.Options.UseTextOptions = true;
            this.coldolores.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coldolores.Caption = "Dolores";
            this.coldolores.FieldName = "dolores";
            this.coldolores.Name = "coldolores";
            this.coldolores.Visible = true;
            this.coldolores.VisibleIndex = 5;
            this.coldolores.Width = 100;
            // 
            // colheroico
            // 
            this.colheroico.AppearanceCell.Options.UseTextOptions = true;
            this.colheroico.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colheroico.AppearanceHeader.Options.UseTextOptions = true;
            this.colheroico.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colheroico.Caption = "Heróico";
            this.colheroico.FieldName = "heroico";
            this.colheroico.Name = "colheroico";
            this.colheroico.Visible = true;
            this.colheroico.VisibleIndex = 6;
            this.colheroico.Width = 100;
            // 
            // colmananero
            // 
            this.colmananero.AppearanceCell.Options.UseTextOptions = true;
            this.colmananero.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colmananero.AppearanceHeader.Options.UseTextOptions = true;
            this.colmananero.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colmananero.Caption = "Mañanero";
            this.colmananero.FieldName = "mananero";
            this.colmananero.Name = "colmananero";
            this.colmananero.Visible = true;
            this.colmananero.VisibleIndex = 7;
            this.colmananero.Width = 100;
            // 
            // colprecio
            // 
            this.colprecio.AppearanceCell.Options.UseTextOptions = true;
            this.colprecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colprecio.AppearanceHeader.Options.UseTextOptions = true;
            this.colprecio.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colprecio.Caption = "Precio";
            this.colprecio.FieldName = "precio";
            this.colprecio.Name = "colprecio";
            this.colprecio.Visible = true;
            this.colprecio.VisibleIndex = 8;
            this.colprecio.Width = 100;
            // 
            // colstatus
            // 
            this.colstatus.FieldName = "status";
            this.colstatus.Name = "colstatus";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(415, 125);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 33);
            this.btnBuscar.TabIndex = 20;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbRealizados
            // 
            this.cbRealizados.AutoSize = true;
            this.cbRealizados.Location = new System.Drawing.Point(320, 132);
            this.cbRealizados.Name = "cbRealizados";
            this.cbRealizados.Size = new System.Drawing.Size(89, 21);
            this.cbRealizados.TabIndex = 19;
            this.cbRealizados.Text = "Realizados";
            this.cbRealizados.UseVisualStyleBackColor = true;
            // 
            // cbPendientes
            // 
            this.cbPendientes.AutoSize = true;
            this.cbPendientes.Checked = true;
            this.cbPendientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPendientes.Location = new System.Drawing.Point(221, 132);
            this.cbPendientes.Name = "cbPendientes";
            this.cbPendientes.Size = new System.Drawing.Size(93, 21);
            this.cbPendientes.TabIndex = 18;
            this.cbPendientes.Text = "Pendientes";
            this.cbPendientes.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Fecha Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fecha Inicio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 22F);
            this.label1.Location = new System.Drawing.Point(59, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 36);
            this.label1.TabIndex = 15;
            this.label1.Text = "Taquerías que han descargado Información";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(82, 89);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(104, 24);
            this.dtpFechaInicio.TabIndex = 14;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(192, 89);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(104, 24);
            this.dtpFechaFin.TabIndex = 13;
            // 
            // frmDescargaInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gcActualizaciones);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbRealizados);
            this.Controls.Add(this.cbPendientes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.dtpFechaFin);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmDescargaInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Descarga Información";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcActualizaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualizacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCargarBloques;
        private System.Windows.Forms.CheckBox cbMostrarBloques;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBloques;
        private DevExpress.XtraGrid.GridControl gcActualizaciones;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox cbRealizados;
        private System.Windows.Forms.CheckBox cbPendientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.BindingSource actualizacionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidActualizacion;
        private DevExpress.XtraGrid.Columns.GridColumn colnumBloque;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha;
        private DevExpress.XtraGrid.Columns.GridColumn colclaveArticulo;
        private DevExpress.XtraGrid.Columns.GridColumn colpalmas;
        private DevExpress.XtraGrid.Columns.GridColumn coldolores;
        private DevExpress.XtraGrid.Columns.GridColumn colheroico;
        private DevExpress.XtraGrid.Columns.GridColumn colmananero;
        private DevExpress.XtraGrid.Columns.GridColumn colprecio;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colproducto;

    }
}