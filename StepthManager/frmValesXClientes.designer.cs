namespace StephManager
{
    partial class frmValesXClientes
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.IDValeXCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDVale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoElectronico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTipoVale = new System.Windows.Forms.TextBox();
            this.btnEliminarCliente = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnGuardarCliente = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.label3 = new System.Windows.Forms.Label();
            this.btnElegirCliente = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtClientes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolioVale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidadLimite = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreVale = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 60);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(611, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(30, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(551, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Asignar clientes a vales";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.txtMensajeError);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 532);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 80);
            this.panel2.TabIndex = 1;
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeError.Location = new System.Drawing.Point(21, 6);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(603, 69);
            this.txtMensajeError.TabIndex = 64;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
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
            this.btnCancelar.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0006_regresr_a;
            this.btnCancelar.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0006_regresr;
            this.btnCancelar.ImagePressed = null;
            this.btnCancelar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancelar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelar.KeyButtonView = false;
            this.btnCancelar.Location = new System.Drawing.Point(674, 5);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Regresar";
            this.btnCancelar.TextDropShadow = true;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 472);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 209);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(776, 263);
            this.panel5.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgvClientes);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(21, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(733, 263);
            this.panel8.TabIndex = 4;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeColumns = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDValeXCliente,
            this.IDVale,
            this.IDCliente,
            this.NombreCliente,
            this.CorreoElectronico});
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvClientes.Location = new System.Drawing.Point(0, 0);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersWidth = 21;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(733, 263);
            this.dgvClientes.TabIndex = 1;
            // 
            // IDValeXCliente
            // 
            this.IDValeXCliente.DataPropertyName = "IDValeXCliente";
            this.IDValeXCliente.HeaderText = "IDValeXCliente";
            this.IDValeXCliente.Name = "IDValeXCliente";
            this.IDValeXCliente.Visible = false;
            // 
            // IDVale
            // 
            this.IDVale.DataPropertyName = "IDVale";
            this.IDVale.HeaderText = "IDVale";
            this.IDVale.Name = "IDVale";
            this.IDVale.Visible = false;
            // 
            // IDCliente
            // 
            this.IDCliente.DataPropertyName = "IDCliente";
            this.IDCliente.HeaderText = "IDCliente";
            this.IDCliente.Name = "IDCliente";
            this.IDCliente.Visible = false;
            // 
            // NombreCliente
            // 
            this.NombreCliente.DataPropertyName = "NombreCliente";
            this.NombreCliente.HeaderText = "Nombre Cliente";
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.Width = 350;
            // 
            // CorreoElectronico
            // 
            this.CorreoElectronico.DataPropertyName = "CorreoElectronico";
            this.CorreoElectronico.HeaderText = "Correo Electronico";
            this.CorreoElectronico.Name = "CorreoElectronico";
            this.CorreoElectronico.Width = 300;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(21, 263);
            this.panel7.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(754, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(22, 263);
            this.panel6.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Controls.Add(this.txtTipoVale);
            this.panel4.Controls.Add(this.btnEliminarCliente);
            this.panel4.Controls.Add(this.btnGuardarCliente);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnElegirCliente);
            this.panel4.Controls.Add(this.txtClientes);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtFolioVale);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtCantidadLimite);
            this.panel4.Controls.Add(this.label26);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txtNombreVale);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(776, 209);
            this.panel4.TabIndex = 0;
            // 
            // txtTipoVale
            // 
            this.txtTipoVale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTipoVale.Enabled = false;
            this.txtTipoVale.Location = new System.Drawing.Point(28, 106);
            this.txtTipoVale.MaxLength = 100;
            this.txtTipoVale.Name = "txtTipoVale";
            this.txtTipoVale.Size = new System.Drawing.Size(264, 25);
            this.txtTipoVale.TabIndex = 155;
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminarCliente.BorderColor = System.Drawing.Color.Red;
            this.btnEliminarCliente.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminarCliente.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarCliente.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnEliminarCliente.FocusRectangle = true;
            this.btnEliminarCliente.Image = null;
            this.btnEliminarCliente.ImageBorderColor = System.Drawing.Color.Red;
            this.btnEliminarCliente.ImageFocused = null;
            this.btnEliminarCliente.ImageInactive = null;
            this.btnEliminarCliente.ImageMouseOver = null;
            this.btnEliminarCliente.ImageNormal = null;
            this.btnEliminarCliente.ImagePressed = null;
            this.btnEliminarCliente.ImageSize = new System.Drawing.Size(35, 35);
            this.btnEliminarCliente.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnEliminarCliente.KeyButtonView = false;
            this.btnEliminarCliente.Location = new System.Drawing.Point(623, 167);
            this.btnEliminarCliente.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnEliminarCliente.MouseOverColor = System.Drawing.Color.Red;
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.OffsetPressedContent = true;
            this.btnEliminarCliente.Size = new System.Drawing.Size(118, 24);
            this.btnEliminarCliente.TabIndex = 154;
            this.btnEliminarCliente.Text = "Eliminar Cliente";
            this.btnEliminarCliente.TextDropShadow = true;
            this.btnEliminarCliente.UseVisualStyleBackColor = false;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // btnGuardarCliente
            // 
            this.btnGuardarCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGuardarCliente.BorderColor = System.Drawing.Color.Red;
            this.btnGuardarCliente.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnGuardarCliente.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardarCliente.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnGuardarCliente.FocusRectangle = true;
            this.btnGuardarCliente.Image = null;
            this.btnGuardarCliente.ImageBorderColor = System.Drawing.Color.Red;
            this.btnGuardarCliente.ImageFocused = null;
            this.btnGuardarCliente.ImageInactive = null;
            this.btnGuardarCliente.ImageMouseOver = null;
            this.btnGuardarCliente.ImageNormal = null;
            this.btnGuardarCliente.ImagePressed = null;
            this.btnGuardarCliente.ImageSize = new System.Drawing.Size(35, 35);
            this.btnGuardarCliente.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnGuardarCliente.KeyButtonView = false;
            this.btnGuardarCliente.Location = new System.Drawing.Point(499, 167);
            this.btnGuardarCliente.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnGuardarCliente.MouseOverColor = System.Drawing.Color.Red;
            this.btnGuardarCliente.Name = "btnGuardarCliente";
            this.btnGuardarCliente.OffsetPressedContent = true;
            this.btnGuardarCliente.Size = new System.Drawing.Size(118, 24);
            this.btnGuardarCliente.TabIndex = 153;
            this.btnGuardarCliente.Text = "Asignar Cliente";
            this.btnGuardarCliente.TextDropShadow = true;
            this.btnGuardarCliente.UseVisualStyleBackColor = false;
            this.btnGuardarCliente.Click += new System.EventHandler(this.btnGuardarCliente_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Location = new System.Drawing.Point(24, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 152;
            this.label3.Text = "Cliente";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnElegirCliente
            // 
            this.btnElegirCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnElegirCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnElegirCliente.BorderColor = System.Drawing.Color.Red;
            this.btnElegirCliente.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnElegirCliente.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnElegirCliente.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnElegirCliente.FocusRectangle = true;
            this.btnElegirCliente.Image = null;
            this.btnElegirCliente.ImageBorderColor = System.Drawing.Color.Red;
            this.btnElegirCliente.ImageFocused = null;
            this.btnElegirCliente.ImageInactive = null;
            this.btnElegirCliente.ImageMouseOver = null;
            this.btnElegirCliente.ImageNormal = null;
            this.btnElegirCliente.ImagePressed = null;
            this.btnElegirCliente.ImageSize = new System.Drawing.Size(35, 35);
            this.btnElegirCliente.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnElegirCliente.KeyButtonView = false;
            this.btnElegirCliente.Location = new System.Drawing.Point(275, 167);
            this.btnElegirCliente.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnElegirCliente.MouseOverColor = System.Drawing.Color.Red;
            this.btnElegirCliente.Name = "btnElegirCliente";
            this.btnElegirCliente.OffsetPressedContent = true;
            this.btnElegirCliente.Size = new System.Drawing.Size(74, 24);
            this.btnElegirCliente.TabIndex = 150;
            this.btnElegirCliente.Text = "Elegir";
            this.btnElegirCliente.TextDropShadow = true;
            this.btnElegirCliente.UseVisualStyleBackColor = false;
            this.btnElegirCliente.Click += new System.EventHandler(this.btnElegirCliente_Click);
            // 
            // txtClientes
            // 
            this.txtClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtClientes.Location = new System.Drawing.Point(27, 167);
            this.txtClientes.MaxLength = 70;
            this.txtClientes.Name = "txtClientes";
            this.txtClientes.ReadOnly = true;
            this.txtClientes.Size = new System.Drawing.Size(242, 25);
            this.txtClientes.TabIndex = 151;
            this.txtClientes.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(389, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 20);
            this.label1.TabIndex = 146;
            this.label1.Text = "Folio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFolioVale
            // 
            this.txtFolioVale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFolioVale.Enabled = false;
            this.txtFolioVale.Location = new System.Drawing.Point(389, 34);
            this.txtFolioVale.MaxLength = 20;
            this.txtFolioVale.Name = "txtFolioVale";
            this.txtFolioVale.Size = new System.Drawing.Size(270, 25);
            this.txtFolioVale.TabIndex = 143;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Location = new System.Drawing.Point(389, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 147;
            this.label2.Text = "Cantidad Limite";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCantidadLimite
            // 
            this.txtCantidadLimite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCantidadLimite.Enabled = false;
            this.txtCantidadLimite.Location = new System.Drawing.Point(389, 106);
            this.txtCantidadLimite.MaxLength = 20;
            this.txtCantidadLimite.Name = "txtCantidadLimite";
            this.txtCantidadLimite.Size = new System.Drawing.Size(131, 25);
            this.txtCantidadLimite.TabIndex = 144;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label26.Location = new System.Drawing.Point(23, 83);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(182, 20);
            this.label26.TabIndex = 149;
            this.label26.Text = "Tipo Vale:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Location = new System.Drawing.Point(23, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 20);
            this.label5.TabIndex = 148;
            this.label5.Text = "Nombre del vale";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNombreVale
            // 
            this.txtNombreVale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombreVale.Enabled = false;
            this.txtNombreVale.Location = new System.Drawing.Point(27, 35);
            this.txtNombreVale.MaxLength = 100;
            this.txtNombreVale.Name = "txtNombreVale";
            this.txtNombreVale.Size = new System.Drawing.Size(264, 25);
            this.txtNombreVale.TabIndex = 142;
            // 
            // frmValesXClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(776, 612);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 650);
            this.Name = "frmValesXClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.Load += new System.EventHandler(this.frmValesXClientes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnElegirCliente;
        private System.Windows.Forms.TextBox txtClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolioVale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidadLimite;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreVale;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnGuardarCliente;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnEliminarCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDValeXCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDVale;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoElectronico;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTipoVale;
    }
}

