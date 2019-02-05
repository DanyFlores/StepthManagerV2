namespace StephManager
{
    partial class frmNuevoMobiliario
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.btnGuardar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel06 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoMobiliario = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.btnbEliminarProveedor = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAgregarProveedor = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            this.IDProductoXProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoUltimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel06.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 80);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(526, 12);
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
            this.label42.Location = new System.Drawing.Point(15, 11);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(238, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Mobiliario";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.txtMensajeError);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 602);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 80);
            this.panel2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.panel2, "Guardar la información");
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeError.Location = new System.Drawing.Point(25, 5);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(468, 69);
            this.txtMensajeError.TabIndex = 62;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
            // 
            // btnGuardar
            // 
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
            this.btnGuardar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnGuardar.KeyButtonView = false;
            this.btnGuardar.Location = new System.Drawing.Point(499, 5);
            this.btnGuardar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnGuardar.MouseOverColor = System.Drawing.Color.Red;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OffsetPressedContent = true;
            this.btnGuardar.Size = new System.Drawing.Size(80, 70);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextDropShadow = true;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
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
            this.btnCancelar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelar.KeyButtonView = false;
            this.btnCancelar.Location = new System.Drawing.Point(585, 6);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar y Regresar al Menú");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 522);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(684, 522);
            this.panel5.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(684, 522);
            this.panel7.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel06);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(684, 522);
            this.panel8.TabIndex = 1;
            // 
            // panel06
            // 
            this.panel06.Controls.Add(this.label4);
            this.panel06.Controls.Add(this.label8);
            this.panel06.Controls.Add(this.cmbTipoMobiliario);
            this.panel06.Controls.Add(this.label7);
            this.panel06.Controls.Add(this.txtModelo);
            this.panel06.Controls.Add(this.label2);
            this.panel06.Controls.Add(this.txtMarca);
            this.panel06.Controls.Add(this.btnbEliminarProveedor);
            this.panel06.Controls.Add(this.txtDescripcion);
            this.panel06.Controls.Add(this.btnAgregarProveedor);
            this.panel06.Controls.Add(this.label6);
            this.panel06.Controls.Add(this.dgvProveedor);
            this.panel06.Controls.Add(this.label14);
            this.panel06.Controls.Add(this.label5);
            this.panel06.Controls.Add(this.label1);
            this.panel06.Controls.Add(this.txtClave);
            this.panel06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel06.Location = new System.Drawing.Point(0, 0);
            this.panel06.Name = "panel06";
            this.panel06.Size = new System.Drawing.Size(684, 522);
            this.panel06.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(330, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 179;
            this.label4.Text = "Tipo Mobiliario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(304, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 178;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTipoMobiliario
            // 
            this.cmbTipoMobiliario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipoMobiliario.FormattingEnabled = true;
            this.cmbTipoMobiliario.Location = new System.Drawing.Point(303, 61);
            this.cmbTipoMobiliario.Name = "cmbTipoMobiliario";
            this.cmbTipoMobiliario.Size = new System.Drawing.Size(276, 28);
            this.cmbTipoMobiliario.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(76, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 176;
            this.label7.Text = "Modelo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(70, 291);
            this.txtModelo.MaxLength = 20;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(199, 25);
            this.txtModelo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(76, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 173;
            this.label2.Text = "Marca";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(70, 228);
            this.txtMarca.MaxLength = 20;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(199, 25);
            this.txtMarca.TabIndex = 4;
            // 
            // btnbEliminarProveedor
            // 
            this.btnbEliminarProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbEliminarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnbEliminarProveedor.BorderColor = System.Drawing.Color.Red;
            this.btnbEliminarProveedor.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnbEliminarProveedor.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnbEliminarProveedor.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnbEliminarProveedor.FocusRectangle = true;
            this.btnbEliminarProveedor.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbEliminarProveedor.ForeColor = System.Drawing.Color.Black;
            this.btnbEliminarProveedor.Image = null;
            this.btnbEliminarProveedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnbEliminarProveedor.ImageBorderColor = System.Drawing.Color.Red;
            this.btnbEliminarProveedor.ImageFocused = null;
            this.btnbEliminarProveedor.ImageInactive = null;
            this.btnbEliminarProveedor.ImageMouseOver = null;
            this.btnbEliminarProveedor.ImageNormal = null;
            this.btnbEliminarProveedor.ImagePressed = null;
            this.btnbEliminarProveedor.ImageSize = new System.Drawing.Size(44, 44);
            this.btnbEliminarProveedor.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnbEliminarProveedor.KeyButtonView = false;
            this.btnbEliminarProveedor.Location = new System.Drawing.Point(562, 404);
            this.btnbEliminarProveedor.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnbEliminarProveedor.MouseOverColor = System.Drawing.Color.Red;
            this.btnbEliminarProveedor.Name = "btnbEliminarProveedor";
            this.btnbEliminarProveedor.OffsetPressedContent = true;
            this.btnbEliminarProveedor.Size = new System.Drawing.Size(34, 29);
            this.btnbEliminarProveedor.TabIndex = 8;
            this.btnbEliminarProveedor.Text = "-";
            this.btnbEliminarProveedor.TextDropShadow = true;
            this.btnbEliminarProveedor.UseVisualStyleBackColor = false;
            this.btnbEliminarProveedor.Click += new System.EventHandler(this.btnEliminarProveedor_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(70, 126);
            this.txtDescripcion.MaxLength = 130;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(347, 63);
            this.txtDescripcion.TabIndex = 3;
            // 
            // btnAgregarProveedor
            // 
            this.btnAgregarProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarProveedor.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarProveedor.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarProveedor.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarProveedor.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarProveedor.FocusRectangle = true;
            this.btnAgregarProveedor.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProveedor.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarProveedor.Image = null;
            this.btnAgregarProveedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarProveedor.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarProveedor.ImageFocused = null;
            this.btnAgregarProveedor.ImageInactive = null;
            this.btnAgregarProveedor.ImageMouseOver = null;
            this.btnAgregarProveedor.ImageNormal = null;
            this.btnAgregarProveedor.ImagePressed = null;
            this.btnAgregarProveedor.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarProveedor.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAgregarProveedor.KeyButtonView = false;
            this.btnAgregarProveedor.Location = new System.Drawing.Point(563, 359);
            this.btnAgregarProveedor.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarProveedor.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarProveedor.Name = "btnAgregarProveedor";
            this.btnAgregarProveedor.OffsetPressedContent = true;
            this.btnAgregarProveedor.Size = new System.Drawing.Size(34, 29);
            this.btnAgregarProveedor.TabIndex = 7;
            this.btnAgregarProveedor.Text = "+";
            this.btnAgregarProveedor.TextDropShadow = true;
            this.btnAgregarProveedor.UseVisualStyleBackColor = false;
            this.btnAgregarProveedor.Click += new System.EventHandler(this.btnAgregarProveedor_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(51, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 122;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.AllowUserToAddRows = false;
            this.dgvProveedor.AllowUserToDeleteRows = false;
            this.dgvProveedor.AllowUserToResizeRows = false;
            this.dgvProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedor.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProductoXProveedor,
            this.IDProveedor,
            this.RazonSocial,
            this.CostoUltimo});
            this.dgvProveedor.Location = new System.Drawing.Point(70, 359);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.Size = new System.Drawing.Size(477, 128);
            this.dgvProveedor.TabIndex = 6;
            this.dgvProveedor.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProveedor_CellValidating);
            this.dgvProveedor.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProveedor_DataError);
            // 
            // IDProductoXProveedor
            // 
            this.IDProductoXProveedor.DataPropertyName = "IDProductoXProveedor";
            this.IDProductoXProveedor.HeaderText = "IDProductoXProveedor";
            this.IDProductoXProveedor.Name = "IDProductoXProveedor";
            this.IDProductoXProveedor.Visible = false;
            // 
            // IDProveedor
            // 
            this.IDProveedor.DataPropertyName = "IDProveedor";
            this.IDProveedor.HeaderText = "IDProveedor";
            this.IDProveedor.Name = "IDProveedor";
            this.IDProveedor.ReadOnly = true;
            this.IDProveedor.Visible = false;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razón Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CostoUltimo
            // 
            this.CostoUltimo.DataPropertyName = "CostoUltimo";
            dataGridViewCellStyle1.Format = "c";
            this.CostoUltimo.DefaultCellStyle = dataGridViewCellStyle1;
            this.CostoUltimo.HeaderText = "Último costo";
            this.CostoUltimo.Name = "CostoUltimo";
            this.CostoUltimo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(76, 336);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 20);
            this.label14.TabIndex = 170;
            this.label14.Text = "Proveedores";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(76, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 20);
            this.label5.TabIndex = 123;
            this.label5.Text = "Descripción";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(76, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 120;
            this.label1.Text = "Clave/Cod. Barra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(70, 61);
            this.txtClave.MaxLength = 20;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(199, 25);
            this.txtClave.TabIndex = 1;
            // 
            // frmNuevoMobiliario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(684, 682);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(700, 720);
            this.MinimumSize = new System.Drawing.Size(700, 720);
            this.Name = "frmNuevoMobiliario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.Load += new System.EventHandler(this.frmNuevoProductoServicio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel06.ResumeLayout(false);
            this.panel06.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnGuardar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel06;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnbEliminarProveedor;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarProveedor;
        private System.Windows.Forms.DataGridView dgvProveedor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProductoXProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoUltimo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoMobiliario;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

