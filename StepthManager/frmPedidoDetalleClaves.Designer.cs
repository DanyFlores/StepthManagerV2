namespace StephManager
{
    partial class frmPedidoDetalleClaves
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolioPedido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPedidoDetalle = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDAsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveProduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Metrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadMetrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MargenError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadUsos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadConsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasTranscurridos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AplicaMetrica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CumpleMetrica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NuevoPedido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label42 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoDetalle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 608);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 80);
            this.panel2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.panel2, "Guardar la información");
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
            this.panel3.Controls.Add(this.txtNombreProducto);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtFolioPedido);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dgvPedidoDetalle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 528);
            this.panel3.TabIndex = 2;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Enabled = false;
            this.txtNombreProducto.Location = new System.Drawing.Point(221, 60);
            this.txtNombreProducto.MaxLength = 1000;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(348, 25);
            this.txtNombreProducto.TabIndex = 117;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(67, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 118;
            this.label1.Text = "Producto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFolioPedido
            // 
            this.txtFolioPedido.Enabled = false;
            this.txtFolioPedido.Location = new System.Drawing.Point(221, 20);
            this.txtFolioPedido.MaxLength = 1000;
            this.txtFolioPedido.Name = "txtFolioPedido";
            this.txtFolioPedido.Size = new System.Drawing.Size(348, 25);
            this.txtFolioPedido.TabIndex = 115;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(67, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 116;
            this.label5.Text = "Folio del pedido";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvPedidoDetalle
            // 
            this.dgvPedidoDetalle.AllowUserToAddRows = false;
            this.dgvPedidoDetalle.AllowUserToDeleteRows = false;
            this.dgvPedidoDetalle.AllowUserToResizeRows = false;
            this.dgvPedidoDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidoDetalle.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPedidoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.FechaInicio,
            this.FechaFin,
            this.NombreEmpleado,
            this.IDAsignacion,
            this.ClaveProduccion,
            this.Metrica,
            this.CantidadMetrica,
            this.MargenError,
            this.CantidadUsos,
            this.CantidadConsumo,
            this.DiasTranscurridos,
            this.AplicaMetrica,
            this.CumpleMetrica,
            this.NuevoPedido});
            this.dgvPedidoDetalle.Location = new System.Drawing.Point(21, 107);
            this.dgvPedidoDetalle.Name = "dgvPedidoDetalle";
            this.dgvPedidoDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoDetalle.Size = new System.Drawing.Size(937, 382);
            this.dgvPedidoDetalle.TabIndex = 12;
            this.dgvPedidoDetalle.Sorted += new System.EventHandler(this.dgvPedidoDetalle_Sorted);
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "CantidadPedido";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = "0";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle15;
            this.Cantidad.FillWeight = 0.793147F;
            this.Cantidad.HeaderText = "Cantidad solicitada";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 85;
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaInicio";
            this.FechaInicio.HeaderText = "Fecha de Inicio";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ReadOnly = true;
            this.FechaInicio.Visible = false;
            // 
            // FechaFin
            // 
            this.FechaFin.DataPropertyName = "FechaFin";
            this.FechaFin.HeaderText = "Fecha de término";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Visible = false;
            // 
            // NombreEmpleado
            // 
            this.NombreEmpleado.DataPropertyName = "SucursalPersona";
            this.NombreEmpleado.FillWeight = 369.5432F;
            this.NombreEmpleado.HeaderText = "Empleado / Sucursal";
            this.NombreEmpleado.Name = "NombreEmpleado";
            this.NombreEmpleado.ReadOnly = true;
            this.NombreEmpleado.Width = 210;
            // 
            // IDAsignacion
            // 
            this.IDAsignacion.DataPropertyName = "IDAsignacion";
            this.IDAsignacion.HeaderText = "IDAsignacion";
            this.IDAsignacion.Name = "IDAsignacion";
            this.IDAsignacion.ReadOnly = true;
            this.IDAsignacion.Visible = false;
            // 
            // ClaveProduccion
            // 
            this.ClaveProduccion.DataPropertyName = "ClaveProduccion";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ClaveProduccion.DefaultCellStyle = dataGridViewCellStyle16;
            this.ClaveProduccion.HeaderText = "Clave de Producción";
            this.ClaveProduccion.Name = "ClaveProduccion";
            this.ClaveProduccion.ReadOnly = true;
            this.ClaveProduccion.Width = 95;
            // 
            // Metrica
            // 
            this.Metrica.DataPropertyName = "Metrica";
            this.Metrica.HeaderText = "Métrica";
            this.Metrica.Name = "Metrica";
            this.Metrica.ReadOnly = true;
            this.Metrica.Width = 180;
            // 
            // CantidadMetrica
            // 
            this.CantidadMetrica.DataPropertyName = "CantidadMetrica";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CantidadMetrica.DefaultCellStyle = dataGridViewCellStyle17;
            this.CantidadMetrica.HeaderText = "Cantidad estimada";
            this.CantidadMetrica.Name = "CantidadMetrica";
            this.CantidadMetrica.ReadOnly = true;
            this.CantidadMetrica.Width = 110;
            // 
            // MargenError
            // 
            this.MargenError.DataPropertyName = "MargenError";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MargenError.DefaultCellStyle = dataGridViewCellStyle18;
            this.MargenError.HeaderText = "Margen de Error";
            this.MargenError.Name = "MargenError";
            this.MargenError.ReadOnly = true;
            // 
            // CantidadUsos
            // 
            this.CantidadUsos.DataPropertyName = "CantidadUsos";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CantidadUsos.DefaultCellStyle = dataGridViewCellStyle19;
            this.CantidadUsos.HeaderText = "Usos";
            this.CantidadUsos.Name = "CantidadUsos";
            this.CantidadUsos.ReadOnly = true;
            this.CantidadUsos.Width = 85;
            // 
            // CantidadConsumo
            // 
            this.CantidadConsumo.DataPropertyName = "CantidadConsumo";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CantidadConsumo.DefaultCellStyle = dataGridViewCellStyle20;
            this.CantidadConsumo.HeaderText = "Consumo";
            this.CantidadConsumo.Name = "CantidadConsumo";
            this.CantidadConsumo.ReadOnly = true;
            this.CantidadConsumo.Width = 90;
            // 
            // DiasTranscurridos
            // 
            this.DiasTranscurridos.DataPropertyName = "DiasTranscurridos";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DiasTranscurridos.DefaultCellStyle = dataGridViewCellStyle21;
            this.DiasTranscurridos.HeaderText = "Días transcurridos";
            this.DiasTranscurridos.Name = "DiasTranscurridos";
            this.DiasTranscurridos.ReadOnly = true;
            this.DiasTranscurridos.Width = 110;
            // 
            // AplicaMetrica
            // 
            this.AplicaMetrica.DataPropertyName = "AplicaMetrica";
            this.AplicaMetrica.HeaderText = "AplicaMetrica";
            this.AplicaMetrica.Name = "AplicaMetrica";
            this.AplicaMetrica.ReadOnly = true;
            this.AplicaMetrica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AplicaMetrica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AplicaMetrica.Visible = false;
            // 
            // CumpleMetrica
            // 
            this.CumpleMetrica.DataPropertyName = "CumpleMetrica";
            this.CumpleMetrica.HeaderText = "¿Cumple Métrica?";
            this.CumpleMetrica.Name = "CumpleMetrica";
            this.CumpleMetrica.ReadOnly = true;
            this.CumpleMetrica.Visible = false;
            // 
            // NuevoPedido
            // 
            this.NuevoPedido.DataPropertyName = "NuevoPedido";
            this.NuevoPedido.HeaderText = "NuevoPedido";
            this.NuevoPedido.Name = "NuevoPedido";
            this.NuevoPedido.ReadOnly = true;
            this.NuevoPedido.Visible = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(652, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Detalle de claves del pedido";
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
            // frmPedidoDetalleClaves
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
            this.Name = "frmPedidoDetalleClaves";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPedidoDetalle_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoDetalle)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvPedidoDetalle;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFolioPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDAsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveProduccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Metrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadMetrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn MargenError;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadUsos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadConsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasTranscurridos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AplicaMetrica;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CumpleMetrica;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NuevoPedido;
    }
}

