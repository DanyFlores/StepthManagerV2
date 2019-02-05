namespace StephManager
{
    partial class frmNominaConceptos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnQuitarCV = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAgregarCV = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnQuitarCF = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAgregarCF = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panelBase = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvConceptosVariables = new System.Windows.Forms.DataGridView();
            this.IDConceptoVariable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDConceptoV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panelIzquierda = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvConceptosFijos = new System.Windows.Forms.DataGridView();
            this.IDConceptoFijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Simbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelBase.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosVariables)).BeginInit();
            this.panelIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosFijos)).BeginInit();
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
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(857, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(514, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Conceptos Nominales";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.txtMensajeError);
            this.panel2.Controls.Add(this.btnSalir);
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
            this.txtMensajeError.Size = new System.Drawing.Size(839, 68);
            this.txtMensajeError.TabIndex = 63;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnSalir.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0006_regresr_a;
            this.btnSalir.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0006_regresr;
            this.btnSalir.ImagePressed = null;
            this.btnSalir.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSalir.KeyButton = System.Windows.Forms.Keys.None;
            this.btnSalir.KeyButtonView = false;
            this.btnSalir.Location = new System.Drawing.Point(916, 7);
            this.btnSalir.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSalir.MouseOverColor = System.Drawing.Color.Red;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.OffsetPressedContent = true;
            this.btnSalir.Size = new System.Drawing.Size(80, 70);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Regresar";
            this.btnSalir.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnSalir, "Cancelar y Regresar al Menú");
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnQuitarCV
            // 
            this.btnQuitarCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarCV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnQuitarCV.BorderColor = System.Drawing.Color.Red;
            this.btnQuitarCV.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnQuitarCV.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitarCV.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnQuitarCV.FocusRectangle = true;
            this.btnQuitarCV.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarCV.ForeColor = System.Drawing.Color.White;
            this.btnQuitarCV.Image = null;
            this.btnQuitarCV.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitarCV.ImageBorderColor = System.Drawing.Color.Red;
            this.btnQuitarCV.ImageFocused = null;
            this.btnQuitarCV.ImageInactive = null;
            this.btnQuitarCV.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0004_eliminar_a;
            this.btnQuitarCV.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0004_eliminar;
            this.btnQuitarCV.ImagePressed = null;
            this.btnQuitarCV.ImageSize = new System.Drawing.Size(44, 44);
            this.btnQuitarCV.KeyButton = System.Windows.Forms.Keys.None;
            this.btnQuitarCV.KeyButtonView = false;
            this.btnQuitarCV.Location = new System.Drawing.Point(414, 378);
            this.btnQuitarCV.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnQuitarCV.MouseOverColor = System.Drawing.Color.Red;
            this.btnQuitarCV.Name = "btnQuitarCV";
            this.btnQuitarCV.OffsetPressedContent = true;
            this.btnQuitarCV.Size = new System.Drawing.Size(80, 70);
            this.btnQuitarCV.TabIndex = 178;
            this.btnQuitarCV.Text = "Quitar";
            this.btnQuitarCV.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnQuitarCV, "Cancelar y Regresar al Menú");
            this.btnQuitarCV.UseVisualStyleBackColor = false;
            this.btnQuitarCV.Click += new System.EventHandler(this.btnQuitarCV_Click);
            // 
            // btnAgregarCV
            // 
            this.btnAgregarCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarCV.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarCV.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarCV.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarCV.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarCV.FocusRectangle = true;
            this.btnAgregarCV.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCV.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCV.Image = null;
            this.btnAgregarCV.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarCV.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarCV.ImageFocused = null;
            this.btnAgregarCV.ImageInactive = null;
            this.btnAgregarCV.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0001_agregar_a;
            this.btnAgregarCV.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0001_agregar;
            this.btnAgregarCV.ImagePressed = null;
            this.btnAgregarCV.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarCV.KeyButton = System.Windows.Forms.Keys.None;
            this.btnAgregarCV.KeyButtonView = false;
            this.btnAgregarCV.Location = new System.Drawing.Point(328, 378);
            this.btnAgregarCV.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarCV.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarCV.Name = "btnAgregarCV";
            this.btnAgregarCV.OffsetPressedContent = true;
            this.btnAgregarCV.Size = new System.Drawing.Size(80, 70);
            this.btnAgregarCV.TabIndex = 177;
            this.btnAgregarCV.Text = "Agregar";
            this.btnAgregarCV.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnAgregarCV, "Cancelar y Regresar al Menú");
            this.btnAgregarCV.UseVisualStyleBackColor = false;
            this.btnAgregarCV.Click += new System.EventHandler(this.btnAgregarCV_Click);
            // 
            // btnQuitarCF
            // 
            this.btnQuitarCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarCF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnQuitarCF.BorderColor = System.Drawing.Color.Red;
            this.btnQuitarCF.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnQuitarCF.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitarCF.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnQuitarCF.FocusRectangle = true;
            this.btnQuitarCF.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarCF.ForeColor = System.Drawing.Color.White;
            this.btnQuitarCF.Image = null;
            this.btnQuitarCF.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitarCF.ImageBorderColor = System.Drawing.Color.Red;
            this.btnQuitarCF.ImageFocused = null;
            this.btnQuitarCF.ImageInactive = null;
            this.btnQuitarCF.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0004_eliminar_a;
            this.btnQuitarCF.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0004_eliminar;
            this.btnQuitarCF.ImagePressed = null;
            this.btnQuitarCF.ImageSize = new System.Drawing.Size(44, 44);
            this.btnQuitarCF.KeyButton = System.Windows.Forms.Keys.None;
            this.btnQuitarCF.KeyButtonView = false;
            this.btnQuitarCF.Location = new System.Drawing.Point(417, 378);
            this.btnQuitarCF.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnQuitarCF.MouseOverColor = System.Drawing.Color.Red;
            this.btnQuitarCF.Name = "btnQuitarCF";
            this.btnQuitarCF.OffsetPressedContent = true;
            this.btnQuitarCF.Size = new System.Drawing.Size(80, 70);
            this.btnQuitarCF.TabIndex = 172;
            this.btnQuitarCF.Text = "Quitar";
            this.btnQuitarCF.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnQuitarCF, "Cancelar y Regresar al Menú");
            this.btnQuitarCF.UseVisualStyleBackColor = false;
            this.btnQuitarCF.Click += new System.EventHandler(this.btnQuitarCF_Click);
            // 
            // btnAgregarCF
            // 
            this.btnAgregarCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarCF.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarCF.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarCF.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarCF.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarCF.FocusRectangle = true;
            this.btnAgregarCF.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCF.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCF.Image = null;
            this.btnAgregarCF.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarCF.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarCF.ImageFocused = null;
            this.btnAgregarCF.ImageInactive = null;
            this.btnAgregarCF.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0001_agregar_a;
            this.btnAgregarCF.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0001_agregar;
            this.btnAgregarCF.ImagePressed = null;
            this.btnAgregarCF.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarCF.KeyButton = System.Windows.Forms.Keys.None;
            this.btnAgregarCF.KeyButtonView = false;
            this.btnAgregarCF.Location = new System.Drawing.Point(331, 378);
            this.btnAgregarCF.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarCF.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarCF.Name = "btnAgregarCF";
            this.btnAgregarCF.OffsetPressedContent = true;
            this.btnAgregarCF.Size = new System.Drawing.Size(80, 70);
            this.btnAgregarCF.TabIndex = 171;
            this.btnAgregarCF.Text = "Agregar";
            this.btnAgregarCF.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnAgregarCF, "Cancelar y Regresar al Menú");
            this.btnAgregarCF.UseVisualStyleBackColor = false;
            this.btnAgregarCF.Click += new System.EventHandler(this.btnAgregarCF_Click);
            // 
            // panelBase
            // 
            this.panelBase.BackColor = System.Drawing.Color.Gainsboro;
            this.panelBase.Controls.Add(this.panel5);
            this.panelBase.Controls.Add(this.panelIzquierda);
            this.panelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBase.Location = new System.Drawing.Point(0, 80);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(1008, 528);
            this.panelBase.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvConceptosVariables);
            this.panel5.Controls.Add(this.btnQuitarCV);
            this.panel5.Controls.Add(this.btnAgregarCV);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(504, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(504, 528);
            this.panel5.TabIndex = 1;
            // 
            // dgvConceptosVariables
            // 
            this.dgvConceptosVariables.AllowUserToAddRows = false;
            this.dgvConceptosVariables.AllowUserToDeleteRows = false;
            this.dgvConceptosVariables.AllowUserToOrderColumns = true;
            this.dgvConceptosVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConceptosVariables.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvConceptosVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptosVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDConceptoVariable,
            this.IDConceptoV,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvConceptosVariables.Location = new System.Drawing.Point(5, 111);
            this.dgvConceptosVariables.Name = "dgvConceptosVariables";
            this.dgvConceptosVariables.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConceptosVariables.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConceptosVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptosVariables.Size = new System.Drawing.Size(490, 247);
            this.dgvConceptosVariables.TabIndex = 173;
            // 
            // IDConceptoVariable
            // 
            this.IDConceptoVariable.DataPropertyName = "IDConceptoVariable";
            this.IDConceptoVariable.HeaderText = "IDConceptoFijo";
            this.IDConceptoVariable.Name = "IDConceptoVariable";
            this.IDConceptoVariable.ReadOnly = true;
            this.IDConceptoVariable.Visible = false;
            // 
            // IDConceptoV
            // 
            this.IDConceptoV.DataPropertyName = "IDConcepto";
            this.IDConceptoV.HeaderText = "IDConcepto";
            this.IDConceptoV.Name = "IDConceptoV";
            this.IDConceptoV.ReadOnly = true;
            this.IDConceptoV.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Concepto";
            this.dataGridViewTextBoxColumn3.HeaderText = "Concepto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Simbolo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Monto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "c";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "Monto";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 160;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 40);
            this.label1.TabIndex = 169;
            this.label1.Text = "CONCEPTOS VARIABLES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelIzquierda
            // 
            this.panelIzquierda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIzquierda.Controls.Add(this.btnQuitarCF);
            this.panelIzquierda.Controls.Add(this.btnAgregarCF);
            this.panelIzquierda.Controls.Add(this.label19);
            this.panelIzquierda.Controls.Add(this.dgvConceptosFijos);
            this.panelIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIzquierda.Location = new System.Drawing.Point(0, 0);
            this.panelIzquierda.Name = "panelIzquierda";
            this.panelIzquierda.Size = new System.Drawing.Size(504, 528);
            this.panelIzquierda.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(25, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(314, 40);
            this.label19.TabIndex = 168;
            this.label19.Text = "CONCEPTOS FIJOS";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvConceptosFijos
            // 
            this.dgvConceptosFijos.AllowUserToAddRows = false;
            this.dgvConceptosFijos.AllowUserToDeleteRows = false;
            this.dgvConceptosFijos.AllowUserToOrderColumns = true;
            this.dgvConceptosFijos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConceptosFijos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvConceptosFijos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptosFijos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDConceptoFijo,
            this.IDConcepto,
            this.Concepto,
            this.Simbolo,
            this.Monto});
            this.dgvConceptosFijos.Location = new System.Drawing.Point(7, 111);
            this.dgvConceptosFijos.Name = "dgvConceptosFijos";
            this.dgvConceptosFijos.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConceptosFijos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvConceptosFijos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptosFijos.Size = new System.Drawing.Size(490, 247);
            this.dgvConceptosFijos.TabIndex = 167;
            // 
            // IDConceptoFijo
            // 
            this.IDConceptoFijo.DataPropertyName = "IDConceptoFijo";
            this.IDConceptoFijo.HeaderText = "IDConceptoFijo";
            this.IDConceptoFijo.Name = "IDConceptoFijo";
            this.IDConceptoFijo.ReadOnly = true;
            this.IDConceptoFijo.Visible = false;
            // 
            // IDConcepto
            // 
            this.IDConcepto.DataPropertyName = "IDConcepto";
            this.IDConcepto.HeaderText = "IDConcepto";
            this.IDConcepto.Name = "IDConcepto";
            this.IDConcepto.ReadOnly = true;
            this.IDConcepto.Visible = false;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "Concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            this.Concepto.Width = 300;
            // 
            // Simbolo
            // 
            this.Simbolo.DataPropertyName = "Simbolo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Simbolo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Simbolo.HeaderText = "";
            this.Simbolo.Name = "Simbolo";
            this.Simbolo.ReadOnly = true;
            this.Simbolo.Width = 50;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "c";
            this.Monto.DefaultCellStyle = dataGridViewCellStyle5;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 160;
            // 
            // frmNominaConceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panelBase);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmNominaConceptos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNominaConceptos_Load);
            this.Resize += new System.EventHandler(this.frmNominaConceptos_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelBase.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosVariables)).EndInit();
            this.panelIzquierda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosFijos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSalir;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelIzquierda;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dgvConceptosFijos;
        private System.Windows.Forms.Label label1;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnQuitarCV;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarCV;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnQuitarCF;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarCF;
        private System.Windows.Forms.DataGridView dgvConceptosVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDConceptoVariable;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDConceptoV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDConceptoFijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Simbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
    }
}

