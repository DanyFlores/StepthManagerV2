namespace StephManager
{
    partial class frmPedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPendientes = new System.Windows.Forms.TabPage();
            this.dgvPedidosPendientes = new System.Windows.Forms.DataGridView();
            this.IDPedido0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDEstatusPedido0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstatusPedido0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surtido0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FechaPedido0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpConcluidos = new System.Windows.Forms.TabPage();
            this.dgvPedidosConcluidos = new System.Windows.Forms.DataGridView();
            this.IDPedido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDEstatusPedido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstatusPedido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surtido1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FechaPedido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnFinalizarPedido = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnDetallePedido = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSurtir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkTodosLosRegistros = new System.Windows.Forms.CheckBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelarBusq = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosPendientes)).BeginInit();
            this.tpConcluidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosConcluidos)).BeginInit();
            this.panel7.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel5.Location = new System.Drawing.Point(0, 70);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 538);
            this.panel5.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 458);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.Controls.Add(this.tabControl1);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1008, 458);
            this.panel12.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPendientes);
            this.tabControl1.Controls.Add(this.tpConcluidos);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 458);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tbPendientes
            // 
            this.tbPendientes.Controls.Add(this.dgvPedidosPendientes);
            this.tbPendientes.Location = new System.Drawing.Point(4, 29);
            this.tbPendientes.Name = "tbPendientes";
            this.tbPendientes.Size = new System.Drawing.Size(1000, 425);
            this.tbPendientes.TabIndex = 0;
            this.tbPendientes.Text = "Pedidos Pendientes";
            this.tbPendientes.UseVisualStyleBackColor = true;
            // 
            // dgvPedidosPendientes
            // 
            this.dgvPedidosPendientes.AllowUserToAddRows = false;
            this.dgvPedidosPendientes.AllowUserToDeleteRows = false;
            this.dgvPedidosPendientes.AllowUserToResizeRows = false;
            this.dgvPedidosPendientes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPedidosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPedido0,
            this.IDEstatusPedido0,
            this.Folio0,
            this.EstatusPedido0,
            this.Sucursal0,
            this.Surtido0,
            this.FechaPedido0,
            this.Empleado0});
            this.dgvPedidosPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidosPendientes.Location = new System.Drawing.Point(0, 0);
            this.dgvPedidosPendientes.Name = "dgvPedidosPendientes";
            this.dgvPedidosPendientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPedidosPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosPendientes.Size = new System.Drawing.Size(1000, 425);
            this.dgvPedidosPendientes.TabIndex = 14;
            // 
            // IDPedido0
            // 
            this.IDPedido0.DataPropertyName = "IDPedido";
            this.IDPedido0.HeaderText = "IDPedido";
            this.IDPedido0.Name = "IDPedido0";
            this.IDPedido0.ReadOnly = true;
            this.IDPedido0.Visible = false;
            // 
            // IDEstatusPedido0
            // 
            this.IDEstatusPedido0.DataPropertyName = "IDEstatusPedido";
            this.IDEstatusPedido0.HeaderText = "IDEstatusPedido";
            this.IDEstatusPedido0.Name = "IDEstatusPedido0";
            this.IDEstatusPedido0.ReadOnly = true;
            this.IDEstatusPedido0.Visible = false;
            // 
            // Folio0
            // 
            this.Folio0.DataPropertyName = "Folio";
            this.Folio0.HeaderText = "Folio";
            this.Folio0.Name = "Folio0";
            this.Folio0.ReadOnly = true;
            this.Folio0.Width = 150;
            // 
            // EstatusPedido0
            // 
            this.EstatusPedido0.DataPropertyName = "EstatusPedido";
            this.EstatusPedido0.HeaderText = "Estatus";
            this.EstatusPedido0.Name = "EstatusPedido0";
            this.EstatusPedido0.ReadOnly = true;
            this.EstatusPedido0.Width = 180;
            // 
            // Sucursal0
            // 
            this.Sucursal0.DataPropertyName = "NombreSucursal";
            this.Sucursal0.HeaderText = "Sucursal";
            this.Sucursal0.Name = "Sucursal0";
            this.Sucursal0.ReadOnly = true;
            this.Sucursal0.Width = 250;
            // 
            // Surtido0
            // 
            this.Surtido0.DataPropertyName = "Completo";
            this.Surtido0.HeaderText = "Surtido";
            this.Surtido0.Name = "Surtido0";
            this.Surtido0.ReadOnly = true;
            this.Surtido0.Width = 120;
            // 
            // FechaPedido0
            // 
            this.FechaPedido0.DataPropertyName = "FechaPedido";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FechaPedido0.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaPedido0.HeaderText = "Fecha de Pedido";
            this.FechaPedido0.Name = "FechaPedido0";
            this.FechaPedido0.ReadOnly = true;
            this.FechaPedido0.Width = 160;
            // 
            // Empleado0
            // 
            this.Empleado0.DataPropertyName = "EmpleadoCaptura";
            this.Empleado0.HeaderText = "Empleado que capturó";
            this.Empleado0.Name = "Empleado0";
            this.Empleado0.ReadOnly = true;
            this.Empleado0.Width = 280;
            // 
            // tpConcluidos
            // 
            this.tpConcluidos.Controls.Add(this.dgvPedidosConcluidos);
            this.tpConcluidos.Location = new System.Drawing.Point(4, 29);
            this.tpConcluidos.Name = "tpConcluidos";
            this.tpConcluidos.Size = new System.Drawing.Size(1000, 425);
            this.tpConcluidos.TabIndex = 1;
            this.tpConcluidos.Text = "Pedidos Concluidos";
            this.tpConcluidos.UseVisualStyleBackColor = true;
            // 
            // dgvPedidosConcluidos
            // 
            this.dgvPedidosConcluidos.AllowUserToAddRows = false;
            this.dgvPedidosConcluidos.AllowUserToDeleteRows = false;
            this.dgvPedidosConcluidos.AllowUserToResizeRows = false;
            this.dgvPedidosConcluidos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPedidosConcluidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosConcluidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPedido1,
            this.IDEstatusPedido1,
            this.Folio1,
            this.EstatusPedido1,
            this.Sucursal1,
            this.Surtido1,
            this.FechaPedido1,
            this.Empleado1});
            this.dgvPedidosConcluidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidosConcluidos.Location = new System.Drawing.Point(0, 0);
            this.dgvPedidosConcluidos.Name = "dgvPedidosConcluidos";
            this.dgvPedidosConcluidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPedidosConcluidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosConcluidos.Size = new System.Drawing.Size(1000, 425);
            this.dgvPedidosConcluidos.TabIndex = 14;
            // 
            // IDPedido1
            // 
            this.IDPedido1.DataPropertyName = "IDPedido";
            this.IDPedido1.HeaderText = "IDPedido";
            this.IDPedido1.Name = "IDPedido1";
            this.IDPedido1.ReadOnly = true;
            this.IDPedido1.Visible = false;
            // 
            // IDEstatusPedido1
            // 
            this.IDEstatusPedido1.DataPropertyName = "IDEstatusPedido";
            this.IDEstatusPedido1.HeaderText = "IDEstatusPedido";
            this.IDEstatusPedido1.Name = "IDEstatusPedido1";
            this.IDEstatusPedido1.ReadOnly = true;
            this.IDEstatusPedido1.Visible = false;
            // 
            // Folio1
            // 
            this.Folio1.DataPropertyName = "Folio";
            this.Folio1.HeaderText = "Folio";
            this.Folio1.Name = "Folio1";
            this.Folio1.ReadOnly = true;
            this.Folio1.Width = 150;
            // 
            // EstatusPedido1
            // 
            this.EstatusPedido1.DataPropertyName = "EstatusPedido";
            this.EstatusPedido1.HeaderText = "Estatus";
            this.EstatusPedido1.Name = "EstatusPedido1";
            this.EstatusPedido1.ReadOnly = true;
            this.EstatusPedido1.Width = 180;
            // 
            // Sucursal1
            // 
            this.Sucursal1.DataPropertyName = "NombreSucursal";
            this.Sucursal1.HeaderText = "Sucursal";
            this.Sucursal1.Name = "Sucursal1";
            this.Sucursal1.ReadOnly = true;
            this.Sucursal1.Width = 250;
            // 
            // Surtido1
            // 
            this.Surtido1.DataPropertyName = "Completo";
            this.Surtido1.HeaderText = "Surtido";
            this.Surtido1.Name = "Surtido1";
            this.Surtido1.ReadOnly = true;
            this.Surtido1.Width = 120;
            // 
            // FechaPedido1
            // 
            this.FechaPedido1.DataPropertyName = "FechaPedido";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FechaPedido1.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaPedido1.HeaderText = "Fecha de Pedido";
            this.FechaPedido1.Name = "FechaPedido1";
            this.FechaPedido1.ReadOnly = true;
            this.FechaPedido1.Width = 160;
            // 
            // Empleado1
            // 
            this.Empleado1.DataPropertyName = "EmpleadoCaptura";
            this.Empleado1.HeaderText = "Empleado que capturó";
            this.Empleado1.Name = "Empleado1";
            this.Empleado1.ReadOnly = true;
            this.Empleado1.Width = 280;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PanelMenu);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 458);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 80);
            this.panel7.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.Gray;
            this.PanelMenu.Controls.Add(this.btnFinalizarPedido);
            this.PanelMenu.Controls.Add(this.btnDetallePedido);
            this.PanelMenu.Controls.Add(this.btnSurtir);
            this.PanelMenu.Controls.Add(this.btnSalir);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1008, 80);
            this.PanelMenu.TabIndex = 1;
            // 
            // btnFinalizarPedido
            // 
            this.btnFinalizarPedido.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnFinalizarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnFinalizarPedido.BorderColor = System.Drawing.Color.Red;
            this.btnFinalizarPedido.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnFinalizarPedido.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFinalizarPedido.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnFinalizarPedido.FocusRectangle = true;
            this.btnFinalizarPedido.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarPedido.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarPedido.Image = null;
            this.btnFinalizarPedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFinalizarPedido.ImageBorderColor = System.Drawing.Color.Red;
            this.btnFinalizarPedido.ImageFocused = null;
            this.btnFinalizarPedido.ImageInactive = null;
            this.btnFinalizarPedido.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0002_cancelar_a;
            this.btnFinalizarPedido.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0002_cancelar;
            this.btnFinalizarPedido.ImagePressed = null;
            this.btnFinalizarPedido.ImageSize = new System.Drawing.Size(44, 44);
            this.btnFinalizarPedido.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnFinalizarPedido.KeyButtonView = false;
            this.btnFinalizarPedido.Location = new System.Drawing.Point(650, 5);
            this.btnFinalizarPedido.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnFinalizarPedido.MouseOverColor = System.Drawing.Color.Red;
            this.btnFinalizarPedido.Name = "btnFinalizarPedido";
            this.btnFinalizarPedido.OffsetPressedContent = true;
            this.btnFinalizarPedido.Size = new System.Drawing.Size(80, 70);
            this.btnFinalizarPedido.TabIndex = 23;
            this.btnFinalizarPedido.Text = "Finalizar Inc.";
            this.btnFinalizarPedido.TextDropShadow = true;
            this.btnFinalizarPedido.UseVisualStyleBackColor = false;
            this.btnFinalizarPedido.Click += new System.EventHandler(this.btnFinalizarPedido_Click);
            // 
            // btnDetallePedido
            // 
            this.btnDetallePedido.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDetallePedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnDetallePedido.BorderColor = System.Drawing.Color.Red;
            this.btnDetallePedido.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnDetallePedido.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDetallePedido.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnDetallePedido.FocusRectangle = true;
            this.btnDetallePedido.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallePedido.ForeColor = System.Drawing.Color.White;
            this.btnDetallePedido.Image = null;
            this.btnDetallePedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetallePedido.ImageBorderColor = System.Drawing.Color.Red;
            this.btnDetallePedido.ImageFocused = null;
            this.btnDetallePedido.ImageInactive = null;
            this.btnDetallePedido.ImageMouseOver = global::StephManager.Properties.Resources.icons_steph_vino_ver_detalles_a;
            this.btnDetallePedido.ImageNormal = global::StephManager.Properties.Resources.icons_steph_vino_ver_detalles;
            this.btnDetallePedido.ImagePressed = null;
            this.btnDetallePedido.ImageSize = new System.Drawing.Size(44, 44);
            this.btnDetallePedido.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnDetallePedido.KeyButtonView = false;
            this.btnDetallePedido.Location = new System.Drawing.Point(822, 5);
            this.btnDetallePedido.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnDetallePedido.MouseOverColor = System.Drawing.Color.Red;
            this.btnDetallePedido.Name = "btnDetallePedido";
            this.btnDetallePedido.OffsetPressedContent = true;
            this.btnDetallePedido.Size = new System.Drawing.Size(80, 70);
            this.btnDetallePedido.TabIndex = 22;
            this.btnDetallePedido.Text = "Ver Detalle";
            this.btnDetallePedido.TextDropShadow = true;
            this.btnDetallePedido.UseVisualStyleBackColor = false;
            this.btnDetallePedido.Click += new System.EventHandler(this.btnDetallePedido_Click);
            // 
            // btnSurtir
            // 
            this.btnSurtir.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            this.btnSurtir.Location = new System.Drawing.Point(736, 5);
            this.btnSurtir.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSurtir.MouseOverColor = System.Drawing.Color.Red;
            this.btnSurtir.Name = "btnSurtir";
            this.btnSurtir.OffsetPressedContent = true;
            this.btnSurtir.Size = new System.Drawing.Size(80, 70);
            this.btnSurtir.TabIndex = 21;
            this.btnSurtir.Text = "Surtir";
            this.btnSurtir.TextDropShadow = true;
            this.btnSurtir.UseVisualStyleBackColor = false;
            this.btnSurtir.Click += new System.EventHandler(this.btnSurtir_Click);
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
            this.btnSalir.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0001s_0000_salir_a;
            this.btnSalir.ImageNormal = global::StephManager.Properties.Resources._0000s_0001s_0000_salir;
            this.btnSalir.ImagePressed = null;
            this.btnSalir.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSalir.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSalir.KeyButtonView = false;
            this.btnSalir.Location = new System.Drawing.Point(908, 5);
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
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Controls.Add(this.chkTodosLosRegistros);
            this.panel4.Controls.Add(this.txtBusqueda);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnCancelarBusq);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 70);
            this.panel4.TabIndex = 0;
            // 
            // chkTodosLosRegistros
            // 
            this.chkTodosLosRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkTodosLosRegistros.Location = new System.Drawing.Point(761, 28);
            this.chkTodosLosRegistros.Name = "chkTodosLosRegistros";
            this.chkTodosLosRegistros.Size = new System.Drawing.Size(156, 25);
            this.chkTodosLosRegistros.TabIndex = 152;
            this.chkTodosLosRegistros.Text = "Todos los registros";
            this.chkTodosLosRegistros.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBusqueda.Location = new System.Drawing.Point(377, 28);
            this.txtBusqueda.MaxLength = 20;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(238, 25);
            this.txtBusqueda.TabIndex = 151;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(90, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 37);
            this.label2.TabIndex = 150;
            this.label2.Text = "Folio del pedido";
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
            this.btnCancelarBusq.Location = new System.Drawing.Point(720, 28);
            this.btnCancelarBusq.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelarBusq.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelarBusq.Name = "btnCancelarBusq";
            this.btnCancelarBusq.OffsetPressedContent = true;
            this.btnCancelarBusq.Size = new System.Drawing.Size(23, 25);
            this.btnCancelarBusq.TabIndex = 18;
            this.btnCancelarBusq.Text = "X";
            this.btnCancelarBusq.TextDropShadow = true;
            this.btnCancelarBusq.UseVisualStyleBackColor = false;
            this.btnCancelarBusq.Click += new System.EventHandler(this.btnCancelarBusq_Click);
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
            this.btnBuscar.Location = new System.Drawing.Point(621, 28);
            this.btnBuscar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBuscar.MouseOverColor = System.Drawing.Color.Red;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OffsetPressedContent = true;
            this.btnBuscar.Size = new System.Drawing.Size(100, 25);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextDropShadow = true;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.pictureBox1.Location = new System.Drawing.Point(846, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 55);
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
            this.label42.Size = new System.Drawing.Size(205, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Pedidos";
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbPendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosPendientes)).EndInit();
            this.tpConcluidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosConcluidos)).EndInit();
            this.panel7.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Panel PanelMenu;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSalir;
        private System.Windows.Forms.Panel panel12;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSurtir;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelarBusq;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnDetallePedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPendientes;
        private System.Windows.Forms.DataGridView dgvPedidosPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPedido0;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEstatusPedido0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio0;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstatusPedido0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal0;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Surtido0;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPedido0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado0;
        private System.Windows.Forms.TabPage tpConcluidos;
        private System.Windows.Forms.DataGridView dgvPedidosConcluidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPedido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEstatusPedido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstatusPedido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Surtido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPedido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.CheckBox chkTodosLosRegistros;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnFinalizarPedido;
    }
}

