namespace StephManager
{
    partial class frmNuevo_Mobiliario_Resguardo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dgvMobiliario = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnGuardarResguardo = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cmbSucursales = new System.Windows.Forms.ComboBox();
            this.btnQuitarMobiliario = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAgregarMobiario = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.IDMobiliarioResguardo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMobiliario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobiliario)).BeginInit();
            this.panel7.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 688);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 608);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 89);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 519);
            this.panel5.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 439);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.Controls.Add(this.dgvMobiliario);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1008, 439);
            this.panel12.TabIndex = 2;
            // 
            // dgvMobiliario
            // 
            this.dgvMobiliario.AllowUserToAddRows = false;
            this.dgvMobiliario.AllowUserToDeleteRows = false;
            this.dgvMobiliario.AllowUserToResizeRows = false;
            this.dgvMobiliario.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvMobiliario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMobiliario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDMobiliarioResguardo,
            this.IDMobiliario,
            this.IDSucursal,
            this.Codigo,
            this.Descripcion,
            this.Marca,
            this.Modelo,
            this.Cantidad});
            this.dgvMobiliario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMobiliario.Location = new System.Drawing.Point(0, 0);
            this.dgvMobiliario.Name = "dgvMobiliario";
            this.dgvMobiliario.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMobiliario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMobiliario.Size = new System.Drawing.Size(1008, 439);
            this.dgvMobiliario.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PanelMenu);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 439);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 80);
            this.panel7.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.Gray;
            this.PanelMenu.Controls.Add(this.txtMensajeError);
            this.PanelMenu.Controls.Add(this.btnSalir);
            this.PanelMenu.Controls.Add(this.btnGuardarResguardo);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1008, 80);
            this.PanelMenu.TabIndex = 1;
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeError.Location = new System.Drawing.Point(31, 8);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(749, 69);
            this.txtMensajeError.TabIndex = 64;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSalir.BorderColor = System.Drawing.Color.Red;
            this.btnSalir.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSalir.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalir.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnSalir.FocusRectangle = true;
            this.btnSalir.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = null;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.ImageBorderColor = System.Drawing.Color.Red;
            this.btnSalir.ImageFocused = null;
            this.btnSalir.ImageInactive = null;
            this.btnSalir.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0002_cancelar_a;
            this.btnSalir.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0002_cancelar;
            this.btnSalir.ImagePressed = null;
            this.btnSalir.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSalir.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSalir.KeyButtonView = false;
            this.btnSalir.Location = new System.Drawing.Point(908, 5);
            this.btnSalir.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSalir.MouseOverColor = System.Drawing.Color.Red;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.OffsetPressedContent = true;
            this.btnSalir.Size = new System.Drawing.Size(80, 70);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.TextDropShadow = true;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardarResguardo
            // 
            this.btnGuardarResguardo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGuardarResguardo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGuardarResguardo.BorderColor = System.Drawing.Color.Red;
            this.btnGuardarResguardo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGuardarResguardo.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardarResguardo.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnGuardarResguardo.FocusRectangle = true;
            this.btnGuardarResguardo.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarResguardo.ForeColor = System.Drawing.Color.White;
            this.btnGuardarResguardo.Image = null;
            this.btnGuardarResguardo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarResguardo.ImageBorderColor = System.Drawing.Color.Red;
            this.btnGuardarResguardo.ImageFocused = null;
            this.btnGuardarResguardo.ImageInactive = null;
            this.btnGuardarResguardo.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0003_guardar_a;
            this.btnGuardarResguardo.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0003_guardar;
            this.btnGuardarResguardo.ImagePressed = null;
            this.btnGuardarResguardo.ImageSize = new System.Drawing.Size(44, 44);
            this.btnGuardarResguardo.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnGuardarResguardo.KeyButtonView = false;
            this.btnGuardarResguardo.Location = new System.Drawing.Point(822, 5);
            this.btnGuardarResguardo.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnGuardarResguardo.MouseOverColor = System.Drawing.Color.Red;
            this.btnGuardarResguardo.Name = "btnGuardarResguardo";
            this.btnGuardarResguardo.OffsetPressedContent = true;
            this.btnGuardarResguardo.Size = new System.Drawing.Size(80, 70);
            this.btnGuardarResguardo.TabIndex = 18;
            this.btnGuardarResguardo.Text = "Guardar";
            this.btnGuardarResguardo.TextDropShadow = true;
            this.btnGuardarResguardo.UseVisualStyleBackColor = false;
            this.btnGuardarResguardo.Click += new System.EventHandler(this.btnGuardarResguardo_Click);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 89);
            this.panel4.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DarkGray;
            this.panel10.Controls.Add(this.cmbSucursales);
            this.panel10.Controls.Add(this.btnQuitarMobiliario);
            this.panel10.Controls.Add(this.btnAgregarMobiario);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1008, 89);
            this.panel10.TabIndex = 2;
            // 
            // cmbSucursales
            // 
            this.cmbSucursales.FormattingEnabled = true;
            this.cmbSucursales.Location = new System.Drawing.Point(420, 29);
            this.cmbSucursales.Name = "cmbSucursales";
            this.cmbSucursales.Size = new System.Drawing.Size(312, 28);
            this.cmbSucursales.TabIndex = 61;
            // 
            // btnQuitarMobiliario
            // 
            this.btnQuitarMobiliario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnQuitarMobiliario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnQuitarMobiliario.BorderColor = System.Drawing.Color.Red;
            this.btnQuitarMobiliario.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnQuitarMobiliario.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitarMobiliario.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnQuitarMobiliario.FocusRectangle = true;
            this.btnQuitarMobiliario.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarMobiliario.ForeColor = System.Drawing.Color.Black;
            this.btnQuitarMobiliario.Image = null;
            this.btnQuitarMobiliario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitarMobiliario.ImageBorderColor = System.Drawing.Color.Red;
            this.btnQuitarMobiliario.ImageFocused = null;
            this.btnQuitarMobiliario.ImageInactive = null;
            this.btnQuitarMobiliario.ImageMouseOver = null;
            this.btnQuitarMobiliario.ImageNormal = null;
            this.btnQuitarMobiliario.ImagePressed = null;
            this.btnQuitarMobiliario.ImageSize = new System.Drawing.Size(44, 44);
            this.btnQuitarMobiliario.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnQuitarMobiliario.KeyButtonView = false;
            this.btnQuitarMobiliario.Location = new System.Drawing.Point(842, 9);
            this.btnQuitarMobiliario.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnQuitarMobiliario.MouseOverColor = System.Drawing.Color.Red;
            this.btnQuitarMobiliario.Name = "btnQuitarMobiliario";
            this.btnQuitarMobiliario.OffsetPressedContent = true;
            this.btnQuitarMobiliario.Size = new System.Drawing.Size(80, 70);
            this.btnQuitarMobiliario.TabIndex = 60;
            this.btnQuitarMobiliario.Text = "Eliminar";
            this.btnQuitarMobiliario.TextDropShadow = true;
            this.btnQuitarMobiliario.UseVisualStyleBackColor = false;
            this.btnQuitarMobiliario.Click += new System.EventHandler(this.btnQuitarMobiliario_Click);
            // 
            // btnAgregarMobiario
            // 
            this.btnAgregarMobiario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAgregarMobiario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarMobiario.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarMobiario.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarMobiario.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarMobiario.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarMobiario.FocusRectangle = true;
            this.btnAgregarMobiario.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMobiario.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarMobiario.Image = null;
            this.btnAgregarMobiario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarMobiario.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarMobiario.ImageFocused = null;
            this.btnAgregarMobiario.ImageInactive = null;
            this.btnAgregarMobiario.ImageMouseOver = null;
            this.btnAgregarMobiario.ImageNormal = null;
            this.btnAgregarMobiario.ImagePressed = null;
            this.btnAgregarMobiario.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarMobiario.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAgregarMobiario.KeyButtonView = false;
            this.btnAgregarMobiario.Location = new System.Drawing.Point(756, 9);
            this.btnAgregarMobiario.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarMobiario.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarMobiario.Name = "btnAgregarMobiario";
            this.btnAgregarMobiario.OffsetPressedContent = true;
            this.btnAgregarMobiario.Size = new System.Drawing.Size(80, 70);
            this.btnAgregarMobiario.TabIndex = 59;
            this.btnAgregarMobiario.Text = "Agregar";
            this.btnAgregarMobiario.TextDropShadow = true;
            this.btnAgregarMobiario.UseVisualStyleBackColor = false;
            this.btnAgregarMobiario.Click += new System.EventHandler(this.btnAgregarMobiario_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 37);
            this.label1.TabIndex = 58;
            this.label1.Text = "Sucursal";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 80);
            this.panel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.label42);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1008, 80);
            this.panel6.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(842, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(429, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Nuevo Resguardo";
            // 
            // IDMobiliarioResguardo
            // 
            this.IDMobiliarioResguardo.DataPropertyName = "IDMobiliarioResguardo";
            this.IDMobiliarioResguardo.HeaderText = "IDMobiliarioResguardo";
            this.IDMobiliarioResguardo.Name = "IDMobiliarioResguardo";
            this.IDMobiliarioResguardo.ReadOnly = true;
            this.IDMobiliarioResguardo.Visible = false;
            this.IDMobiliarioResguardo.Width = 106;
            // 
            // IDMobiliario
            // 
            this.IDMobiliario.DataPropertyName = "IDMobiliario";
            this.IDMobiliario.HeaderText = "IDMobiliario";
            this.IDMobiliario.Name = "IDMobiliario";
            this.IDMobiliario.Visible = false;
            // 
            // IDSucursal
            // 
            this.IDSucursal.DataPropertyName = "IDSucursal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IDSucursal.DefaultCellStyle = dataGridViewCellStyle1;
            this.IDSucursal.HeaderText = "IDSucursal";
            this.IDSucursal.Name = "IDSucursal";
            this.IDSucursal.ReadOnly = true;
            this.IDSucursal.Visible = false;
            this.IDSucursal.Width = 135;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Folio";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 150;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 250;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "Marca";
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            this.Marca.Width = 200;
            // 
            // Modelo
            // 
            this.Modelo.DataPropertyName = "Modelo";
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            this.Modelo.Width = 200;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.NullValue = "1";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.ToolTipText = "1";
            // 
            // frmNuevo_Mobiliario_Resguardo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmNuevo_Mobiliario_Resguardo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNuevo_Mobiliario_Resguardo_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobiliario)).EndInit();
            this.panel7.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.PanelMenu.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel PanelMenu;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSalir;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnGuardarResguardo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataGridView dgvMobiliario;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnQuitarMobiliario;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarMobiario;
        private System.Windows.Forms.ComboBox cmbSucursales;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMobiliarioResguardo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMobiliario;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}

