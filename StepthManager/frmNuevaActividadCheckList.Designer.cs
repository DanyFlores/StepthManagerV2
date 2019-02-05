namespace StephManager
{
    partial class frmNuevaActividadCheckList
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvActividadesCheckList = new System.Windows.Forms.DataGridView();
            this.IDActividadCheckList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCategorioCheckList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreActividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnModificarActividad = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAgregarActividad = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnQuitarActividad = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.chkTodosLosRegistros = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRegresar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividadesCheckList)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 688);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 137);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 471);
            this.panel5.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgvActividadesCheckList);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(895, 471);
            this.panel8.TabIndex = 1;
            // 
            // dgvActividadesCheckList
            // 
            this.dgvActividadesCheckList.AllowUserToAddRows = false;
            this.dgvActividadesCheckList.AllowUserToDeleteRows = false;
            this.dgvActividadesCheckList.AllowUserToResizeColumns = false;
            this.dgvActividadesCheckList.AllowUserToResizeRows = false;
            this.dgvActividadesCheckList.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvActividadesCheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActividadesCheckList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDActividadCheckList,
            this.IDCategorioCheckList,
            this.NombreCategoria,
            this.NombreActividad,
            this.Orden});
            this.dgvActividadesCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActividadesCheckList.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvActividadesCheckList.Location = new System.Drawing.Point(0, 0);
            this.dgvActividadesCheckList.Name = "dgvActividadesCheckList";
            this.dgvActividadesCheckList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActividadesCheckList.Size = new System.Drawing.Size(895, 471);
            this.dgvActividadesCheckList.TabIndex = 2;
            // 
            // IDActividadCheckList
            // 
            this.IDActividadCheckList.DataPropertyName = "IDActividadCheckList";
            this.IDActividadCheckList.HeaderText = "IDActividadCheckList";
            this.IDActividadCheckList.Name = "IDActividadCheckList";
            this.IDActividadCheckList.Visible = false;
            // 
            // IDCategorioCheckList
            // 
            this.IDCategorioCheckList.DataPropertyName = "IDCategorioCheckList";
            this.IDCategorioCheckList.HeaderText = "IDCategorioCheckList";
            this.IDCategorioCheckList.Name = "IDCategorioCheckList";
            this.IDCategorioCheckList.ReadOnly = true;
            this.IDCategorioCheckList.Visible = false;
            // 
            // NombreCategoria
            // 
            this.NombreCategoria.DataPropertyName = "NombreCategoria";
            this.NombreCategoria.HeaderText = "Nombre Categoria";
            this.NombreCategoria.Name = "NombreCategoria";
            this.NombreCategoria.ReadOnly = true;
            this.NombreCategoria.Width = 350;
            // 
            // NombreActividad
            // 
            this.NombreActividad.DataPropertyName = "NombreActividad";
            this.NombreActividad.HeaderText = "Nombre Actividad";
            this.NombreActividad.Name = "NombreActividad";
            this.NombreActividad.ReadOnly = true;
            this.NombreActividad.Width = 600;
            // 
            // Orden
            // 
            this.Orden.DataPropertyName = "Orden";
            this.Orden.HeaderText = "Orden";
            this.Orden.Name = "Orden";
            this.Orden.ReadOnly = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnModificarActividad);
            this.panel7.Controls.Add(this.btnAgregarActividad);
            this.panel7.Controls.Add(this.btnQuitarActividad);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(895, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(113, 471);
            this.panel7.TabIndex = 0;
            // 
            // btnModificarActividad
            // 
            this.btnModificarActividad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnModificarActividad.BorderColor = System.Drawing.Color.Red;
            this.btnModificarActividad.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnModificarActividad.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnModificarActividad.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnModificarActividad.FocusRectangle = true;
            this.btnModificarActividad.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarActividad.ForeColor = System.Drawing.Color.White;
            this.btnModificarActividad.Image = null;
            this.btnModificarActividad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificarActividad.ImageBorderColor = System.Drawing.Color.Red;
            this.btnModificarActividad.ImageFocused = null;
            this.btnModificarActividad.ImageInactive = null;
            this.btnModificarActividad.ImageMouseOver = null;
            this.btnModificarActividad.ImageNormal = null;
            this.btnModificarActividad.ImagePressed = null;
            this.btnModificarActividad.ImageSize = new System.Drawing.Size(44, 44);
            this.btnModificarActividad.KeyButton = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.btnModificarActividad.KeyButtonView = false;
            this.btnModificarActividad.Location = new System.Drawing.Point(4, 196);
            this.btnModificarActividad.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnModificarActividad.MouseOverColor = System.Drawing.Color.Red;
            this.btnModificarActividad.Name = "btnModificarActividad";
            this.btnModificarActividad.OffsetPressedContent = true;
            this.btnModificarActividad.Size = new System.Drawing.Size(100, 29);
            this.btnModificarActividad.TabIndex = 5;
            this.btnModificarActividad.Text = "Modificar Act.";
            this.btnModificarActividad.TextDropShadow = true;
            this.btnModificarActividad.UseVisualStyleBackColor = false;
            this.btnModificarActividad.Click += new System.EventHandler(this.btnModificarActividad_Click);
            // 
            // btnAgregarActividad
            // 
            this.btnAgregarActividad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarActividad.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarActividad.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarActividad.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarActividad.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarActividad.FocusRectangle = true;
            this.btnAgregarActividad.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarActividad.ForeColor = System.Drawing.Color.White;
            this.btnAgregarActividad.Image = null;
            this.btnAgregarActividad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarActividad.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarActividad.ImageFocused = null;
            this.btnAgregarActividad.ImageInactive = null;
            this.btnAgregarActividad.ImageMouseOver = null;
            this.btnAgregarActividad.ImageNormal = null;
            this.btnAgregarActividad.ImagePressed = null;
            this.btnAgregarActividad.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarActividad.KeyButton = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.btnAgregarActividad.KeyButtonView = false;
            this.btnAgregarActividad.Location = new System.Drawing.Point(4, 58);
            this.btnAgregarActividad.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarActividad.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarActividad.Name = "btnAgregarActividad";
            this.btnAgregarActividad.OffsetPressedContent = true;
            this.btnAgregarActividad.Size = new System.Drawing.Size(100, 29);
            this.btnAgregarActividad.TabIndex = 3;
            this.btnAgregarActividad.Text = "Agregar Act.";
            this.btnAgregarActividad.TextDropShadow = true;
            this.btnAgregarActividad.UseVisualStyleBackColor = false;
            this.btnAgregarActividad.Click += new System.EventHandler(this.btnAgregarActividad_Click);
            // 
            // btnQuitarActividad
            // 
            this.btnQuitarActividad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnQuitarActividad.BorderColor = System.Drawing.Color.Red;
            this.btnQuitarActividad.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnQuitarActividad.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitarActividad.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnQuitarActividad.FocusRectangle = true;
            this.btnQuitarActividad.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarActividad.ForeColor = System.Drawing.Color.White;
            this.btnQuitarActividad.Image = null;
            this.btnQuitarActividad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitarActividad.ImageBorderColor = System.Drawing.Color.Red;
            this.btnQuitarActividad.ImageFocused = null;
            this.btnQuitarActividad.ImageInactive = null;
            this.btnQuitarActividad.ImageMouseOver = null;
            this.btnQuitarActividad.ImageNormal = null;
            this.btnQuitarActividad.ImagePressed = null;
            this.btnQuitarActividad.ImageSize = new System.Drawing.Size(44, 44);
            this.btnQuitarActividad.KeyButton = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.btnQuitarActividad.KeyButtonView = false;
            this.btnQuitarActividad.Location = new System.Drawing.Point(4, 129);
            this.btnQuitarActividad.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnQuitarActividad.MouseOverColor = System.Drawing.Color.Red;
            this.btnQuitarActividad.Name = "btnQuitarActividad";
            this.btnQuitarActividad.OffsetPressedContent = true;
            this.btnQuitarActividad.Size = new System.Drawing.Size(100, 29);
            this.btnQuitarActividad.TabIndex = 4;
            this.btnQuitarActividad.Text = "Quitar Act.";
            this.btnQuitarActividad.TextDropShadow = true;
            this.btnQuitarActividad.UseVisualStyleBackColor = false;
            this.btnQuitarActividad.Click += new System.EventHandler(this.btnQuitarActividad_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Controls.Add(this.txtBusqueda);
            this.panel4.Controls.Add(this.chkTodosLosRegistros);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 57);
            this.panel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "Titulo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBuscar.BorderColor = System.Drawing.Color.Red;
            this.btnBuscar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBuscar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBuscar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnBuscar.FocusRectangle = true;
            this.btnBuscar.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = null;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnBuscar.ImageFocused = null;
            this.btnBuscar.ImageInactive = null;
            this.btnBuscar.ImageMouseOver = null;
            this.btnBuscar.ImageNormal = null;
            this.btnBuscar.ImagePressed = null;
            this.btnBuscar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnBuscar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnBuscar.KeyButtonView = false;
            this.btnBuscar.Location = new System.Drawing.Point(589, 14);
            this.btnBuscar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBuscar.MouseOverColor = System.Drawing.Color.Red;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OffsetPressedContent = true;
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextDropShadow = true;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBusqueda.Location = new System.Drawing.Point(184, 14);
            this.txtBusqueda.MaxLength = 300;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(397, 25);
            this.txtBusqueda.TabIndex = 63;
            // 
            // chkTodosLosRegistros
            // 
            this.chkTodosLosRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTodosLosRegistros.Location = new System.Drawing.Point(830, 14);
            this.chkTodosLosRegistros.Name = "chkTodosLosRegistros";
            this.chkTodosLosRegistros.Size = new System.Drawing.Size(156, 25);
            this.chkTodosLosRegistros.TabIndex = 2;
            this.chkTodosLosRegistros.Text = "Todos los registros";
            this.chkTodosLosRegistros.UseVisualStyleBackColor = true;
            this.chkTodosLosRegistros.CheckedChanged += new System.EventHandler(this.chkTodosLosRegistros_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.btnRegresar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 608);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 80);
            this.panel3.TabIndex = 1;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnRegresar.BorderColor = System.Drawing.Color.Red;
            this.btnRegresar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnRegresar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRegresar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnRegresar.FocusRectangle = true;
            this.btnRegresar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Image = null;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegresar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnRegresar.ImageFocused = null;
            this.btnRegresar.ImageInactive = null;
            this.btnRegresar.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0006_regresr_a;
            this.btnRegresar.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0006_regresr;
            this.btnRegresar.ImagePressed = null;
            this.btnRegresar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnRegresar.KeyButton = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.btnRegresar.KeyButtonView = false;
            this.btnRegresar.Location = new System.Drawing.Point(916, 6);
            this.btnRegresar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnRegresar.MouseOverColor = System.Drawing.Color.Red;
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.OffsetPressedContent = true;
            this.btnRegresar.Size = new System.Drawing.Size(80, 70);
            this.btnRegresar.TabIndex = 6;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.TextDropShadow = true;
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbltitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 80);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(843, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // lbltitulo
            // 
            this.lbltitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.Color.White;
            this.lbltitulo.Location = new System.Drawing.Point(12, 9);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(798, 68);
            this.lbltitulo.TabIndex = 25;
            this.lbltitulo.Text = "Actividad Check List";
            this.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmNuevaActividadCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmNuevaActividadCheckList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNuevaActividadCheckList_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividadesCheckList)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbltitulo;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnRegresar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvActividadesCheckList;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarActividad;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnModificarActividad;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnQuitarActividad;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDActividadCheckList;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCategorioCheckList;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        private System.Windows.Forms.CheckBox chkTodosLosRegistros;
        private System.Windows.Forms.Label label3;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
    }
}

