namespace StephManager
{
    partial class frmMobiliario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.IDMobiliarioXSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMobiliario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobiliarioDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbSucursales = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnTranferencia = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnBajaMobiliario = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnResguardoMobiliario = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCompras = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.PanelMenu.SuspendLayout();
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
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 608);
            this.panel5.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 528);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.Controls.Add(this.panel9);
            this.panel12.Controls.Add(this.panel4);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1008, 528);
            this.panel12.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dgvPedidos);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 58);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1008, 470);
            this.panel9.TabIndex = 1;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AllowUserToResizeRows = false;
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDMobiliarioXSucursal,
            this.IDSucursal,
            this.IDMobiliario,
            this.NombreSucursal,
            this.Codigo,
            this.MobiliarioDesc,
            this.Marca,
            this.Modelo,
            this.NumSerie,
            this.FechaAsignacion});
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidos.Location = new System.Drawing.Point(0, 0);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(1008, 470);
            this.dgvPedidos.TabIndex = 13;
            // 
            // IDMobiliarioXSucursal
            // 
            this.IDMobiliarioXSucursal.DataPropertyName = "IDMobiliarioXSucursal";
            this.IDMobiliarioXSucursal.HeaderText = "IDMobiliarioXSucursal";
            this.IDMobiliarioXSucursal.Name = "IDMobiliarioXSucursal";
            this.IDMobiliarioXSucursal.ReadOnly = true;
            this.IDMobiliarioXSucursal.Visible = false;
            // 
            // IDSucursal
            // 
            this.IDSucursal.DataPropertyName = "IDSucursal";
            this.IDSucursal.HeaderText = "IDSucursal";
            this.IDSucursal.Name = "IDSucursal";
            this.IDSucursal.ReadOnly = true;
            this.IDSucursal.Visible = false;
            // 
            // IDMobiliario
            // 
            this.IDMobiliario.DataPropertyName = "IDMobiliario";
            this.IDMobiliario.HeaderText = "IDMobiliario";
            this.IDMobiliario.Name = "IDMobiliario";
            this.IDMobiliario.ReadOnly = true;
            this.IDMobiliario.Visible = false;
            // 
            // NombreSucursal
            // 
            this.NombreSucursal.DataPropertyName = "NombreSucursal";
            this.NombreSucursal.HeaderText = "Sucursal";
            this.NombreSucursal.Name = "NombreSucursal";
            this.NombreSucursal.ReadOnly = true;
            this.NombreSucursal.Width = 180;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 110;
            // 
            // MobiliarioDesc
            // 
            this.MobiliarioDesc.DataPropertyName = "MobiliarioDesc";
            this.MobiliarioDesc.HeaderText = "Descripción";
            this.MobiliarioDesc.Name = "MobiliarioDesc";
            this.MobiliarioDesc.ReadOnly = true;
            this.MobiliarioDesc.Width = 200;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "Marca";
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            this.Marca.Width = 165;
            // 
            // Modelo
            // 
            this.Modelo.DataPropertyName = "Modelo";
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            this.Modelo.Width = 180;
            // 
            // NumSerie
            // 
            this.NumSerie.DataPropertyName = "NumSerie";
            this.NumSerie.HeaderText = "Núm. de serie";
            this.NumSerie.Name = "NumSerie";
            this.NumSerie.ReadOnly = true;
            this.NumSerie.Width = 110;
            // 
            // FechaAsignacion
            // 
            this.FechaAsignacion.DataPropertyName = "FechaAsignacion";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FechaAsignacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaAsignacion.HeaderText = "Fecha de Asignación";
            this.FechaAsignacion.Name = "FechaAsignacion";
            this.FechaAsignacion.ReadOnly = true;
            this.FechaAsignacion.Width = 120;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.cmbSucursales);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 58);
            this.panel4.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.Location = new System.Drawing.Point(185, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Sucursal";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSucursales
            // 
            this.cmbSucursales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSucursales.FormattingEnabled = true;
            this.cmbSucursales.Location = new System.Drawing.Point(316, 10);
            this.cmbSucursales.Name = "cmbSucursales";
            this.cmbSucursales.Size = new System.Drawing.Size(242, 28);
            this.cmbSucursales.TabIndex = 29;
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
            this.btnBuscar.Location = new System.Drawing.Point(563, 10);
            this.btnBuscar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBuscar.MouseOverColor = System.Drawing.Color.Red;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OffsetPressedContent = true;
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextDropShadow = true;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PanelMenu);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 528);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 80);
            this.panel7.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.Gray;
            this.PanelMenu.Controls.Add(this.btnTranferencia);
            this.PanelMenu.Controls.Add(this.btnBajaMobiliario);
            this.PanelMenu.Controls.Add(this.btnResguardoMobiliario);
            this.PanelMenu.Controls.Add(this.btnCompras);
            this.PanelMenu.Controls.Add(this.btnSalir);
            this.PanelMenu.Controls.Add(this.btnCancelar);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1008, 80);
            this.PanelMenu.TabIndex = 1;
            // 
            // btnTranferencia
            // 
            this.btnTranferencia.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTranferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnTranferencia.BorderColor = System.Drawing.Color.Red;
            this.btnTranferencia.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnTranferencia.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTranferencia.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnTranferencia.FocusRectangle = true;
            this.btnTranferencia.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranferencia.ForeColor = System.Drawing.Color.White;
            this.btnTranferencia.Image = null;
            this.btnTranferencia.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTranferencia.ImageBorderColor = System.Drawing.Color.Red;
            this.btnTranferencia.ImageFocused = null;
            this.btnTranferencia.ImageInactive = null;
            this.btnTranferencia.ImageMouseOver = global::StephManager.Properties.Resources.icons_steph_negro___0007_transferencias;
            this.btnTranferencia.ImageNormal = global::StephManager.Properties.Resources.icons_steph_negro___0007_transferencias_a;
            this.btnTranferencia.ImagePressed = null;
            this.btnTranferencia.ImageSize = new System.Drawing.Size(44, 44);
            this.btnTranferencia.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnTranferencia.KeyButtonView = false;
            this.btnTranferencia.Location = new System.Drawing.Point(478, 5);
            this.btnTranferencia.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnTranferencia.MouseOverColor = System.Drawing.Color.Red;
            this.btnTranferencia.Name = "btnTranferencia";
            this.btnTranferencia.OffsetPressedContent = true;
            this.btnTranferencia.Size = new System.Drawing.Size(80, 70);
            this.btnTranferencia.TabIndex = 24;
            this.btnTranferencia.Text = "Transferir";
            this.btnTranferencia.TextDropShadow = true;
            this.btnTranferencia.UseVisualStyleBackColor = false;
            this.btnTranferencia.Click += new System.EventHandler(this.btnTranferencia_Click);
            // 
            // btnBajaMobiliario
            // 
            this.btnBajaMobiliario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBajaMobiliario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBajaMobiliario.BorderColor = System.Drawing.Color.Red;
            this.btnBajaMobiliario.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnBajaMobiliario.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBajaMobiliario.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnBajaMobiliario.FocusRectangle = true;
            this.btnBajaMobiliario.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajaMobiliario.ForeColor = System.Drawing.Color.White;
            this.btnBajaMobiliario.Image = null;
            this.btnBajaMobiliario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBajaMobiliario.ImageBorderColor = System.Drawing.Color.Red;
            this.btnBajaMobiliario.ImageFocused = null;
            this.btnBajaMobiliario.ImageInactive = null;
            this.btnBajaMobiliario.ImageMouseOver = global::StephManager.Properties.Resources.icons_steph_vino_mobiliario_baja_n;
            this.btnBajaMobiliario.ImageNormal = global::StephManager.Properties.Resources.icons_steph_vino_mobiliario_baja;
            this.btnBajaMobiliario.ImagePressed = null;
            this.btnBajaMobiliario.ImageSize = new System.Drawing.Size(44, 44);
            this.btnBajaMobiliario.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnBajaMobiliario.KeyButtonView = false;
            this.btnBajaMobiliario.Location = new System.Drawing.Point(564, 5);
            this.btnBajaMobiliario.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBajaMobiliario.MouseOverColor = System.Drawing.Color.Red;
            this.btnBajaMobiliario.Name = "btnBajaMobiliario";
            this.btnBajaMobiliario.OffsetPressedContent = true;
            this.btnBajaMobiliario.Size = new System.Drawing.Size(80, 70);
            this.btnBajaMobiliario.TabIndex = 23;
            this.btnBajaMobiliario.Text = "Baja Mob.";
            this.btnBajaMobiliario.TextDropShadow = true;
            this.btnBajaMobiliario.UseVisualStyleBackColor = false;
            this.btnBajaMobiliario.Click += new System.EventHandler(this.btnBajaMobiliario_Click);
            // 
            // btnResguardoMobiliario
            // 
            this.btnResguardoMobiliario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnResguardoMobiliario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnResguardoMobiliario.BorderColor = System.Drawing.Color.Red;
            this.btnResguardoMobiliario.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnResguardoMobiliario.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnResguardoMobiliario.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnResguardoMobiliario.FocusRectangle = true;
            this.btnResguardoMobiliario.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResguardoMobiliario.ForeColor = System.Drawing.Color.White;
            this.btnResguardoMobiliario.Image = null;
            this.btnResguardoMobiliario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnResguardoMobiliario.ImageBorderColor = System.Drawing.Color.Red;
            this.btnResguardoMobiliario.ImageFocused = null;
            this.btnResguardoMobiliario.ImageInactive = null;
            this.btnResguardoMobiliario.ImageMouseOver = global::StephManager.Properties.Resources.icons_steph_vino_mobiliario_resguardo_n;
            this.btnResguardoMobiliario.ImageNormal = global::StephManager.Properties.Resources.icons_steph_vino_mobiliario_resguardo;
            this.btnResguardoMobiliario.ImagePressed = null;
            this.btnResguardoMobiliario.ImageSize = new System.Drawing.Size(44, 44);
            this.btnResguardoMobiliario.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnResguardoMobiliario.KeyButtonView = false;
            this.btnResguardoMobiliario.Location = new System.Drawing.Point(822, 5);
            this.btnResguardoMobiliario.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnResguardoMobiliario.MouseOverColor = System.Drawing.Color.Red;
            this.btnResguardoMobiliario.Name = "btnResguardoMobiliario";
            this.btnResguardoMobiliario.OffsetPressedContent = true;
            this.btnResguardoMobiliario.Size = new System.Drawing.Size(80, 70);
            this.btnResguardoMobiliario.TabIndex = 22;
            this.btnResguardoMobiliario.Text = "Resguardo";
            this.btnResguardoMobiliario.TextDropShadow = true;
            this.btnResguardoMobiliario.UseVisualStyleBackColor = false;
            this.btnResguardoMobiliario.Click += new System.EventHandler(this.btnResguardoMobiliario_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCompras.BorderColor = System.Drawing.Color.Red;
            this.btnCompras.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnCompras.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCompras.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnCompras.FocusRectangle = true;
            this.btnCompras.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.ForeColor = System.Drawing.Color.White;
            this.btnCompras.Image = null;
            this.btnCompras.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCompras.ImageBorderColor = System.Drawing.Color.Red;
            this.btnCompras.ImageFocused = null;
            this.btnCompras.ImageInactive = null;
            this.btnCompras.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0001s_0002_compras_a;
            this.btnCompras.ImageNormal = global::StephManager.Properties.Resources._0000s_0001s_0002_compras;
            this.btnCompras.ImagePressed = null;
            this.btnCompras.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCompras.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCompras.KeyButtonView = false;
            this.btnCompras.Location = new System.Drawing.Point(736, 5);
            this.btnCompras.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCompras.MouseOverColor = System.Drawing.Color.Red;
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.OffsetPressedContent = true;
            this.btnCompras.Size = new System.Drawing.Size(80, 70);
            this.btnCompras.TabIndex = 21;
            this.btnCompras.Text = "Compras";
            this.btnCompras.TextDropShadow = true;
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
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
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            this.btnCancelar.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0001s_0014_catalogo_a;
            this.btnCancelar.ImageNormal = global::StephManager.Properties.Resources._0000s_0001s_0014_catalogo;
            this.btnCancelar.ImagePressed = null;
            this.btnCancelar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnCancelar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnCancelar.KeyButtonView = false;
            this.btnCancelar.Location = new System.Drawing.Point(650, 5);
            this.btnCancelar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancelar.MouseOverColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.Size = new System.Drawing.Size(80, 70);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Catálogo";
            this.btnCancelar.TextDropShadow = true;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCatMobiliario_Click);
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
            this.label42.Size = new System.Drawing.Size(238, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Mobiliario";
            // 
            // frmMobiliario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmMobiliario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMobiliario_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel PanelMenu;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSalir;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelar;
        private System.Windows.Forms.Panel panel12;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCompras;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnResguardoMobiliario;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMobiliarioXSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMobiliario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobiliarioDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAsignacion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbSucursales;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBajaMobiliario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnTranferencia;
    }
}

