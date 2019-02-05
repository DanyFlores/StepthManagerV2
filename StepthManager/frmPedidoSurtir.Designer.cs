namespace StephManager
{
    partial class frmPedidoSurtir
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMensajeError = new System.Windows.Forms.TextBox();
            this.btnSurtir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtEstatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolioPedido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPedidoDetalle = new System.Windows.Forms.DataGridView();
            this.IDPedidoDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDAsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveProduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadSurtida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadASurtir = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2.Controls.Add(this.txtMensajeError);
            this.panel2.Controls.Add(this.btnSurtir);
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
            this.txtMensajeError.Location = new System.Drawing.Point(21, 5);
            this.txtMensajeError.Multiline = true;
            this.txtMensajeError.Name = "txtMensajeError";
            this.txtMensajeError.ReadOnly = true;
            this.txtMensajeError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajeError.Size = new System.Drawing.Size(770, 69);
            this.txtMensajeError.TabIndex = 63;
            this.txtMensajeError.Text = "Ocurrió un Error";
            this.txtMensajeError.Visible = false;
            // 
            // btnSurtir
            // 
            this.btnSurtir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSurtir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSurtir.BorderColor = System.Drawing.Color.Red;
            this.btnSurtir.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSurtir.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSurtir.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnSurtir.FocusRectangle = true;
            this.btnSurtir.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSurtir.ForeColor = System.Drawing.Color.White;
            this.btnSurtir.Image = null;
            this.btnSurtir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSurtir.ImageBorderColor = System.Drawing.Color.Red;
            this.btnSurtir.ImageFocused = null;
            this.btnSurtir.ImageInactive = null;
            this.btnSurtir.ImageMouseOver = global::StephManager.Properties.Resources.icons_steph_vino_pedido_surtir_n;
            this.btnSurtir.ImageNormal = global::StephManager.Properties.Resources.icons_steph_vino_pedido_surtir;
            this.btnSurtir.ImagePressed = null;
            this.btnSurtir.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSurtir.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSurtir.KeyButtonView = false;
            this.btnSurtir.Location = new System.Drawing.Point(827, 6);
            this.btnSurtir.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSurtir.MouseOverColor = System.Drawing.Color.Red;
            this.btnSurtir.Name = "btnSurtir";
            this.btnSurtir.OffsetPressedContent = true;
            this.btnSurtir.Size = new System.Drawing.Size(80, 70);
            this.btnSurtir.TabIndex = 36;
            this.btnSurtir.Text = "Surtir";
            this.btnSurtir.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnSurtir, "Surtir el pedido");
            this.btnSurtir.UseVisualStyleBackColor = false;
            this.btnSurtir.Click += new System.EventHandler(this.btnSurtir_Click);
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
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextDropShadow = true;
            this.toolTip1.SetToolTip(this.btnCancelar, "Regresar a Pedidos");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.txtEstatus);
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
            // txtEstatus
            // 
            this.txtEstatus.Enabled = false;
            this.txtEstatus.Location = new System.Drawing.Point(161, 58);
            this.txtEstatus.MaxLength = 1000;
            this.txtEstatus.Name = "txtEstatus";
            this.txtEstatus.Size = new System.Drawing.Size(219, 25);
            this.txtEstatus.TabIndex = 117;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(67, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 118;
            this.label1.Text = "Estatus";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFolioPedido
            // 
            this.txtFolioPedido.Enabled = false;
            this.txtFolioPedido.Location = new System.Drawing.Point(161, 18);
            this.txtFolioPedido.MaxLength = 1000;
            this.txtFolioPedido.Name = "txtFolioPedido";
            this.txtFolioPedido.Size = new System.Drawing.Size(348, 25);
            this.txtFolioPedido.TabIndex = 115;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(67, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 116;
            this.label5.Text = "Folio";
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
            this.IDPedidoDetalle,
            this.IDAsignacion,
            this.IDProducto,
            this.Clave,
            this.Producto,
            this.ClaveProduccion,
            this.IDEmpleado,
            this.NombreEmpleado,
            this.Cantidad,
            this.CantidadSurtida,
            this.CantidadPendiente,
            this.CantidadASurtir});
            this.dgvPedidoDetalle.Location = new System.Drawing.Point(40, 107);
            this.dgvPedidoDetalle.Name = "dgvPedidoDetalle";
            this.dgvPedidoDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoDetalle.Size = new System.Drawing.Size(929, 415);
            this.dgvPedidoDetalle.TabIndex = 12;
            this.dgvPedidoDetalle.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidoDetalle_CellValidated);
            this.dgvPedidoDetalle.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPedidoDetalle_CellValidating);
            // 
            // IDPedidoDetalle
            // 
            this.IDPedidoDetalle.DataPropertyName = "IDPedidoDetalle";
            this.IDPedidoDetalle.HeaderText = "IDPedidoDetalle";
            this.IDPedidoDetalle.Name = "IDPedidoDetalle";
            this.IDPedidoDetalle.ReadOnly = true;
            this.IDPedidoDetalle.Visible = false;
            // 
            // IDAsignacion
            // 
            this.IDAsignacion.DataPropertyName = "IDAsignacion";
            this.IDAsignacion.HeaderText = "IDAsignacion";
            this.IDAsignacion.Name = "IDAsignacion";
            this.IDAsignacion.ReadOnly = true;
            this.IDAsignacion.Visible = false;
            // 
            // IDProducto
            // 
            this.IDProducto.DataPropertyName = "IDProducto";
            this.IDProducto.HeaderText = "IDProducto";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.ReadOnly = true;
            this.IDProducto.Visible = false;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "ClaveProducto";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Width = 130;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "NombreProducto";
            this.Producto.FillWeight = 28.87055F;
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 210;
            // 
            // ClaveProduccion
            // 
            this.ClaveProduccion.DataPropertyName = "ClaveProduccion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ClaveProduccion.DefaultCellStyle = dataGridViewCellStyle1;
            this.ClaveProduccion.HeaderText = "Clave de Producción";
            this.ClaveProduccion.Name = "ClaveProduccion";
            this.ClaveProduccion.ReadOnly = true;
            this.ClaveProduccion.Width = 110;
            // 
            // IDEmpleado
            // 
            this.IDEmpleado.DataPropertyName = "IDEmpleado";
            this.IDEmpleado.FillWeight = 0.793147F;
            this.IDEmpleado.HeaderText = "IDEmpleado";
            this.IDEmpleado.Name = "IDEmpleado";
            this.IDEmpleado.ReadOnly = true;
            this.IDEmpleado.Visible = false;
            this.IDEmpleado.Width = 5;
            // 
            // NombreEmpleado
            // 
            this.NombreEmpleado.DataPropertyName = "NombreEmpleado";
            this.NombreEmpleado.FillWeight = 369.5432F;
            this.NombreEmpleado.HeaderText = "Empleado";
            this.NombreEmpleado.Name = "NombreEmpleado";
            this.NombreEmpleado.ReadOnly = true;
            this.NombreEmpleado.Width = 300;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cantidad.FillWeight = 0.793147F;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 120;
            // 
            // CantidadSurtida
            // 
            this.CantidadSurtida.DataPropertyName = "CantidadSurtida";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.CantidadSurtida.DefaultCellStyle = dataGridViewCellStyle3;
            this.CantidadSurtida.HeaderText = "Cantidad Surtida";
            this.CantidadSurtida.Name = "CantidadSurtida";
            this.CantidadSurtida.ReadOnly = true;
            this.CantidadSurtida.Width = 120;
            // 
            // CantidadPendiente
            // 
            this.CantidadPendiente.DataPropertyName = "CantidadPendiente";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.CantidadPendiente.DefaultCellStyle = dataGridViewCellStyle4;
            this.CantidadPendiente.HeaderText = "Cantidad Pendiente";
            this.CantidadPendiente.Name = "CantidadPendiente";
            this.CantidadPendiente.ReadOnly = true;
            this.CantidadPendiente.Width = 120;
            // 
            // CantidadASurtir
            // 
            this.CantidadASurtir.DataPropertyName = "CantidadASurtir";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.CantidadASurtir.DefaultCellStyle = dataGridViewCellStyle5;
            this.CantidadASurtir.HeaderText = "Cantidad a surtir";
            this.CantidadASurtir.Name = "CantidadASurtir";
            this.CantidadASurtir.Width = 120;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(309, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Surtir pedido";
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
            this.pictureBox1.Location = new System.Drawing.Point(827, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // frmPedidoSurtir
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
            this.Name = "frmPedidoSurtir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph V.10";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPedidoSurtir_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.TextBox txtEstatus;
        private System.Windows.Forms.Label label1;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSurtir;
        private System.Windows.Forms.TextBox txtMensajeError;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPedidoDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDAsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveProduccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadSurtida;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadASurtir;
    }
}

