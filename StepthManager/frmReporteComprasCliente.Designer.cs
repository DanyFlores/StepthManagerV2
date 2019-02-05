namespace StephManager
{
    partial class frmReporteComprasCliente
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dgvReporteComprasCliente = new System.Windows.Forms.DataGridView();
            this.IDReporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnImpresion = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnNuevo = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtpFechaBusqueda = new System.Windows.Forms.DateTimePicker();
            this.btnCancelarBusq = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.button_Creativa1 = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancBusqueda = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.dtpFechaBuscar = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteComprasCliente)).BeginInit();
            this.panel7.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
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
            this.panel5.Location = new System.Drawing.Point(0, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 558);
            this.panel5.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 478);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.Controls.Add(this.dgvReporteComprasCliente);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1008, 478);
            this.panel12.TabIndex = 2;
            // 
            // dgvReporteComprasCliente
            // 
            this.dgvReporteComprasCliente.AllowUserToAddRows = false;
            this.dgvReporteComprasCliente.AllowUserToDeleteRows = false;
            this.dgvReporteComprasCliente.AllowUserToResizeRows = false;
            this.dgvReporteComprasCliente.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvReporteComprasCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteComprasCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDReporte,
            this.FechaInicio,
            this.FechaFin,
            this.IDCliente,
            this.Nombre});
            this.dgvReporteComprasCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReporteComprasCliente.Location = new System.Drawing.Point(0, 0);
            this.dgvReporteComprasCliente.MultiSelect = false;
            this.dgvReporteComprasCliente.Name = "dgvReporteComprasCliente";
            this.dgvReporteComprasCliente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvReporteComprasCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporteComprasCliente.Size = new System.Drawing.Size(1008, 478);
            this.dgvReporteComprasCliente.TabIndex = 1;
            // 
            // IDReporte
            // 
            this.IDReporte.DataPropertyName = "IDReporte";
            this.IDReporte.HeaderText = "IDReporte";
            this.IDReporte.Name = "IDReporte";
            this.IDReporte.ReadOnly = true;
            this.IDReporte.Visible = false;
            this.IDReporte.Width = 120;
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaInicio";
            this.FechaInicio.HeaderText = "Fecha de Inicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Width = 200;
            // 
            // FechaFin
            // 
            this.FechaFin.DataPropertyName = "FechaFin";
            this.FechaFin.HeaderText = "Fecha de término";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Width = 200;
            // 
            // IDCliente
            // 
            this.IDCliente.DataPropertyName = "IDCliente";
            this.IDCliente.HeaderText = "Cliente";
            this.IDCliente.Name = "IDCliente";
            this.IDCliente.ReadOnly = true;
            this.IDCliente.Visible = false;
            this.IDCliente.Width = 300;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre Cliente";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 300;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PanelMenu);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 478);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 80);
            this.panel7.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.Gray;
            this.PanelMenu.Controls.Add(this.btnImpresion);
            this.PanelMenu.Controls.Add(this.btnSalir);
            this.PanelMenu.Controls.Add(this.btnNuevo);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1008, 80);
            this.PanelMenu.TabIndex = 1;
            // 
            // btnImpresion
            // 
            this.btnImpresion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnImpresion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnImpresion.BorderColor = System.Drawing.Color.Red;
            this.btnImpresion.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnImpresion.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnImpresion.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnImpresion.FocusRectangle = true;
            this.btnImpresion.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImpresion.ForeColor = System.Drawing.Color.White;
            this.btnImpresion.Image = null;
            this.btnImpresion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImpresion.ImageBorderColor = System.Drawing.Color.Red;
            this.btnImpresion.ImageFocused = null;
            this.btnImpresion.ImageInactive = null;
            this.btnImpresion.ImageMouseOver = null;
            this.btnImpresion.ImageNormal = null;
            this.btnImpresion.ImagePressed = null;
            this.btnImpresion.ImageSize = new System.Drawing.Size(44, 44);
            this.btnImpresion.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnImpresion.KeyButtonView = false;
            this.btnImpresion.Location = new System.Drawing.Point(833, 5);
            this.btnImpresion.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnImpresion.MouseOverColor = System.Drawing.Color.Red;
            this.btnImpresion.Name = "btnImpresion";
            this.btnImpresion.OffsetPressedContent = true;
            this.btnImpresion.Size = new System.Drawing.Size(80, 70);
            this.btnImpresion.TabIndex = 21;
            this.btnImpresion.Text = "Imprimir";
            this.btnImpresion.TextDropShadow = true;
            this.btnImpresion.UseVisualStyleBackColor = false;
            this.btnImpresion.Click += new System.EventHandler(this.btnImpresion_Click);
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
            this.btnSalir.ImageMouseOver = null;
            this.btnSalir.ImageNormal = null;
            this.btnSalir.ImagePressed = null;
            this.btnSalir.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSalir.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSalir.KeyButtonView = false;
            this.btnSalir.Location = new System.Drawing.Point(919, 5);
            this.btnSalir.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSalir.MouseOverColor = System.Drawing.Color.Red;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.OffsetPressedContent = true;
            this.btnSalir.Size = new System.Drawing.Size(80, 70);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextDropShadow = true;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnNuevo.BorderColor = System.Drawing.Color.Red;
            this.btnNuevo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnNuevo.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNuevo.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnNuevo.FocusRectangle = true;
            this.btnNuevo.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = null;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.ImageBorderColor = System.Drawing.Color.Red;
            this.btnNuevo.ImageFocused = null;
            this.btnNuevo.ImageInactive = null;
            this.btnNuevo.ImageMouseOver = null;
            this.btnNuevo.ImageNormal = null;
            this.btnNuevo.ImagePressed = null;
            this.btnNuevo.ImageSize = new System.Drawing.Size(44, 44);
            this.btnNuevo.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnNuevo.KeyButtonView = false;
            this.btnNuevo.Location = new System.Drawing.Point(747, 5);
            this.btnNuevo.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNuevo.MouseOverColor = System.Drawing.Color.Red;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.OffsetPressedContent = true;
            this.btnNuevo.Size = new System.Drawing.Size(80, 70);
            this.btnNuevo.TabIndex = 17;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextDropShadow = true;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 50);
            this.panel4.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DarkGray;
            this.panel10.Controls.Add(this.panel9);
            this.panel10.Controls.Add(this.btnCancBusqueda);
            this.panel10.Controls.Add(this.btnBuscar);
            this.panel10.Controls.Add(this.dtpFechaBuscar);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1008, 50);
            this.panel10.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DarkGray;
            this.panel9.Controls.Add(this.dtpFechaBusqueda);
            this.panel9.Controls.Add(this.btnCancelarBusq);
            this.panel9.Controls.Add(this.button_Creativa1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1008, 50);
            this.panel9.TabIndex = 118;
            // 
            // dtpFechaBusqueda
            // 
            this.dtpFechaBusqueda.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFechaBusqueda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaBusqueda.Location = new System.Drawing.Point(577, 12);
            this.dtpFechaBusqueda.Name = "dtpFechaBusqueda";
            this.dtpFechaBusqueda.Size = new System.Drawing.Size(165, 25);
            this.dtpFechaBusqueda.TabIndex = 68;
            // 
            // btnCancelarBusq
            // 
            this.btnCancelarBusq.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelarBusq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancelarBusq.BorderColor = System.Drawing.Color.Red;
            this.btnCancelarBusq.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancelarBusq.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarBusq.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnCancelarBusq.FocusRectangle = true;
            this.btnCancelarBusq.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarBusq.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarBusq.Image = null;
            this.btnCancelarBusq.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelarBusq.ImageBorderColor = System.Drawing.Color.Red;
            this.btnCancelarBusq.ImageFocused = null;
            this.btnCancelarBusq.ImageInactive = null;
            this.btnCancelarBusq.ImageMouseOver = null;
            this.btnCancelarBusq.ImageNormal = null;
            this.btnCancelarBusq.ImagePressed = null;
            this.btnCancelarBusq.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancelarBusq.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelarBusq.KeyButtonView = false;
            this.btnCancelarBusq.Location = new System.Drawing.Point(852, 12);
            this.btnCancelarBusq.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelarBusq.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelarBusq.Name = "btnCancelarBusq";
            this.btnCancelarBusq.OffsetPressedContent = true;
            this.btnCancelarBusq.Size = new System.Drawing.Size(23, 25);
            this.btnCancelarBusq.TabIndex = 67;
            this.btnCancelarBusq.Text = "X";
            this.btnCancelarBusq.TextDropShadow = true;
            this.btnCancelarBusq.UseVisualStyleBackColor = false;
            this.btnCancelarBusq.Click += new System.EventHandler(this.btnCancelarBusq_Click);
            // 
            // button_Creativa1
            // 
            this.button_Creativa1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Creativa1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.button_Creativa1.BorderColor = System.Drawing.Color.Red;
            this.button_Creativa1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.button_Creativa1.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_Creativa1.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.button_Creativa1.FocusRectangle = true;
            this.button_Creativa1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Creativa1.ForeColor = System.Drawing.Color.Black;
            this.button_Creativa1.Image = null;
            this.button_Creativa1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Creativa1.ImageBorderColor = System.Drawing.Color.Red;
            this.button_Creativa1.ImageFocused = null;
            this.button_Creativa1.ImageInactive = null;
            this.button_Creativa1.ImageMouseOver = null;
            this.button_Creativa1.ImageNormal = null;
            this.button_Creativa1.ImagePressed = null;
            this.button_Creativa1.ImageSize = new System.Drawing.Size(44, 44);
            this.button_Creativa1.KeyButton = System.Windows.Forms.Keys.F1;
            this.button_Creativa1.KeyButtonView = false;
            this.button_Creativa1.Location = new System.Drawing.Point(748, 12);
            this.button_Creativa1.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.button_Creativa1.MouseOverColor = System.Drawing.Color.Red;
            this.button_Creativa1.Name = "button_Creativa1";
            this.button_Creativa1.OffsetPressedContent = true;
            this.button_Creativa1.Size = new System.Drawing.Size(100, 25);
            this.button_Creativa1.TabIndex = 66;
            this.button_Creativa1.Text = "Buscar";
            this.button_Creativa1.TextDropShadow = true;
            this.button_Creativa1.UseVisualStyleBackColor = false;
            this.button_Creativa1.Click += new System.EventHandler(this.button_Creativa1_Click);
            // 
            // btnCancBusqueda
            // 
            this.btnCancBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancBusqueda.BorderColor = System.Drawing.Color.Red;
            this.btnCancBusqueda.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCancBusqueda.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancBusqueda.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnCancBusqueda.FocusRectangle = true;
            this.btnCancBusqueda.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancBusqueda.ForeColor = System.Drawing.Color.Black;
            this.btnCancBusqueda.Image = null;
            this.btnCancBusqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancBusqueda.ImageBorderColor = System.Drawing.Color.Red;
            this.btnCancBusqueda.ImageFocused = null;
            this.btnCancBusqueda.ImageInactive = null;
            this.btnCancBusqueda.ImageMouseOver = null;
            this.btnCancBusqueda.ImageNormal = null;
            this.btnCancBusqueda.ImagePressed = null;
            this.btnCancBusqueda.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancBusqueda.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancBusqueda.KeyButtonView = false;
            this.btnCancBusqueda.Location = new System.Drawing.Point(658, 15);
            this.btnCancBusqueda.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancBusqueda.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancBusqueda.Name = "btnCancBusqueda";
            this.btnCancBusqueda.OffsetPressedContent = true;
            this.btnCancBusqueda.Size = new System.Drawing.Size(25, 25);
            this.btnCancBusqueda.TabIndex = 117;
            this.btnCancBusqueda.Text = "X";
            this.btnCancBusqueda.TextDropShadow = true;
            this.btnCancBusqueda.UseVisualStyleBackColor = false;
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
            this.btnBuscar.Location = new System.Drawing.Point(559, 15);
            this.btnBuscar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBuscar.MouseOverColor = System.Drawing.Color.Red;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OffsetPressedContent = true;
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 116;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextDropShadow = true;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dtpFechaBuscar
            // 
            this.dtpFechaBuscar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaBuscar.Location = new System.Drawing.Point(323, 15);
            this.dtpFechaBuscar.Name = "dtpFechaBuscar";
            this.dtpFechaBuscar.Size = new System.Drawing.Size(230, 25);
            this.dtpFechaBuscar.TabIndex = 113;
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
            this.pictureBox1.Location = new System.Drawing.Point(849, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(411, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Visita de Clientes";
            this.label42.UseWaitCursor = true;
            // 
            // frmReporteComprasCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmReporteComprasCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteComprasCliente)).EndInit();
            this.panel7.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
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
        private CreativaSL.LibControls.WinForms.Button_Creativa btnNuevo;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnImpresion;
        private System.Windows.Forms.DateTimePicker dtpFechaBuscar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancBusqueda;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgvReporteComprasCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DateTimePicker dtpFechaBusqueda;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelarBusq;
        private CreativaSL.LibControls.WinForms.Button_Creativa button_Creativa1;
    }
}

