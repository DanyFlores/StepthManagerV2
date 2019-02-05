namespace StephManager
{
    partial class frmNuevaPromocion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.btnGuardar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkD = new System.Windows.Forms.CheckBox();
            this.chkS = new System.Windows.Forms.CheckBox();
            this.chkV = new System.Windows.Forms.CheckBox();
            this.chkJ = new System.Windows.Forms.CheckBox();
            this.chkX = new System.Windows.Forms.CheckBox();
            this.chkM = new System.Windows.Forms.CheckBox();
            this.chkL = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkListBoxSucursales = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEliminarServicio = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.IDServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarServicio = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtNombrePromocion = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1008, 80);
            this.panel1.TabIndex = 0;
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
            this.label42.Size = new System.Drawing.Size(316, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Promociones";
            // 
            // panel2
            // 
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
            this.txtMensajeError.Location = new System.Drawing.Point(40, 6);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(766, 69);
            this.txtMensajeError.TabIndex = 62;
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
            this.btnGuardar.Location = new System.Drawing.Point(829, 6);
            this.btnGuardar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnGuardar.MouseOverColor = System.Drawing.Color.Red;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OffsetPressedContent = true;
            this.btnGuardar.Size = new System.Drawing.Size(80, 70);
            this.btnGuardar.TabIndex = 13;
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
            this.btnCancelar.Location = new System.Drawing.Point(913, 6);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 14;
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
            this.panel3.Size = new System.Drawing.Size(1008, 528);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 528);
            this.panel5.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 528);
            this.panel7.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.chkD);
            this.panel8.Controls.Add(this.chkS);
            this.panel8.Controls.Add(this.chkV);
            this.panel8.Controls.Add(this.chkJ);
            this.panel8.Controls.Add(this.chkX);
            this.panel8.Controls.Add(this.chkM);
            this.panel8.Controls.Add(this.chkL);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.chkListBoxSucursales);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.btnEliminarServicio);
            this.panel8.Controls.Add(this.dgvServicios);
            this.panel8.Controls.Add(this.btnAgregarServicio);
            this.panel8.Controls.Add(this.txtNombrePromocion);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 528);
            this.panel8.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(76, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 130;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(102, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(267, 20);
            this.label8.TabIndex = 129;
            this.label8.Text = "Servicios";
            // 
            // chkD
            // 
            this.chkD.AutoSize = true;
            this.chkD.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkD.Location = new System.Drawing.Point(592, 132);
            this.chkD.Name = "chkD";
            this.chkD.Size = new System.Drawing.Size(86, 24);
            this.chkD.TabIndex = 8;
            this.chkD.Text = "Domingo";
            this.chkD.UseVisualStyleBackColor = true;
            // 
            // chkS
            // 
            this.chkS.AutoSize = true;
            this.chkS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkS.Location = new System.Drawing.Point(511, 132);
            this.chkS.Name = "chkS";
            this.chkS.Size = new System.Drawing.Size(75, 24);
            this.chkS.TabIndex = 7;
            this.chkS.Text = "Sábado";
            this.chkS.UseVisualStyleBackColor = true;
            // 
            // chkV
            // 
            this.chkV.AutoSize = true;
            this.chkV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkV.Location = new System.Drawing.Point(428, 132);
            this.chkV.Name = "chkV";
            this.chkV.Size = new System.Drawing.Size(77, 24);
            this.chkV.TabIndex = 6;
            this.chkV.Text = "Viernes";
            this.chkV.UseVisualStyleBackColor = true;
            // 
            // chkJ
            // 
            this.chkJ.AutoSize = true;
            this.chkJ.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkJ.Location = new System.Drawing.Point(350, 132);
            this.chkJ.Name = "chkJ";
            this.chkJ.Size = new System.Drawing.Size(72, 24);
            this.chkJ.TabIndex = 5;
            this.chkJ.Text = "Jueves";
            this.chkJ.UseVisualStyleBackColor = true;
            // 
            // chkX
            // 
            this.chkX.AutoSize = true;
            this.chkX.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkX.Location = new System.Drawing.Point(255, 132);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(89, 24);
            this.chkX.TabIndex = 4;
            this.chkX.Text = "Miércoles";
            this.chkX.UseVisualStyleBackColor = true;
            // 
            // chkM
            // 
            this.chkM.AutoSize = true;
            this.chkM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkM.Location = new System.Drawing.Point(176, 132);
            this.chkM.Name = "chkM";
            this.chkM.Size = new System.Drawing.Size(73, 24);
            this.chkM.TabIndex = 3;
            this.chkM.Text = "Martes";
            this.chkM.UseVisualStyleBackColor = true;
            // 
            // chkL
            // 
            this.chkL.AutoSize = true;
            this.chkL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkL.Location = new System.Drawing.Point(104, 132);
            this.chkL.Name = "chkL";
            this.chkL.Size = new System.Drawing.Size(66, 24);
            this.chkL.TabIndex = 2;
            this.chkL.Text = "Lunes";
            this.chkL.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(74, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 121;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(100, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 20);
            this.label4.TabIndex = 120;
            this.label4.Text = "Días de promoción";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(76, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 119;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(102, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 20);
            this.label1.TabIndex = 118;
            this.label1.Text = "Sucursales";
            // 
            // chkListBoxSucursales
            // 
            this.chkListBoxSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListBoxSucursales.CheckOnClick = true;
            this.chkListBoxSucursales.ColumnWidth = 228;
            this.chkListBoxSucursales.FormattingEnabled = true;
            this.chkListBoxSucursales.HorizontalScrollbar = true;
            this.chkListBoxSucursales.Location = new System.Drawing.Point(104, 203);
            this.chkListBoxSucursales.MultiColumn = true;
            this.chkListBoxSucursales.Name = "chkListBoxSucursales";
            this.chkListBoxSucursales.Size = new System.Drawing.Size(740, 84);
            this.chkListBoxSucursales.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(76, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 115;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(100, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 20);
            this.label5.TabIndex = 116;
            this.label5.Text = "Nombre de la promoción";
            // 
            // btnEliminarServicio
            // 
            this.btnEliminarServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminarServicio.BorderColor = System.Drawing.Color.Red;
            this.btnEliminarServicio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminarServicio.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarServicio.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnEliminarServicio.FocusRectangle = true;
            this.btnEliminarServicio.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarServicio.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarServicio.Image = null;
            this.btnEliminarServicio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarServicio.ImageBorderColor = System.Drawing.Color.Red;
            this.btnEliminarServicio.ImageFocused = null;
            this.btnEliminarServicio.ImageInactive = null;
            this.btnEliminarServicio.ImageMouseOver = null;
            this.btnEliminarServicio.ImageNormal = null;
            this.btnEliminarServicio.ImagePressed = null;
            this.btnEliminarServicio.ImageSize = new System.Drawing.Size(44, 44);
            this.btnEliminarServicio.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnEliminarServicio.KeyButtonView = false;
            this.btnEliminarServicio.Location = new System.Drawing.Point(544, 404);
            this.btnEliminarServicio.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnEliminarServicio.MouseOverColor = System.Drawing.Color.Red;
            this.btnEliminarServicio.Name = "btnEliminarServicio";
            this.btnEliminarServicio.OffsetPressedContent = true;
            this.btnEliminarServicio.Size = new System.Drawing.Size(80, 29);
            this.btnEliminarServicio.TabIndex = 11;
            this.btnEliminarServicio.Text = "Remover";
            this.btnEliminarServicio.TextDropShadow = true;
            this.btnEliminarServicio.UseVisualStyleBackColor = false;
            this.btnEliminarServicio.Click += new System.EventHandler(this.btnEliminarProveedor_Click);
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AllowUserToResizeRows = false;
            this.dgvServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDServicio,
            this.NombreServicio});
            this.dgvServicios.Location = new System.Drawing.Point(102, 369);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(425, 120);
            this.dgvServicios.TabIndex = 12;
            // 
            // IDServicio
            // 
            this.IDServicio.DataPropertyName = "IDServicio";
            this.IDServicio.HeaderText = "IDServicio";
            this.IDServicio.Name = "IDServicio";
            this.IDServicio.ReadOnly = true;
            this.IDServicio.Visible = false;
            // 
            // NombreServicio
            // 
            this.NombreServicio.DataPropertyName = "NombreServicio";
            this.NombreServicio.HeaderText = "Servicio";
            this.NombreServicio.Name = "NombreServicio";
            this.NombreServicio.ReadOnly = true;
            // 
            // btnAgregarServicio
            // 
            this.btnAgregarServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarServicio.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarServicio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarServicio.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarServicio.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarServicio.FocusRectangle = true;
            this.btnAgregarServicio.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarServicio.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarServicio.Image = null;
            this.btnAgregarServicio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarServicio.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarServicio.ImageFocused = null;
            this.btnAgregarServicio.ImageInactive = null;
            this.btnAgregarServicio.ImageMouseOver = null;
            this.btnAgregarServicio.ImageNormal = null;
            this.btnAgregarServicio.ImagePressed = null;
            this.btnAgregarServicio.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarServicio.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAgregarServicio.KeyButtonView = false;
            this.btnAgregarServicio.Location = new System.Drawing.Point(544, 369);
            this.btnAgregarServicio.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarServicio.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarServicio.Name = "btnAgregarServicio";
            this.btnAgregarServicio.OffsetPressedContent = true;
            this.btnAgregarServicio.Size = new System.Drawing.Size(80, 29);
            this.btnAgregarServicio.TabIndex = 10;
            this.btnAgregarServicio.Text = "Seleccionar";
            this.btnAgregarServicio.TextDropShadow = true;
            this.btnAgregarServicio.UseVisualStyleBackColor = false;
            this.btnAgregarServicio.Click += new System.EventHandler(this.btnAgregarProveedor_Click);
            // 
            // txtNombrePromocion
            // 
            this.txtNombrePromocion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombrePromocion.Location = new System.Drawing.Point(102, 55);
            this.txtNombrePromocion.MaxLength = 130;
            this.txtNombrePromocion.Name = "txtNombrePromocion";
            this.txtNombrePromocion.Size = new System.Drawing.Size(437, 25);
            this.txtNombrePromocion.TabIndex = 1;
            // 
            // frmNuevaPromocion
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
            this.Name = "frmNuevaPromocion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNuevaPromocion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnGuardar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnEliminarServicio;
        private System.Windows.Forms.DataGridView dgvServicios;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarServicio;
        private System.Windows.Forms.TextBox txtNombrePromocion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkD;
        private System.Windows.Forms.CheckBox chkS;
        private System.Windows.Forms.CheckBox chkV;
        private System.Windows.Forms.CheckBox chkJ;
        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.CheckBox chkM;
        private System.Windows.Forms.CheckBox chkL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkListBoxSucursales;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreServicio;
    }
}

