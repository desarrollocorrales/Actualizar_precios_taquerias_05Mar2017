﻿namespace ActPreciosTacos.GUIs
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbServidorMs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBaseDeDatosMs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnProbarConMysql = new System.Windows.Forms.Button();
            this.tbContraseniaMs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbUsuarioMs = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAutenticacionS = new System.Windows.Forms.ComboBox();
            this.tbBaseDatosS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbServidorS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnProbarConnMicrosip = new System.Windows.Forms.Button();
            this.tbContraseniaS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbUsuarioS = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbServidorMs);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbBaseDeDatosMs);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnProbarConMysql);
            this.groupBox2.Controls.Add(this.tbContraseniaMs);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbUsuarioMs);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(12, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 267);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MySQL";
            // 
            // tbServidorMs
            // 
            this.tbServidorMs.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbServidorMs.Location = new System.Drawing.Point(13, 42);
            this.tbServidorMs.Name = "tbServidorMs";
            this.tbServidorMs.Size = new System.Drawing.Size(235, 24);
            this.tbServidorMs.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label3.Location = new System.Drawing.Point(10, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Servidor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label4.Location = new System.Drawing.Point(10, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Usuario";
            // 
            // tbBaseDeDatosMs
            // 
            this.tbBaseDeDatosMs.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbBaseDeDatosMs.Location = new System.Drawing.Point(13, 189);
            this.tbBaseDeDatosMs.Name = "tbBaseDeDatosMs";
            this.tbBaseDeDatosMs.Size = new System.Drawing.Size(235, 24);
            this.tbBaseDeDatosMs.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label5.Location = new System.Drawing.Point(10, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "Contraseña";
            // 
            // btnProbarConMysql
            // 
            this.btnProbarConMysql.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnProbarConMysql.Location = new System.Drawing.Point(75, 225);
            this.btnProbarConMysql.Name = "btnProbarConMysql";
            this.btnProbarConMysql.Size = new System.Drawing.Size(106, 23);
            this.btnProbarConMysql.TabIndex = 11;
            this.btnProbarConMysql.Text = "Probar Conexión";
            this.btnProbarConMysql.UseVisualStyleBackColor = true;
            this.btnProbarConMysql.Click += new System.EventHandler(this.btnProbarConMysql_Click);
            // 
            // tbContraseniaMs
            // 
            this.tbContraseniaMs.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbContraseniaMs.Location = new System.Drawing.Point(13, 141);
            this.tbContraseniaMs.Name = "tbContraseniaMs";
            this.tbContraseniaMs.Size = new System.Drawing.Size(235, 24);
            this.tbContraseniaMs.TabIndex = 9;
            this.tbContraseniaMs.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label6.Location = new System.Drawing.Point(10, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Base de Datos";
            // 
            // tbUsuarioMs
            // 
            this.tbUsuarioMs.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbUsuarioMs.Location = new System.Drawing.Point(13, 90);
            this.tbUsuarioMs.Name = "tbUsuarioMs";
            this.tbUsuarioMs.Size = new System.Drawing.Size(235, 24);
            this.tbUsuarioMs.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAutenticacionS);
            this.groupBox1.Controls.Add(this.tbBaseDatosS);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbServidorS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnProbarConnMicrosip);
            this.groupBox1.Controls.Add(this.tbContraseniaS);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbUsuarioS);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 303);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SoftRestaurant";
            // 
            // cmbAutenticacionS
            // 
            this.cmbAutenticacionS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutenticacionS.FormattingEnabled = true;
            this.cmbAutenticacionS.Items.AddRange(new object[] {
            "Windows",
            "SQL Server"});
            this.cmbAutenticacionS.Location = new System.Drawing.Point(13, 133);
            this.cmbAutenticacionS.Name = "cmbAutenticacionS";
            this.cmbAutenticacionS.Size = new System.Drawing.Size(235, 24);
            this.cmbAutenticacionS.TabIndex = 3;
            this.cmbAutenticacionS.SelectionChangeCommitted += new System.EventHandler(this.cmbAutenticacionS_SelectionChangeCommitted);
            // 
            // tbBaseDatosS
            // 
            this.tbBaseDatosS.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbBaseDatosS.Location = new System.Drawing.Point(13, 84);
            this.tbBaseDatosS.Name = "tbBaseDatosS";
            this.tbBaseDatosS.Size = new System.Drawing.Size(235, 24);
            this.tbBaseDatosS.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label9.Location = new System.Drawing.Point(10, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 14);
            this.label9.TabIndex = 26;
            this.label9.Text = "Base de Datos";
            // 
            // tbServidorS
            // 
            this.tbServidorS.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbServidorS.Location = new System.Drawing.Point(13, 36);
            this.tbServidorS.Name = "tbServidorS";
            this.tbServidorS.Size = new System.Drawing.Size(235, 24);
            this.tbServidorS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label2.Location = new System.Drawing.Point(10, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 20;
            this.label2.Text = "Usuario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label7.Location = new System.Drawing.Point(10, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 14);
            this.label7.TabIndex = 22;
            this.label7.Text = "Contraseña";
            // 
            // btnProbarConnMicrosip
            // 
            this.btnProbarConnMicrosip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnProbarConnMicrosip.Location = new System.Drawing.Point(75, 269);
            this.btnProbarConnMicrosip.Name = "btnProbarConnMicrosip";
            this.btnProbarConnMicrosip.Size = new System.Drawing.Size(106, 23);
            this.btnProbarConnMicrosip.TabIndex = 6;
            this.btnProbarConnMicrosip.Text = "Probar Conexión";
            this.btnProbarConnMicrosip.UseVisualStyleBackColor = true;
            this.btnProbarConnMicrosip.Click += new System.EventHandler(this.btnProbarConnMicrosip_Click);
            // 
            // tbContraseniaS
            // 
            this.tbContraseniaS.Enabled = false;
            this.tbContraseniaS.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbContraseniaS.Location = new System.Drawing.Point(13, 232);
            this.tbContraseniaS.Name = "tbContraseniaS";
            this.tbContraseniaS.Size = new System.Drawing.Size(235, 24);
            this.tbContraseniaS.TabIndex = 5;
            this.tbContraseniaS.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label8.Location = new System.Drawing.Point(10, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "Autenticación";
            // 
            // tbUsuarioS
            // 
            this.tbUsuarioS.Enabled = false;
            this.tbUsuarioS.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbUsuarioS.Location = new System.Drawing.Point(13, 181);
            this.tbUsuarioS.Name = "tbUsuarioS";
            this.tbUsuarioS.Size = new System.Drawing.Size(235, 24);
            this.tbUsuarioS.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(164, 604);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 30);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 646);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuardar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbServidorMs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBaseDeDatosMs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnProbarConMysql;
        private System.Windows.Forms.TextBox tbContraseniaMs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbUsuarioMs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAutenticacionS;
        private System.Windows.Forms.TextBox tbBaseDatosS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbServidorS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnProbarConnMicrosip;
        private System.Windows.Forms.TextBox tbContraseniaS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbUsuarioS;
        private System.Windows.Forms.Button btnGuardar;
    }
}