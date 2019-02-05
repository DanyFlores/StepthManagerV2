namespace StephManager
{
    partial class frmMaterialesCapacitacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemplazar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAgregarMaterial = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvPedidoDetalle = new System.Windows.Forms.DataGridView();
            this.IDAsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveProduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Metrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadMetrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MargenError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadUsos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CumpleMetrica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnCancelarBusq = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label42 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoDetalle)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.btnRemplazar);
            this.panel2.Controls.Add(this.btnAgregarMaterial);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 608);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 80);
            this.panel2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.panel2, "Guardar la información");
            // 
            // btnRemplazar
            // 
            this.btnRemplazar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemplazar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnRemplazar.BorderColor = System.Drawing.Color.Red;
            this.btnRemplazar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnRemplazar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemplazar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnRemplazar.FocusRectangle = true;
            this.btnRemplazar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemplazar.ForeColor = System.Drawing.Color.White;
            this.btnRemplazar.Image = null;
            this.btnRemplazar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemplazar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnRemplazar.ImageFocused = null;
            this.btnRemplazar.ImageInactive = null;
            this.btnRemplazar.ImageMouseOver = null;
            this.btnRemplazar.ImageNormal = null;
            this.btnRemplazar.ImagePressed = null;
            this.btnRemplazar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnRemplazar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnRemplazar.KeyButtonView = false;
            this.btnRemplazar.Location = new System.Drawing.Point(741, 6);
            this.btnRemplazar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnRemplazar.MouseOverColor = System.Drawing.Color.Red;
            this.btnRemplazar.Name = "btnRemplazar";
            this.btnRemplazar.OffsetPressedContent = true;
            this.btnRemplazar.Size = new System.Drawing.Size(80, 70);
            this.btnRemplazar.TabIndex = 37;
            this.btnRemplazar.Text = "Reemplazo";
            this.btnRemplazar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnRemplazar, "Remplazar material a capacitacion");
            this.btnRemplazar.UseVisualStyleBackColor = false;
            this.btnRemplazar.Click += new System.EventHandler(this.btnRemplazar_Click);
            // 
            // btnAgregarMaterial
            // 
            this.btnAgregarMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarMaterial.BorderColor = System.Drawing.Color.Red;
            this.btnAgregarMaterial.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAgregarMaterial.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAgregarMaterial.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAgregarMaterial.FocusRectangle = true;
            this.btnAgregarMaterial.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMaterial.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMaterial.Image = null;
            this.btnAgregarMaterial.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarMaterial.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAgregarMaterial.ImageFocused = null;
            this.btnAgregarMaterial.ImageInactive = null;
            this.btnAgregarMaterial.ImageMouseOver = null;
            this.btnAgregarMaterial.ImageNormal = null;
            this.btnAgregarMaterial.ImagePressed = null;
            this.btnAgregarMaterial.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAgregarMaterial.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAgregarMaterial.KeyButtonView = false;
            this.btnAgregarMaterial.Location = new System.Drawing.Point(827, 6);
            this.btnAgregarMaterial.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAgregarMaterial.MouseOverColor = System.Drawing.Color.Red;
            this.btnAgregarMaterial.Name = "btnAgregarMaterial";
            this.btnAgregarMaterial.OffsetPressedContent = true;
            this.btnAgregarMaterial.Size = new System.Drawing.Size(80, 70);
            this.btnAgregarMaterial.TabIndex = 36;
            this.btnAgregarMaterial.Text = "Nuevo";
            this.btnAgregarMaterial.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnAgregarMaterial, "Agregar material a capacitacion");
            this.btnAgregarMaterial.UseVisualStyleBackColor = false;
            this.btnAgregarMaterial.Click += new System.EventHandler(this.btnAgregarMaterial_Click);
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
            this.btnCancelar.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0001s_0000_salir_a;
            this.btnCancelar.ImageNormal = global::StephManager.Properties.Resources._0000s_0001s_0000_salir;
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
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar y Regresar al Menú");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
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
            this.panel5.Controls.Add(this.dgvPedidoDetalle);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 478);
            this.panel5.TabIndex = 14;
            // 
            // dgvPedidoDetalle
            // 
            this.dgvPedidoDetalle.AllowUserToAddRows = false;
            this.dgvPedidoDetalle.AllowUserToDeleteRows = false;
            this.dgvPedidoDetalle.AllowUserToResizeRows = false;
            this.dgvPedidoDetalle.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPedidoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDAsignacion,
            this.Clave,
            this.Producto,
            this.ClaveProduccion,
            this.Metrica,
            this.FechaInicio,
            this.CantidadMetrica,
            this.MargenError,
            this.CantidadUsos,
            this.CumpleMetrica});
            this.dgvPedidoDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidoDetalle.Location = new System.Drawing.Point(0, 0);
            this.dgvPedidoDetalle.Name = "dgvPedidoDetalle";
            this.dgvPedidoDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoDetalle.Size = new System.Drawing.Size(1008, 478);
            this.dgvPedidoDetalle.TabIndex = 13;
            // 
            // IDAsignacion
            // 
            this.IDAsignacion.DataPropertyName = "IDAsignacion";
            this.IDAsignacion.HeaderText = "IDAsignacion";
            this.IDAsignacion.Name = "IDAsignacion";
            this.IDAsignacion.ReadOnly = true;
            this.IDAsignacion.Visible = false;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "ClaveProducto";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Width = 110;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "NombreProducto";
            this.Producto.FillWeight = 28.87055F;
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 250;
            // 
            // ClaveProduccion
            // 
            this.ClaveProduccion.DataPropertyName = "ClaveProduccion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ClaveProduccion.DefaultCellStyle = dataGridViewCellStyle1;
            this.ClaveProduccion.HeaderText = "Clave de producción";
            this.ClaveProduccion.Name = "ClaveProduccion";
            this.ClaveProduccion.ReadOnly = true;
            this.ClaveProduccion.Width = 115;
            // 
            // Metrica
            // 
            this.Metrica.DataPropertyName = "Metrica";
            this.Metrica.HeaderText = "Métrica";
            this.Metrica.Name = "Metrica";
            this.Metrica.ReadOnly = true;
            this.Metrica.Width = 180;
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaEntrega";
            this.FechaInicio.HeaderText = "Fecha de Inicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Visible = false;
            // 
            // CantidadMetrica
            // 
            this.CantidadMetrica.DataPropertyName = "CantMetrica";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CantidadMetrica.DefaultCellStyle = dataGridViewCellStyle2;
            this.CantidadMetrica.HeaderText = "Cantidad de métrica";
            this.CantidadMetrica.Name = "CantidadMetrica";
            this.CantidadMetrica.ReadOnly = true;
            this.CantidadMetrica.Width = 125;
            // 
            // MargenError
            // 
            this.MargenError.DataPropertyName = "MargenError";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MargenError.DefaultCellStyle = dataGridViewCellStyle3;
            this.MargenError.HeaderText = "Margen de error";
            this.MargenError.Name = "MargenError";
            this.MargenError.ReadOnly = true;
            this.MargenError.Width = 125;
            // 
            // CantidadUsos
            // 
            this.CantidadUsos.DataPropertyName = "UsosConsumoDias";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CantidadUsos.DefaultCellStyle = dataGridViewCellStyle4;
            this.CantidadUsos.HeaderText = "Usos / Consumo / Días";
            this.CantidadUsos.Name = "CantidadUsos";
            this.CantidadUsos.ReadOnly = true;
            this.CantidadUsos.Width = 180;
            // 
            // CumpleMetrica
            // 
            this.CumpleMetrica.DataPropertyName = "CumpleMetrica";
            this.CumpleMetrica.HeaderText = "¿Cumple Métrica?";
            this.CumpleMetrica.Name = "CumpleMetrica";
            this.CumpleMetrica.ReadOnly = true;
            this.CumpleMetrica.Visible = false;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 50);
            this.panel4.TabIndex = 13;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DarkGray;
            this.panel10.Controls.Add(this.btnCancelarBusq);
            this.panel10.Controls.Add(this.chkTodos);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.btnBuscar);
            this.panel10.Controls.Add(this.txtBusqueda);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1008, 50);
            this.panel10.TabIndex = 2;
            // 
            // btnCancelarBusq
            // 
            this.btnCancelarBusq.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnCancelarBusq.Location = new System.Drawing.Point(724, 15);
            this.btnCancelarBusq.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelarBusq.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelarBusq.Name = "btnCancelarBusq";
            this.btnCancelarBusq.OffsetPressedContent = true;
            this.btnCancelarBusq.Size = new System.Drawing.Size(23, 25);
            this.btnCancelarBusq.TabIndex = 62;
            this.btnCancelarBusq.Text = "X";
            this.btnCancelarBusq.TextDropShadow = true;
            this.btnCancelarBusq.UseVisualStyleBackColor = false;
            this.btnCancelarBusq.Click += new System.EventHandler(this.btnCancelarBusq_Click);
            // 
            // chkTodos
            // 
            this.chkTodos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(798, 16);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(92, 24);
            this.chkTodos.TabIndex = 61;
            this.chkTodos.Text = "Ver todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(109, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 37);
            this.label1.TabIndex = 58;
            this.label1.Text = "Producto";
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
            this.btnBuscar.Location = new System.Drawing.Point(625, 15);
            this.btnBuscar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBuscar.MouseOverColor = System.Drawing.Color.Red;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OffsetPressedContent = true;
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 56;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextDropShadow = true;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBusqueda.Location = new System.Drawing.Point(269, 15);
            this.txtBusqueda.MaxLength = 170;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(350, 25);
            this.txtBusqueda.TabIndex = 13;
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(618, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Materiales de capacitación";
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
            this.pictureBox1.Location = new System.Drawing.Point(851, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // frmMaterialesCapacitacion
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
            this.Name = "frmMaterialesCapacitacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMaterialesCapacitacion_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoDetalle)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvPedidoDetalle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label1;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDAsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveProduccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Metrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadMetrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn MargenError;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadUsos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CumpleMetrica;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelarBusq;
        private System.Windows.Forms.CheckBox chkTodos;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnRemplazar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAgregarMaterial;
    }
}

