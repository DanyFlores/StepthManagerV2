namespace StephManager
{
    partial class frmNotificaciones
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
            this.dgvNotificaciones = new System.Windows.Forms.DataGridView();
            this.IDNotificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDTipoNotificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDNivelEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreNotificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DecripcionNotificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoNotificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnviarNotificacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Individual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IDCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnReenvio = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnNuevo = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnAprobar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnEliminar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnModificar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.chkBuscarXNotificacion = new System.Windows.Forms.CheckBox();
            this.chkBuscarXFecha = new System.Windows.Forms.CheckBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnTodos = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnCancelarBusq = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtTagBusqueda = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.bgwEnvioNotificaciones = new System.ComponentModel.BackgroundWorker();
            this.btnNuevos = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSalirr = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnEliminarr = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotificaciones)).BeginInit();
            this.panel7.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.panel9.SuspendLayout();
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
            this.panel5.Location = new System.Drawing.Point(0, 92);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 516);
            this.panel5.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 436);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.Controls.Add(this.dgvNotificaciones);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1008, 436);
            this.panel12.TabIndex = 2;
            // 
            // dgvNotificaciones
            // 
            this.dgvNotificaciones.AllowUserToAddRows = false;
            this.dgvNotificaciones.AllowUserToDeleteRows = false;
            this.dgvNotificaciones.AllowUserToOrderColumns = true;
            this.dgvNotificaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNotificaciones.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvNotificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotificaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDNotificacion,
            this.IDTipoNotificacion,
            this.IDNivelEntrega,
            this.NombreNotificacion,
            this.DecripcionNotificacion,
            this.TipoNotificacion,
            this.EnviarNotificacion,
            this.Individual,
            this.IDCliente});
            this.dgvNotificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotificaciones.Location = new System.Drawing.Point(0, 0);
            this.dgvNotificaciones.Name = "dgvNotificaciones";
            this.dgvNotificaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvNotificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotificaciones.Size = new System.Drawing.Size(1008, 436);
            this.dgvNotificaciones.TabIndex = 12;
            // 
            // IDNotificacion
            // 
            this.IDNotificacion.DataPropertyName = "IDNotificacion";
            this.IDNotificacion.HeaderText = "IDNotificacion";
            this.IDNotificacion.Name = "IDNotificacion";
            this.IDNotificacion.ReadOnly = true;
            this.IDNotificacion.Visible = false;
            // 
            // IDTipoNotificacion
            // 
            this.IDTipoNotificacion.DataPropertyName = "IDTipoNotificacion";
            this.IDTipoNotificacion.HeaderText = "IDTipoNotificacion";
            this.IDTipoNotificacion.Name = "IDTipoNotificacion";
            this.IDTipoNotificacion.ReadOnly = true;
            this.IDTipoNotificacion.Visible = false;
            // 
            // IDNivelEntrega
            // 
            this.IDNivelEntrega.DataPropertyName = "IDNivelEntrega";
            this.IDNivelEntrega.HeaderText = "IDNivelEntrega";
            this.IDNivelEntrega.Name = "IDNivelEntrega";
            this.IDNivelEntrega.ReadOnly = true;
            this.IDNivelEntrega.Visible = false;
            // 
            // NombreNotificacion
            // 
            this.NombreNotificacion.DataPropertyName = "NombreNotificacion";
            this.NombreNotificacion.HeaderText = "Nombre Notificación";
            this.NombreNotificacion.Name = "NombreNotificacion";
            this.NombreNotificacion.ReadOnly = true;
            this.NombreNotificacion.Width = 300;
            // 
            // DecripcionNotificacion
            // 
            this.DecripcionNotificacion.DataPropertyName = "DecripcionNotificacion";
            this.DecripcionNotificacion.HeaderText = "Decripción Notificación";
            this.DecripcionNotificacion.Name = "DecripcionNotificacion";
            this.DecripcionNotificacion.ReadOnly = true;
            this.DecripcionNotificacion.Width = 350;
            // 
            // TipoNotificacion
            // 
            this.TipoNotificacion.DataPropertyName = "TipoNotificacion";
            this.TipoNotificacion.HeaderText = "Tipo Notificación";
            this.TipoNotificacion.Name = "TipoNotificacion";
            this.TipoNotificacion.ReadOnly = true;
            this.TipoNotificacion.Width = 300;
            // 
            // EnviarNotificacion
            // 
            this.EnviarNotificacion.DataPropertyName = "EnviarNotificacion";
            this.EnviarNotificacion.HeaderText = "Enviada";
            this.EnviarNotificacion.Name = "EnviarNotificacion";
            this.EnviarNotificacion.ReadOnly = true;
            // 
            // Individual
            // 
            this.Individual.DataPropertyName = "Individual";
            this.Individual.HeaderText = "Individual o Grupal";
            this.Individual.Name = "Individual";
            this.Individual.ReadOnly = true;
            this.Individual.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Individual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Individual.Width = 200;
            // 
            // IDCliente
            // 
            this.IDCliente.DataPropertyName = "IDGeneral";
            this.IDCliente.HeaderText = "IDCliente";
            this.IDCliente.Name = "IDCliente";
            this.IDCliente.ReadOnly = true;
            this.IDCliente.Visible = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PanelMenu);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 436);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 80);
            this.panel7.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.Gray;
            this.PanelMenu.Controls.Add(this.panel9);
            this.PanelMenu.Controls.Add(this.btnNuevo);
            this.PanelMenu.Controls.Add(this.btnAprobar);
            this.PanelMenu.Controls.Add(this.btnSalir);
            this.PanelMenu.Controls.Add(this.btnEliminar);
            this.PanelMenu.Controls.Add(this.btnModificar);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1008, 80);
            this.PanelMenu.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Gray;
            this.panel9.Controls.Add(this.btnReenvio);
            this.panel9.Controls.Add(this.btnNuevos);
            this.panel9.Controls.Add(this.btnSalirr);
            this.panel9.Controls.Add(this.btnEliminarr);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1008, 80);
            this.panel9.TabIndex = 23;
            // 
            // btnReenvio
            // 
            this.btnReenvio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReenvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnReenvio.BorderColor = System.Drawing.Color.Red;
            this.btnReenvio.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnReenvio.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReenvio.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnReenvio.FocusRectangle = true;
            this.btnReenvio.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReenvio.ForeColor = System.Drawing.Color.White;
            this.btnReenvio.Image = null;
            this.btnReenvio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReenvio.ImageBorderColor = System.Drawing.Color.Red;
            this.btnReenvio.ImageFocused = null;
            this.btnReenvio.ImageInactive = null;
            this.btnReenvio.ImageMouseOver = global::StephManager.Properties.Resources.icons_steph_vino_notificaciones_reenviar_n;
            this.btnReenvio.ImageNormal = global::StephManager.Properties.Resources.icons_steph_vino_notificaciones_reenviar;
            this.btnReenvio.ImagePressed = null;
            this.btnReenvio.ImageSize = new System.Drawing.Size(44, 44);
            this.btnReenvio.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnReenvio.KeyButtonView = false;
            this.btnReenvio.Location = new System.Drawing.Point(651, 5);
            this.btnReenvio.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnReenvio.MouseOverColor = System.Drawing.Color.Red;
            this.btnReenvio.Name = "btnReenvio";
            this.btnReenvio.OffsetPressedContent = true;
            this.btnReenvio.Size = new System.Drawing.Size(80, 70);
            this.btnReenvio.TabIndex = 23;
            this.btnReenvio.Text = "Reenviar";
            this.btnReenvio.TextDropShadow = true;
            this.btnReenvio.UseVisualStyleBackColor = false;
            this.btnReenvio.Click += new System.EventHandler(this.btnReenvio_Click);
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
            this.btnNuevo.Location = new System.Drawing.Point(651, 5);
            this.btnNuevo.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNuevo.MouseOverColor = System.Drawing.Color.Red;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.OffsetPressedContent = true;
            this.btnNuevo.Size = new System.Drawing.Size(80, 70);
            this.btnNuevo.TabIndex = 22;
            this.btnNuevo.Text = "Nueva";
            this.btnNuevo.TextDropShadow = true;
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnAprobar
            // 
            this.btnAprobar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAprobar.BorderColor = System.Drawing.Color.Red;
            this.btnAprobar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnAprobar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAprobar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnAprobar.FocusRectangle = true;
            this.btnAprobar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprobar.ForeColor = System.Drawing.Color.White;
            this.btnAprobar.Image = null;
            this.btnAprobar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAprobar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnAprobar.ImageFocused = null;
            this.btnAprobar.ImageInactive = null;
            this.btnAprobar.ImageMouseOver = null;
            this.btnAprobar.ImageNormal = null;
            this.btnAprobar.ImagePressed = null;
            this.btnAprobar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAprobar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAprobar.KeyButtonView = false;
            this.btnAprobar.Location = new System.Drawing.Point(565, 5);
            this.btnAprobar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAprobar.MouseOverColor = System.Drawing.Color.Red;
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.OffsetPressedContent = true;
            this.btnAprobar.Size = new System.Drawing.Size(80, 70);
            this.btnAprobar.TabIndex = 21;
            this.btnAprobar.Text = "Enviar";
            this.btnAprobar.TextDropShadow = true;
            this.btnAprobar.UseVisualStyleBackColor = false;
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
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminar.BorderColor = System.Drawing.Color.Red;
            this.btnEliminar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnEliminar.FocusRectangle = true;
            this.btnEliminar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = null;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnEliminar.ImageFocused = null;
            this.btnEliminar.ImageInactive = null;
            this.btnEliminar.ImageMouseOver = null;
            this.btnEliminar.ImageNormal = null;
            this.btnEliminar.ImagePressed = null;
            this.btnEliminar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnEliminar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnEliminar.KeyButtonView = false;
            this.btnEliminar.Location = new System.Drawing.Point(823, 5);
            this.btnEliminar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnEliminar.MouseOverColor = System.Drawing.Color.Red;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.OffsetPressedContent = true;
            this.btnEliminar.Size = new System.Drawing.Size(80, 70);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextDropShadow = true;
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnModificar.BorderColor = System.Drawing.Color.Red;
            this.btnModificar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnModificar.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnModificar.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnModificar.FocusRectangle = true;
            this.btnModificar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Image = null;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificar.ImageBorderColor = System.Drawing.Color.Red;
            this.btnModificar.ImageFocused = null;
            this.btnModificar.ImageInactive = null;
            this.btnModificar.ImageMouseOver = null;
            this.btnModificar.ImageNormal = null;
            this.btnModificar.ImagePressed = null;
            this.btnModificar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnModificar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnModificar.KeyButtonView = false;
            this.btnModificar.Location = new System.Drawing.Point(737, 5);
            this.btnModificar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnModificar.MouseOverColor = System.Drawing.Color.Red;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.OffsetPressedContent = true;
            this.btnModificar.Size = new System.Drawing.Size(80, 70);
            this.btnModificar.TabIndex = 18;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextDropShadow = true;
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Controls.Add(this.dtpFecha2);
            this.panel4.Controls.Add(this.chkBuscarXNotificacion);
            this.panel4.Controls.Add(this.chkBuscarXFecha);
            this.panel4.Controls.Add(this.dtpFecha);
            this.panel4.Controls.Add(this.btnTodos);
            this.panel4.Controls.Add(this.btnCancelarBusq);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Controls.Add(this.txtTagBusqueda);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 92);
            this.panel4.TabIndex = 0;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha2.Location = new System.Drawing.Point(515, 40);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(116, 25);
            this.dtpFecha2.TabIndex = 65;
            // 
            // chkBuscarXNotificacion
            // 
            this.chkBuscarXNotificacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkBuscarXNotificacion.Location = new System.Drawing.Point(83, 6);
            this.chkBuscarXNotificacion.Name = "chkBuscarXNotificacion";
            this.chkBuscarXNotificacion.Size = new System.Drawing.Size(200, 28);
            this.chkBuscarXNotificacion.TabIndex = 64;
            this.chkBuscarXNotificacion.Text = "Nombre de Notificación";
            this.chkBuscarXNotificacion.UseVisualStyleBackColor = true;
            // 
            // chkBuscarXFecha
            // 
            this.chkBuscarXFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkBuscarXFecha.Location = new System.Drawing.Point(410, 6);
            this.chkBuscarXFecha.Name = "chkBuscarXFecha";
            this.chkBuscarXFecha.Size = new System.Drawing.Size(196, 28);
            this.chkBuscarXFecha.TabIndex = 63;
            this.chkBuscarXFecha.Text = "Fecha de Notificación";
            this.chkBuscarXFecha.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(384, 40);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(116, 25);
            this.dtpFecha.TabIndex = 61;
            // 
            // btnTodos
            // 
            this.btnTodos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnTodos.BorderColor = System.Drawing.Color.Red;
            this.btnTodos.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnTodos.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTodos.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnTodos.FocusRectangle = true;
            this.btnTodos.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodos.ForeColor = System.Drawing.Color.Black;
            this.btnTodos.Image = null;
            this.btnTodos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTodos.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(205)))), ((int)(((byte)(215)))));
            this.btnTodos.ImageFocused = null;
            this.btnTodos.ImageInactive = null;
            this.btnTodos.ImageMouseOver = null;
            this.btnTodos.ImageNormal = null;
            this.btnTodos.ImagePressed = null;
            this.btnTodos.ImageSize = new System.Drawing.Size(44, 44);
            this.btnTodos.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnTodos.KeyButtonView = false;
            this.btnTodos.Location = new System.Drawing.Point(888, 36);
            this.btnTodos.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnTodos.MouseOverColor = System.Drawing.Color.Red;
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.OffsetPressedContent = true;
            this.btnTodos.Size = new System.Drawing.Size(100, 25);
            this.btnTodos.TabIndex = 60;
            this.btnTodos.Text = "Ver todos";
            this.btnTodos.TextDropShadow = true;
            this.btnTodos.UseVisualStyleBackColor = false;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
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
            this.btnCancelarBusq.Location = new System.Drawing.Point(792, 36);
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
            this.btnBuscar.Location = new System.Drawing.Point(686, 36);
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
            // txtTagBusqueda
            // 
            this.txtTagBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTagBusqueda.Location = new System.Drawing.Point(69, 40);
            this.txtTagBusqueda.MaxLength = 20;
            this.txtTagBusqueda.Name = "txtTagBusqueda";
            this.txtTagBusqueda.Size = new System.Drawing.Size(248, 25);
            this.txtTagBusqueda.TabIndex = 13;
            this.txtTagBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTagBusqueda_KeyPress);
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
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(336, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Notificaciones";
            // 
            // bgwEnvioNotificaciones
            // 
            this.bgwEnvioNotificaciones.WorkerReportsProgress = true;
            this.bgwEnvioNotificaciones.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwEnvioNotificaciones_DoWork);
            this.bgwEnvioNotificaciones.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwEnvioNotificaciones_ProgressChanged);
            this.bgwEnvioNotificaciones.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwEnvioNotificaciones_RunWorkerCompleted);
            // 
            // btnNuevos
            // 
            this.btnNuevos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnNuevos.BorderColor = System.Drawing.Color.Red;
            this.btnNuevos.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnNuevos.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNuevos.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnNuevos.FocusRectangle = true;
            this.btnNuevos.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevos.ForeColor = System.Drawing.Color.White;
            this.btnNuevos.Image = null;
            this.btnNuevos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevos.ImageBorderColor = System.Drawing.Color.Red;
            this.btnNuevos.ImageFocused = null;
            this.btnNuevos.ImageInactive = null;
            this.btnNuevos.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0001_agregar_a;
            this.btnNuevos.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0001_agregar;
            this.btnNuevos.ImagePressed = null;
            this.btnNuevos.ImageSize = new System.Drawing.Size(44, 44);
            this.btnNuevos.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnNuevos.KeyButtonView = false;
            this.btnNuevos.Location = new System.Drawing.Point(737, 6);
            this.btnNuevos.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNuevos.MouseOverColor = System.Drawing.Color.Red;
            this.btnNuevos.Name = "btnNuevos";
            this.btnNuevos.OffsetPressedContent = true;
            this.btnNuevos.Size = new System.Drawing.Size(80, 70);
            this.btnNuevos.TabIndex = 22;
            this.btnNuevos.Text = "Nueva";
            this.btnNuevos.TextDropShadow = true;
            this.btnNuevos.UseVisualStyleBackColor = false;
            this.btnNuevos.Click += new System.EventHandler(this.btnNuevos_Click);
            // 
            // btnSalirr
            // 
            this.btnSalirr.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalirr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSalirr.BorderColor = System.Drawing.Color.Red;
            this.btnSalirr.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnSalirr.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalirr.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnSalirr.FocusRectangle = true;
            this.btnSalirr.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirr.ForeColor = System.Drawing.Color.White;
            this.btnSalirr.Image = null;
            this.btnSalirr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalirr.ImageBorderColor = System.Drawing.Color.Red;
            this.btnSalirr.ImageFocused = null;
            this.btnSalirr.ImageInactive = null;
            this.btnSalirr.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0001s_0000_salir_a;
            this.btnSalirr.ImageNormal = global::StephManager.Properties.Resources._0000s_0001s_0000_salir;
            this.btnSalirr.ImagePressed = null;
            this.btnSalirr.ImageSize = new System.Drawing.Size(44, 44);
            this.btnSalirr.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnSalirr.KeyButtonView = false;
            this.btnSalirr.Location = new System.Drawing.Point(908, 5);
            this.btnSalirr.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSalirr.MouseOverColor = System.Drawing.Color.Red;
            this.btnSalirr.Name = "btnSalirr";
            this.btnSalirr.OffsetPressedContent = true;
            this.btnSalirr.Size = new System.Drawing.Size(80, 70);
            this.btnSalirr.TabIndex = 20;
            this.btnSalirr.Text = "Salir";
            this.btnSalirr.TextDropShadow = true;
            this.btnSalirr.UseVisualStyleBackColor = false;
            this.btnSalirr.Click += new System.EventHandler(this.btnSalirr_Click);
            // 
            // btnEliminarr
            // 
            this.btnEliminarr.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEliminarr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminarr.BorderColor = System.Drawing.Color.Red;
            this.btnEliminarr.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnEliminarr.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarr.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnEliminarr.FocusRectangle = true;
            this.btnEliminarr.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarr.ForeColor = System.Drawing.Color.White;
            this.btnEliminarr.Image = null;
            this.btnEliminarr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarr.ImageBorderColor = System.Drawing.Color.Red;
            this.btnEliminarr.ImageFocused = null;
            this.btnEliminarr.ImageInactive = null;
            this.btnEliminarr.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0004_eliminar_a;
            this.btnEliminarr.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0004_eliminar;
            this.btnEliminarr.ImagePressed = null;
            this.btnEliminarr.ImageSize = new System.Drawing.Size(44, 44);
            this.btnEliminarr.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnEliminarr.KeyButtonView = false;
            this.btnEliminarr.Location = new System.Drawing.Point(823, 5);
            this.btnEliminarr.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnEliminarr.MouseOverColor = System.Drawing.Color.Red;
            this.btnEliminarr.Name = "btnEliminarr";
            this.btnEliminarr.OffsetPressedContent = true;
            this.btnEliminarr.Size = new System.Drawing.Size(80, 70);
            this.btnEliminarr.TabIndex = 19;
            this.btnEliminarr.Text = "Eliminar";
            this.btnEliminarr.TextDropShadow = true;
            this.btnEliminarr.UseVisualStyleBackColor = false;
            this.btnEliminarr.Click += new System.EventHandler(this.btnEliminarr_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(857, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // frmNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmNotificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCatalogoWeb_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotificaciones)).EndInit();
            this.panel7.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
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
        private CreativaSL.LibControls.WinForms.Button_Creativa btnModificar;
        private System.Windows.Forms.Panel panel12;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private System.Windows.Forms.TextBox txtTagBusqueda;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelarBusq;
        private System.Windows.Forms.DataGridView dgvNotificaciones;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnEliminar;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAprobar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnNuevo;
        private System.Windows.Forms.Panel panel9;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSalirr;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnEliminarr;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnNuevos;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnTodos;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnReenvio;
        private System.ComponentModel.BackgroundWorker bgwEnvioNotificaciones;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.CheckBox chkBuscarXNotificacion;
        private System.Windows.Forms.CheckBox chkBuscarXFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNotificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTipoNotificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNivelEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreNotificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DecripcionNotificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoNotificacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnviarNotificacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Individual;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCliente;
    }
}

