namespace StephManager
{
    partial class frmNuevoPuesto
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
            this.btnGuardar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnBajarSubTema = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSubirSubTema = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnbEliminarSubTema = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAgregarSubTema = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvSubPuesto = new System.Windows.Forms.DataGridView();
            this.IDCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDPuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SueldoBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNombrePuesto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubPuesto)).BeginInit();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(598, 80);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(430, 12);
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
            this.label42.Size = new System.Drawing.Size(180, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Puesto";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.txtMensajeError);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 468);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 80);
            this.panel2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.panel2, "Guardar la información");
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
            this.btnGuardar.KeyButton = System.Windows.Forms.Keys.None;
            this.btnGuardar.KeyButtonView = false;
            this.btnGuardar.Location = new System.Drawing.Point(372, 4);
            this.btnGuardar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnGuardar.MouseOverColor = System.Drawing.Color.Red;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OffsetPressedContent = true;
            this.btnGuardar.Size = new System.Drawing.Size(80, 70);
            this.btnGuardar.TabIndex = 2;
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
            this.btnCancelar.KeyButton = System.Windows.Forms.Keys.None;
            this.btnCancelar.KeyButtonView = false;
            this.btnCancelar.Location = new System.Drawing.Point(458, 5);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar y Regresar al Menú");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeError.Location = new System.Drawing.Point(12, 3);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(328, 69);
            this.txtMensajeError.TabIndex = 63;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.btnBajarSubTema);
            this.panel4.Controls.Add(this.btnSubirSubTema);
            this.panel4.Controls.Add(this.btnbEliminarSubTema);
            this.panel4.Controls.Add(this.btnAgregarSubTema);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.dgvSubPuesto);
            this.panel4.Controls.Add(this.txtNombrePuesto);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(598, 388);
            this.panel4.TabIndex = 0;
            // 
            // btnBajarSubTema
            // 
            this.btnBajarSubTema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBajarSubTema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBajarSubTema.BorderColor = System.Drawing.Color.Red;
            this.btnBajarSubTema.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBajarSubTema.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBajarSubTema.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnBajarSubTema.FocusRectangle = true;
            this.btnBajarSubTema.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajarSubTema.ForeColor = System.Drawing.Color.Black;
            this.btnBajarSubTema.Image = null;
            this.btnBajarSubTema.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBajarSubTema.ImageBorderColor = System.Drawing.Color.Red;
            this.btnBajarSubTema.ImageFocused = null;
            this.btnBajarSubTema.ImageInactive = null;
            this.btnBajarSubTema.ImageMouseOver = null;
            this.btnBajarSubTema.ImageNormal = null;
            this.btnBajarSubTema.ImagePressed = null;
            this.btnBajarSubTema.ImageSize = new System.Drawing.Size(44, 44);
            this.btnBajarSubTema.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnBajarSubTema.KeyButtonView = false;
            this.btnBajarSubTema.Location = new System.Drawing.Point(525, 275);
            this.btnBajarSubTema.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBajarSubTema.MouseOverColor = System.Drawing.Color.Red;
            this.btnBajarSubTema.Name = "btnBajarSubTema";
            this.btnBajarSubTema.OffsetPressedContent = true;
            this.btnBajarSubTema.Size = new System.Drawing.Size(34, 29);
            this.btnBajarSubTema.TabIndex = 113;
            this.btnBajarSubTema.Text = "▼";
            this.btnBajarSubTema.TextDropShadow = true;
            this.btnBajarSubTema.UseVisualStyleBackColor = false;
            this.btnBajarSubTema.Click += new System.EventHandler(this.btnBajarSubTema_Click);
            // 
            // btnSubirSubTema
            // 
            this.btnSubirSubTema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubirSubTema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSubirSubTema.BorderColor = System.Drawing.Color.Red;
            this.btnSubirSubTema.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSubirSubTema.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSubirSubTema.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnSubirSubTema.FocusRectangle = true;
            this.btnSubirSubTema.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirSubTema.ForeColor = System.Drawing.Color.Black;
            this.btnSubirSubTema.Image = null;
            this.btnSubirSubTema.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSubirSubTema.ImageBorderColor = System.Drawing.Color.Red;
            this.btnSubirSubTema.ImageFocused = null;
            this.btnSubirSubTema.ImageInactive = null;
            this.btnSubirSubTema.ImageMouseOver = null;
            this.btnSubirSubTema.ImageNormal = null;
            this.btnSubirSubTema.ImagePressed = null;
            this.btnSubirSubTema.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSubirSubTema.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSubirSubTema.KeyButtonView = false;
            this.btnSubirSubTema.Location = new System.Drawing.Point(525, 240);
            this.btnSubirSubTema.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSubirSubTema.MouseOverColor = System.Drawing.Color.Red;
            this.btnSubirSubTema.Name = "btnSubirSubTema";
            this.btnSubirSubTema.OffsetPressedContent = true;
            this.btnSubirSubTema.Size = new System.Drawing.Size(34, 29);
            this.btnSubirSubTema.TabIndex = 112;
            this.btnSubirSubTema.Text = "▲";
            this.btnSubirSubTema.TextDropShadow = true;
            this.btnSubirSubTema.UseVisualStyleBackColor = false;
            this.btnSubirSubTema.Click += new System.EventHandler(this.btnSubirSubTema_Click);
            // 
            // btnbEliminarSubTema
            // 
            this.btnbEliminarSubTema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbEliminarSubTema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnbEliminarSubTema.BorderColor = System.Drawing.Color.Red;
            this.btnbEliminarSubTema.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnbEliminarSubTema.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnbEliminarSubTema.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnbEliminarSubTema.FocusRectangle = true;
            this.btnbEliminarSubTema.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbEliminarSubTema.ForeColor = System.Drawing.Color.Black;
            this.btnbEliminarSubTema.Image = null;
            this.btnbEliminarSubTema.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnbEliminarSubTema.ImageBorderColor = System.Drawing.Color.Red;
            this.btnbEliminarSubTema.ImageFocused = null;
            this.btnbEliminarSubTema.ImageInactive = null;
            this.btnbEliminarSubTema.ImageMouseOver = null;
            this.btnbEliminarSubTema.ImageNormal = null;
            this.btnbEliminarSubTema.ImagePressed = null;
            this.btnbEliminarSubTema.ImageSize = new System.Drawing.Size(44, 44);
            this.btnbEliminarSubTema.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnbEliminarSubTema.KeyButtonView = false;
            this.btnbEliminarSubTema.Location = new System.Drawing.Point(525, 171);
            this.btnbEliminarSubTema.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnbEliminarSubTema.MouseOverColor = System.Drawing.Color.Red;
            this.btnbEliminarSubTema.Name = "btnbEliminarSubTema";
            this.btnbEliminarSubTema.OffsetPressedContent = true;
            this.btnbEliminarSubTema.Size = new System.Drawing.Size(34, 29);
            this.btnbEliminarSubTema.TabIndex = 111;
            this.btnbEliminarSubTema.Text = "-";
            this.btnbEliminarSubTema.TextDropShadow = true;
            this.btnbEliminarSubTema.UseVisualStyleBackColor = false;
            this.btnbEliminarSubTema.Click += new System.EventHandler(this.btnbEliminarSubTema_Click);
            // 
            // btnAgregarSubTema
            // 
            this.btnAgregarSubTema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarSubTema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarSubTema.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarSubTema.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarSubTema.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarSubTema.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarSubTema.FocusRectangle = true;
            this.btnAgregarSubTema.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarSubTema.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarSubTema.Image = null;
            this.btnAgregarSubTema.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarSubTema.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarSubTema.ImageFocused = null;
            this.btnAgregarSubTema.ImageInactive = null;
            this.btnAgregarSubTema.ImageMouseOver = null;
            this.btnAgregarSubTema.ImageNormal = null;
            this.btnAgregarSubTema.ImagePressed = null;
            this.btnAgregarSubTema.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarSubTema.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAgregarSubTema.KeyButtonView = false;
            this.btnAgregarSubTema.Location = new System.Drawing.Point(525, 136);
            this.btnAgregarSubTema.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarSubTema.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarSubTema.Name = "btnAgregarSubTema";
            this.btnAgregarSubTema.OffsetPressedContent = true;
            this.btnAgregarSubTema.Size = new System.Drawing.Size(34, 29);
            this.btnAgregarSubTema.TabIndex = 110;
            this.btnAgregarSubTema.Text = "+";
            this.btnAgregarSubTema.TextDropShadow = true;
            this.btnAgregarSubTema.UseVisualStyleBackColor = false;
            this.btnAgregarSubTema.Click += new System.EventHandler(this.btnAgregarSubTema_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(77, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 109;
            this.label2.Text = "Categoría";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(51, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 108;
            this.label4.Text = "*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSubPuesto
            // 
            this.dgvSubPuesto.AllowUserToAddRows = false;
            this.dgvSubPuesto.AllowUserToDeleteRows = false;
            this.dgvSubPuesto.AllowUserToResizeRows = false;
            this.dgvSubPuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubPuesto.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSubPuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubPuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCategoria,
            this.IDPuesto,
            this.Descripcion,
            this.SueldoBase});
            this.dgvSubPuesto.Location = new System.Drawing.Point(56, 136);
            this.dgvSubPuesto.MultiSelect = false;
            this.dgvSubPuesto.Name = "dgvSubPuesto";
            this.dgvSubPuesto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSubPuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubPuesto.Size = new System.Drawing.Size(432, 221);
            this.dgvSubPuesto.TabIndex = 107;
            // 
            // IDCategoria
            // 
            this.IDCategoria.DataPropertyName = "IDCategoria";
            this.IDCategoria.HeaderText = "IDCategoria";
            this.IDCategoria.Name = "IDCategoria";
            this.IDCategoria.ReadOnly = true;
            this.IDCategoria.Visible = false;
            // 
            // IDPuesto
            // 
            this.IDPuesto.DataPropertyName = "IDPuesto";
            this.IDPuesto.HeaderText = "IDPuesto";
            this.IDPuesto.Name = "IDPuesto";
            this.IDPuesto.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // SueldoBase
            // 
            this.SueldoBase.DataPropertyName = "SueldoBase";
            dataGridViewCellStyle1.Format = "C";
            this.SueldoBase.DefaultCellStyle = dataGridViewCellStyle1;
            this.SueldoBase.HeaderText = "Sueldo Base";
            this.SueldoBase.Name = "SueldoBase";
            // 
            // txtNombrePuesto
            // 
            this.txtNombrePuesto.Location = new System.Drawing.Point(66, 59);
            this.txtNombrePuesto.MaxLength = 150;
            this.txtNombrePuesto.Name = "txtNombrePuesto";
            this.txtNombrePuesto.Size = new System.Drawing.Size(422, 25);
            this.txtNombrePuesto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(76, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 106;
            this.label1.Text = "Nombre del Puesto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(51, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 105;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(598, 388);
            this.panel3.TabIndex = 2;
            // 
            // frmNuevoPuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(598, 548);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(600, 550);
            this.MinimumSize = new System.Drawing.Size(400, 550);
            this.Name = "frmNuevoPuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmNuevoTema_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubPuesto)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnGuardar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.TextBox txtNombrePuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBajarSubTema;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSubirSubTema;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnbEliminarSubTema;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarSubTema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvSubPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn SueldoBase;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

