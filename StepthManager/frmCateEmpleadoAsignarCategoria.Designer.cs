﻿namespace StephManager
{
    partial class frmCateEmpleadoAsignarCategoria
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSueldoBase = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCategoriaPuesto = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbCatPuesto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.btnGuardar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 423);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtSueldoBase);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.cmbCategoriaPuesto);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.cmbCatPuesto);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtEmpleado);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(549, 263);
            this.panel4.TabIndex = 2;
            // 
            // txtSueldoBase
            // 
            this.txtSueldoBase.Location = new System.Drawing.Point(76, 207);
            this.txtSueldoBase.MaxLength = 90;
            this.txtSueldoBase.Name = "txtSueldoBase";
            this.txtSueldoBase.ReadOnly = true;
            this.txtSueldoBase.Size = new System.Drawing.Size(151, 25);
            this.txtSueldoBase.TabIndex = 167;
            this.txtSueldoBase.TabStop = false;
            this.txtSueldoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(86, 187);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 20);
            this.label16.TabIndex = 168;
            this.label16.Text = "Sueldo Base";
            // 
            // cmbCategoriaPuesto
            // 
            this.cmbCategoriaPuesto.FormattingEnabled = true;
            this.cmbCategoriaPuesto.Location = new System.Drawing.Point(75, 158);
            this.cmbCategoriaPuesto.Name = "cmbCategoriaPuesto";
            this.cmbCategoriaPuesto.Size = new System.Drawing.Size(300, 28);
            this.cmbCategoriaPuesto.TabIndex = 3;
            this.cmbCategoriaPuesto.SelectedIndexChanged += new System.EventHandler(this.cmbCategoriaPuesto_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(85, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 20);
            this.label11.TabIndex = 166;
            this.label11.Text = "Categoría del puesto";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(62, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 20);
            this.label13.TabIndex = 165;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCatPuesto
            // 
            this.cmbCatPuesto.FormattingEnabled = true;
            this.cmbCatPuesto.Location = new System.Drawing.Point(74, 107);
            this.cmbCatPuesto.Name = "cmbCatPuesto";
            this.cmbCatPuesto.Size = new System.Drawing.Size(300, 28);
            this.cmbCatPuesto.TabIndex = 2;
            this.cmbCatPuesto.SelectedIndexChanged += new System.EventHandler(this.cmbCatPuesto_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(84, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 164;
            this.label4.Text = "Puesto";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(62, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 163;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(82, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Empleado";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(74, 57);
            this.txtEmpleado.MaxLength = 20;
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(337, 25);
            this.txtEmpleado.TabIndex = 26;
            this.txtEmpleado.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.txtMensajeError);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 343);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 80);
            this.panel3.TabIndex = 1;
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeError.Location = new System.Drawing.Point(14, 6);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(300, 69);
            this.txtMensajeError.TabIndex = 31;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGuardar.BorderColor = System.Drawing.Color.Red;
            this.btnGuardar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGuardar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnGuardar.FocusRectangle = true;
            this.btnGuardar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = null;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnGuardar.ImageFocused = null;
            this.btnGuardar.ImageInactive = null;
            this.btnGuardar.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0003_guardar_a;
            this.btnGuardar.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0003_guardar;
            this.btnGuardar.ImagePressed = null;
            this.btnGuardar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnGuardar.KeyButton = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.btnGuardar.KeyButtonView = false;
            this.btnGuardar.Location = new System.Drawing.Point(372, 6);
            this.btnGuardar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnGuardar.MouseOverColor = System.Drawing.Color.Red;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OffsetPressedContent = true;
            this.btnGuardar.Size = new System.Drawing.Size(80, 70);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextDropShadow = true;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancelar.BorderColor = System.Drawing.Color.Red;
            this.btnCancelar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancelar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnCancelar.FocusRectangle = true;
            this.btnCancelar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = null;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnCancelar.ImageFocused = null;
            this.btnCancelar.ImageInactive = null;
            this.btnCancelar.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0002_cancelar_a;
            this.btnCancelar.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0002_cancelar;
            this.btnCancelar.ImagePressed = null;
            this.btnCancelar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancelar.KeyButton = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.btnCancelar.KeyButtonView = false;
            this.btnCancelar.Location = new System.Drawing.Point(457, 6);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextDropShadow = true;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 80);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(407, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(-3, 22);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(396, 39);
            this.label42.TabIndex = 25;
            this.label42.Text = "Categoría de empleado";
            // 
            // frmCateEmpleadoAsignarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(549, 423);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCateEmpleadoAsignarCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAltaNominal_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label42;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnGuardar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSueldoBase;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCategoriaPuesto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbCatPuesto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

