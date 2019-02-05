namespace StephManager
{
    partial class frmNuevaEncuesta
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
            this.btnBajarRespuesta = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSubirRespuesta = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnEliminarRespuesta = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAgregarRespuesta = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvRespuestas = new System.Windows.Forms.DataGridView();
            this.IDRespuesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Respuestas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnBajarPregunta = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSubirPregunta = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnbEliminarPregunta = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAgregarPregunta = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPreguntas = new System.Windows.Forms.DataGridView();
            this.IDPregunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TituloPregunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDTipoPregunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPregunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Requerida = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RequiereRespuestas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpFechaTermino = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoEncuesta = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtIncentivo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespuestas)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1008, 80);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(847, 12);
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
            this.label42.Size = new System.Drawing.Size(258, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Encuestas";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.txtMensajeError);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 608);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 80);
            this.panel2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.panel2, "Guardar la información");
            // 
            // txtMensajeError
            // 
            this.txtMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajeError.Location = new System.Drawing.Point(54, 8);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(749, 69);
            this.txtMensajeError.TabIndex = 63;
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
            this.btnGuardar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnGuardar.KeyButtonView = false;
            this.btnGuardar.Location = new System.Drawing.Point(830, 6);
            this.btnGuardar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnGuardar.MouseOverColor = System.Drawing.Color.Red;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OffsetPressedContent = true;
            this.btnGuardar.Size = new System.Drawing.Size(80, 70);
            this.btnGuardar.TabIndex = 14;
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
            this.btnCancelar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelar.KeyButtonView = false;
            this.btnCancelar.Location = new System.Drawing.Point(916, 7);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar y Regresar al Menú");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 528);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(490, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(518, 528);
            this.panel5.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnBajarRespuesta);
            this.panel7.Controls.Add(this.btnSubirRespuesta);
            this.panel7.Controls.Add(this.btnEliminarRespuesta);
            this.panel7.Controls.Add(this.btnAgregarRespuesta);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.dgvRespuestas);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 319);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(518, 209);
            this.panel7.TabIndex = 1;
            // 
            // btnBajarRespuesta
            // 
            this.btnBajarRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBajarRespuesta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBajarRespuesta.BorderColor = System.Drawing.Color.Red;
            this.btnBajarRespuesta.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBajarRespuesta.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBajarRespuesta.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnBajarRespuesta.FocusRectangle = true;
            this.btnBajarRespuesta.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajarRespuesta.ForeColor = System.Drawing.Color.Black;
            this.btnBajarRespuesta.Image = null;
            this.btnBajarRespuesta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBajarRespuesta.ImageBorderColor = System.Drawing.Color.Red;
            this.btnBajarRespuesta.ImageFocused = null;
            this.btnBajarRespuesta.ImageInactive = null;
            this.btnBajarRespuesta.ImageMouseOver = null;
            this.btnBajarRespuesta.ImageNormal = null;
            this.btnBajarRespuesta.ImagePressed = null;
            this.btnBajarRespuesta.ImageSize = new System.Drawing.Size(44, 44);
            this.btnBajarRespuesta.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnBajarRespuesta.KeyButtonView = false;
            this.btnBajarRespuesta.Location = new System.Drawing.Point(472, 173);
            this.btnBajarRespuesta.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBajarRespuesta.MouseOverColor = System.Drawing.Color.Red;
            this.btnBajarRespuesta.Name = "btnBajarRespuesta";
            this.btnBajarRespuesta.OffsetPressedContent = true;
            this.btnBajarRespuesta.Size = new System.Drawing.Size(34, 29);
            this.btnBajarRespuesta.TabIndex = 85;
            this.btnBajarRespuesta.Text = "▼";
            this.btnBajarRespuesta.TextDropShadow = true;
            this.btnBajarRespuesta.UseVisualStyleBackColor = false;
            this.btnBajarRespuesta.Click += new System.EventHandler(this.btnBajarRespuesta_Click);
            // 
            // btnSubirRespuesta
            // 
            this.btnSubirRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubirRespuesta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSubirRespuesta.BorderColor = System.Drawing.Color.Red;
            this.btnSubirRespuesta.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSubirRespuesta.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSubirRespuesta.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnSubirRespuesta.FocusRectangle = true;
            this.btnSubirRespuesta.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirRespuesta.ForeColor = System.Drawing.Color.Black;
            this.btnSubirRespuesta.Image = null;
            this.btnSubirRespuesta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSubirRespuesta.ImageBorderColor = System.Drawing.Color.Red;
            this.btnSubirRespuesta.ImageFocused = null;
            this.btnSubirRespuesta.ImageInactive = null;
            this.btnSubirRespuesta.ImageMouseOver = null;
            this.btnSubirRespuesta.ImageNormal = null;
            this.btnSubirRespuesta.ImagePressed = null;
            this.btnSubirRespuesta.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSubirRespuesta.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSubirRespuesta.KeyButtonView = false;
            this.btnSubirRespuesta.Location = new System.Drawing.Point(472, 138);
            this.btnSubirRespuesta.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSubirRespuesta.MouseOverColor = System.Drawing.Color.Red;
            this.btnSubirRespuesta.Name = "btnSubirRespuesta";
            this.btnSubirRespuesta.OffsetPressedContent = true;
            this.btnSubirRespuesta.Size = new System.Drawing.Size(34, 29);
            this.btnSubirRespuesta.TabIndex = 84;
            this.btnSubirRespuesta.Text = "▲";
            this.btnSubirRespuesta.TextDropShadow = true;
            this.btnSubirRespuesta.UseVisualStyleBackColor = false;
            this.btnSubirRespuesta.Click += new System.EventHandler(this.btnSubirRespuesta_Click);
            // 
            // btnEliminarRespuesta
            // 
            this.btnEliminarRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarRespuesta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminarRespuesta.BorderColor = System.Drawing.Color.Red;
            this.btnEliminarRespuesta.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminarRespuesta.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarRespuesta.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnEliminarRespuesta.FocusRectangle = true;
            this.btnEliminarRespuesta.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarRespuesta.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarRespuesta.Image = null;
            this.btnEliminarRespuesta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarRespuesta.ImageBorderColor = System.Drawing.Color.Red;
            this.btnEliminarRespuesta.ImageFocused = null;
            this.btnEliminarRespuesta.ImageInactive = null;
            this.btnEliminarRespuesta.ImageMouseOver = null;
            this.btnEliminarRespuesta.ImageNormal = null;
            this.btnEliminarRespuesta.ImagePressed = null;
            this.btnEliminarRespuesta.ImageSize = new System.Drawing.Size(44, 44);
            this.btnEliminarRespuesta.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnEliminarRespuesta.KeyButtonView = false;
            this.btnEliminarRespuesta.Location = new System.Drawing.Point(472, 84);
            this.btnEliminarRespuesta.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnEliminarRespuesta.MouseOverColor = System.Drawing.Color.Red;
            this.btnEliminarRespuesta.Name = "btnEliminarRespuesta";
            this.btnEliminarRespuesta.OffsetPressedContent = true;
            this.btnEliminarRespuesta.Size = new System.Drawing.Size(34, 29);
            this.btnEliminarRespuesta.TabIndex = 83;
            this.btnEliminarRespuesta.Text = "-";
            this.btnEliminarRespuesta.TextDropShadow = true;
            this.btnEliminarRespuesta.UseVisualStyleBackColor = false;
            this.btnEliminarRespuesta.Click += new System.EventHandler(this.btnEliminarRespuesta_Click);
            // 
            // btnAgregarRespuesta
            // 
            this.btnAgregarRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarRespuesta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarRespuesta.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarRespuesta.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarRespuesta.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarRespuesta.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarRespuesta.FocusRectangle = true;
            this.btnAgregarRespuesta.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRespuesta.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarRespuesta.Image = null;
            this.btnAgregarRespuesta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarRespuesta.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarRespuesta.ImageFocused = null;
            this.btnAgregarRespuesta.ImageInactive = null;
            this.btnAgregarRespuesta.ImageMouseOver = null;
            this.btnAgregarRespuesta.ImageNormal = null;
            this.btnAgregarRespuesta.ImagePressed = null;
            this.btnAgregarRespuesta.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarRespuesta.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAgregarRespuesta.KeyButtonView = false;
            this.btnAgregarRespuesta.Location = new System.Drawing.Point(472, 49);
            this.btnAgregarRespuesta.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarRespuesta.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarRespuesta.Name = "btnAgregarRespuesta";
            this.btnAgregarRespuesta.OffsetPressedContent = true;
            this.btnAgregarRespuesta.Size = new System.Drawing.Size(34, 29);
            this.btnAgregarRespuesta.TabIndex = 82;
            this.btnAgregarRespuesta.Text = "+";
            this.btnAgregarRespuesta.TextDropShadow = true;
            this.btnAgregarRespuesta.UseVisualStyleBackColor = false;
            this.btnAgregarRespuesta.Click += new System.EventHandler(this.btnAgregarRespuesta_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(41, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 20);
            this.label5.TabIndex = 81;
            this.label5.Text = "Respuestas";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(15, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 80;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvRespuestas
            // 
            this.dgvRespuestas.AllowUserToAddRows = false;
            this.dgvRespuestas.AllowUserToDeleteRows = false;
            this.dgvRespuestas.AllowUserToResizeRows = false;
            this.dgvRespuestas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRespuestas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRespuestas.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvRespuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRespuestas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDRespuesta,
            this.Respuestas});
            this.dgvRespuestas.Location = new System.Drawing.Point(20, 49);
            this.dgvRespuestas.MultiSelect = false;
            this.dgvRespuestas.Name = "dgvRespuestas";
            this.dgvRespuestas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRespuestas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRespuestas.Size = new System.Drawing.Size(432, 134);
            this.dgvRespuestas.TabIndex = 3;
            // 
            // IDRespuesta
            // 
            this.IDRespuesta.DataPropertyName = "IDRespuesta";
            this.IDRespuesta.HeaderText = "IDRespuesta";
            this.IDRespuesta.Name = "IDRespuesta";
            this.IDRespuesta.ReadOnly = true;
            this.IDRespuesta.Visible = false;
            // 
            // Respuestas
            // 
            this.Respuestas.DataPropertyName = "Titulo";
            this.Respuestas.HeaderText = "Posibles Respuestas";
            this.Respuestas.Name = "Respuestas";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnBajarPregunta);
            this.panel6.Controls.Add(this.btnSubirPregunta);
            this.panel6.Controls.Add(this.btnbEliminarPregunta);
            this.panel6.Controls.Add(this.btnAgregarPregunta);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.dgvPreguntas);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(518, 319);
            this.panel6.TabIndex = 0;
            // 
            // btnBajarPregunta
            // 
            this.btnBajarPregunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBajarPregunta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBajarPregunta.BorderColor = System.Drawing.Color.Red;
            this.btnBajarPregunta.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBajarPregunta.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBajarPregunta.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnBajarPregunta.FocusRectangle = true;
            this.btnBajarPregunta.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajarPregunta.ForeColor = System.Drawing.Color.Black;
            this.btnBajarPregunta.Image = null;
            this.btnBajarPregunta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBajarPregunta.ImageBorderColor = System.Drawing.Color.Red;
            this.btnBajarPregunta.ImageFocused = null;
            this.btnBajarPregunta.ImageInactive = null;
            this.btnBajarPregunta.ImageMouseOver = null;
            this.btnBajarPregunta.ImageNormal = null;
            this.btnBajarPregunta.ImagePressed = null;
            this.btnBajarPregunta.ImageSize = new System.Drawing.Size(44, 44);
            this.btnBajarPregunta.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnBajarPregunta.KeyButtonView = false;
            this.btnBajarPregunta.Location = new System.Drawing.Point(472, 202);
            this.btnBajarPregunta.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBajarPregunta.MouseOverColor = System.Drawing.Color.Red;
            this.btnBajarPregunta.Name = "btnBajarPregunta";
            this.btnBajarPregunta.OffsetPressedContent = true;
            this.btnBajarPregunta.Size = new System.Drawing.Size(34, 29);
            this.btnBajarPregunta.TabIndex = 83;
            this.btnBajarPregunta.Text = "▼";
            this.btnBajarPregunta.TextDropShadow = true;
            this.btnBajarPregunta.UseVisualStyleBackColor = false;
            this.btnBajarPregunta.Click += new System.EventHandler(this.btnBajarPregunta_Click);
            // 
            // btnSubirPregunta
            // 
            this.btnSubirPregunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubirPregunta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSubirPregunta.BorderColor = System.Drawing.Color.Red;
            this.btnSubirPregunta.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSubirPregunta.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSubirPregunta.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnSubirPregunta.FocusRectangle = true;
            this.btnSubirPregunta.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirPregunta.ForeColor = System.Drawing.Color.Black;
            this.btnSubirPregunta.Image = null;
            this.btnSubirPregunta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSubirPregunta.ImageBorderColor = System.Drawing.Color.Red;
            this.btnSubirPregunta.ImageFocused = null;
            this.btnSubirPregunta.ImageInactive = null;
            this.btnSubirPregunta.ImageMouseOver = null;
            this.btnSubirPregunta.ImageNormal = null;
            this.btnSubirPregunta.ImagePressed = null;
            this.btnSubirPregunta.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSubirPregunta.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSubirPregunta.KeyButtonView = false;
            this.btnSubirPregunta.Location = new System.Drawing.Point(472, 167);
            this.btnSubirPregunta.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSubirPregunta.MouseOverColor = System.Drawing.Color.Red;
            this.btnSubirPregunta.Name = "btnSubirPregunta";
            this.btnSubirPregunta.OffsetPressedContent = true;
            this.btnSubirPregunta.Size = new System.Drawing.Size(34, 29);
            this.btnSubirPregunta.TabIndex = 82;
            this.btnSubirPregunta.Text = "▲";
            this.btnSubirPregunta.TextDropShadow = true;
            this.btnSubirPregunta.UseVisualStyleBackColor = false;
            this.btnSubirPregunta.Click += new System.EventHandler(this.btnSubirPregunta_Click);
            // 
            // btnbEliminarPregunta
            // 
            this.btnbEliminarPregunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbEliminarPregunta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnbEliminarPregunta.BorderColor = System.Drawing.Color.Red;
            this.btnbEliminarPregunta.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnbEliminarPregunta.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnbEliminarPregunta.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnbEliminarPregunta.FocusRectangle = true;
            this.btnbEliminarPregunta.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbEliminarPregunta.ForeColor = System.Drawing.Color.Black;
            this.btnbEliminarPregunta.Image = null;
            this.btnbEliminarPregunta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnbEliminarPregunta.ImageBorderColor = System.Drawing.Color.Red;
            this.btnbEliminarPregunta.ImageFocused = null;
            this.btnbEliminarPregunta.ImageInactive = null;
            this.btnbEliminarPregunta.ImageMouseOver = null;
            this.btnbEliminarPregunta.ImageNormal = null;
            this.btnbEliminarPregunta.ImagePressed = null;
            this.btnbEliminarPregunta.ImageSize = new System.Drawing.Size(44, 44);
            this.btnbEliminarPregunta.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnbEliminarPregunta.KeyButtonView = false;
            this.btnbEliminarPregunta.Location = new System.Drawing.Point(472, 98);
            this.btnbEliminarPregunta.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnbEliminarPregunta.MouseOverColor = System.Drawing.Color.Red;
            this.btnbEliminarPregunta.Name = "btnbEliminarPregunta";
            this.btnbEliminarPregunta.OffsetPressedContent = true;
            this.btnbEliminarPregunta.Size = new System.Drawing.Size(34, 29);
            this.btnbEliminarPregunta.TabIndex = 81;
            this.btnbEliminarPregunta.Text = "-";
            this.btnbEliminarPregunta.TextDropShadow = true;
            this.btnbEliminarPregunta.UseVisualStyleBackColor = false;
            this.btnbEliminarPregunta.Click += new System.EventHandler(this.btnbEliminarPregunta_Click);
            // 
            // btnAgregarPregunta
            // 
            this.btnAgregarPregunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarPregunta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarPregunta.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarPregunta.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarPregunta.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarPregunta.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarPregunta.FocusRectangle = true;
            this.btnAgregarPregunta.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPregunta.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarPregunta.Image = null;
            this.btnAgregarPregunta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarPregunta.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarPregunta.ImageFocused = null;
            this.btnAgregarPregunta.ImageInactive = null;
            this.btnAgregarPregunta.ImageMouseOver = null;
            this.btnAgregarPregunta.ImageNormal = null;
            this.btnAgregarPregunta.ImagePressed = null;
            this.btnAgregarPregunta.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarPregunta.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAgregarPregunta.KeyButtonView = false;
            this.btnAgregarPregunta.Location = new System.Drawing.Point(472, 63);
            this.btnAgregarPregunta.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarPregunta.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarPregunta.Name = "btnAgregarPregunta";
            this.btnAgregarPregunta.OffsetPressedContent = true;
            this.btnAgregarPregunta.Size = new System.Drawing.Size(34, 29);
            this.btnAgregarPregunta.TabIndex = 80;
            this.btnAgregarPregunta.Text = "+";
            this.btnAgregarPregunta.TextDropShadow = true;
            this.btnAgregarPregunta.UseVisualStyleBackColor = false;
            this.btnAgregarPregunta.Click += new System.EventHandler(this.btnAgregarPregunta_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "Preguntas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 78;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPreguntas
            // 
            this.dgvPreguntas.AllowUserToAddRows = false;
            this.dgvPreguntas.AllowUserToDeleteRows = false;
            this.dgvPreguntas.AllowUserToResizeRows = false;
            this.dgvPreguntas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreguntas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPreguntas.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreguntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPregunta,
            this.TituloPregunta,
            this.IDTipoPregunta,
            this.TipoPregunta,
            this.Requerida,
            this.RequiereRespuestas});
            this.dgvPreguntas.Location = new System.Drawing.Point(20, 63);
            this.dgvPreguntas.MultiSelect = false;
            this.dgvPreguntas.Name = "dgvPreguntas";
            this.dgvPreguntas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreguntas.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreguntas.Size = new System.Drawing.Size(432, 222);
            this.dgvPreguntas.TabIndex = 2;
            this.dgvPreguntas.SelectionChanged += new System.EventHandler(this.dgvPreguntas_SelectionChanged);
            // 
            // IDPregunta
            // 
            this.IDPregunta.DataPropertyName = "IDPregunta";
            this.IDPregunta.HeaderText = "IDPregunta";
            this.IDPregunta.Name = "IDPregunta";
            this.IDPregunta.ReadOnly = true;
            this.IDPregunta.Visible = false;
            // 
            // TituloPregunta
            // 
            this.TituloPregunta.DataPropertyName = "Titulo";
            this.TituloPregunta.HeaderText = "Pregunta";
            this.TituloPregunta.Name = "TituloPregunta";
            this.TituloPregunta.ReadOnly = true;
            this.TituloPregunta.Width = 400;
            // 
            // IDTipoPregunta
            // 
            this.IDTipoPregunta.DataPropertyName = "IDTipoPregunta";
            this.IDTipoPregunta.HeaderText = "IDTipoPregunta";
            this.IDTipoPregunta.Name = "IDTipoPregunta";
            this.IDTipoPregunta.ReadOnly = true;
            this.IDTipoPregunta.Visible = false;
            // 
            // TipoPregunta
            // 
            this.TipoPregunta.DataPropertyName = "TipoPreguntaDesc";
            this.TipoPregunta.HeaderText = "Tipo de Pregunta";
            this.TipoPregunta.Name = "TipoPregunta";
            this.TipoPregunta.ReadOnly = true;
            this.TipoPregunta.Width = 180;
            // 
            // Requerida
            // 
            this.Requerida.DataPropertyName = "EsRequerida";
            this.Requerida.FillWeight = 80F;
            this.Requerida.HeaderText = "Requerida";
            this.Requerida.Name = "Requerida";
            this.Requerida.ReadOnly = true;
            this.Requerida.Width = 120;
            // 
            // RequiereRespuestas
            // 
            this.RequiereRespuestas.DataPropertyName = "RequiereRespuestas";
            this.RequiereRespuestas.HeaderText = "RequiereRespuestas";
            this.RequiereRespuestas.Name = "RequiereRespuestas";
            this.RequiereRespuestas.ReadOnly = true;
            this.RequiereRespuestas.Visible = false;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.dtpFechaTermino);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.cmbTipoEncuesta);
            this.panel4.Controls.Add(this.dtpFechaInicio);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.txtIncentivo);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.txtTitulo);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(490, 528);
            this.panel4.TabIndex = 0;
            // 
            // dtpFechaTermino
            // 
            this.dtpFechaTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTermino.Location = new System.Drawing.Point(280, 240);
            this.dtpFechaTermino.Name = "dtpFechaTermino";
            this.dtpFechaTermino.Size = new System.Drawing.Size(170, 25);
            this.dtpFechaTermino.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(291, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 20);
            this.label7.TabIndex = 107;
            this.label7.Text = "Fecha de Término";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(261, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 106;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTipoEncuesta
            // 
            this.cmbTipoEncuesta.FormattingEnabled = true;
            this.cmbTipoEncuesta.Items.AddRange(new object[] {
            "Por Cantidad Uso",
            "Por Tiempo Vida"});
            this.cmbTipoEncuesta.Location = new System.Drawing.Point(41, 155);
            this.cmbTipoEncuesta.Name = "cmbTipoEncuesta";
            this.cmbTipoEncuesta.Size = new System.Drawing.Size(300, 28);
            this.cmbTipoEncuesta.TabIndex = 2;
            this.cmbTipoEncuesta.SelectedIndexChanged += new System.EventHandler(this.cmbTipoEncuesta_SelectedIndexChanged);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(41, 240);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(170, 25);
            this.dtpFechaInicio.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(51, 217);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(156, 20);
            this.label16.TabIndex = 100;
            this.label16.Text = "Fecha de Inicio";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(27, 217);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 20);
            this.label17.TabIndex = 99;
            this.label17.Text = "*";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIncentivo
            // 
            this.txtIncentivo.Location = new System.Drawing.Point(41, 339);
            this.txtIncentivo.MaxLength = 10;
            this.txtIncentivo.Name = "txtIncentivo";
            this.txtIncentivo.Size = new System.Drawing.Size(170, 25);
            this.txtIncentivo.TabIndex = 5;
            this.txtIncentivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIncentivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtIncentivo_Validating);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(51, 319);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(242, 20);
            this.label14.TabIndex = 90;
            this.label14.Text = "Incentivo en Monedero";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(21, 319);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 20);
            this.label15.TabIndex = 89;
            this.label15.Text = "*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(40, 58);
            this.txtTitulo.MaxLength = 80;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(410, 25);
            this.txtTitulo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(50, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 20);
            this.label2.TabIndex = 81;
            this.label2.Text = "Título de la encuesta";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(25, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 80;
            this.label4.Text = "*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(51, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(207, 20);
            this.label12.TabIndex = 77;
            this.label12.Text = "Tipo de encuesta";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(26, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 20);
            this.label13.TabIndex = 76;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNuevaEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmNuevaEncuesta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNuevaEncuesta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespuestas)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtIncentivo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvRespuestas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPreguntas;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnEliminarRespuesta;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarRespuesta;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnbEliminarPregunta;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarPregunta;
        private System.Windows.Forms.ComboBox cmbTipoEncuesta;
        private System.Windows.Forms.DateTimePicker dtpFechaTermino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPregunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn TituloPregunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTipoPregunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPregunta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Requerida;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RequiereRespuestas;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBajarPregunta;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSubirPregunta;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBajarRespuesta;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSubirRespuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDRespuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Respuestas;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

