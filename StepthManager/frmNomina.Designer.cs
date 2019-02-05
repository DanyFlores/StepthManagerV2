namespace StephManager
{
    partial class frmNomina
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dgvNomina = new System.Windows.Forms.DataGridView();
            this.IDNomina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoNomina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveNomina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnReporteDetalle = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnReporteSaldos = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnNuevaNomina = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.rbPeriodo = new System.Windows.Forms.RadioButton();
            this.rbClaveNomina = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtBusq = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.MenuStripNomina = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolsm_NominaAdm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsm_NominaFiscal = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).BeginInit();
            this.panel7.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MenuStripNomina.SuspendLayout();
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
            this.panel5.Location = new System.Drawing.Point(0, 69);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1008, 539);
            this.panel5.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1008, 459);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.AutoScroll = true;
            this.panel12.Controls.Add(this.dgvNomina);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1008, 459);
            this.panel12.TabIndex = 2;
            // 
            // dgvNomina
            // 
            this.dgvNomina.AllowUserToAddRows = false;
            this.dgvNomina.AllowUserToDeleteRows = false;
            this.dgvNomina.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNomina.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNomina.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDNomina,
            this.TipoNomina,
            this.ClaveNomina,
            this.FechaInicio,
            this.FechaFin});
            this.dgvNomina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNomina.Location = new System.Drawing.Point(0, 0);
            this.dgvNomina.MultiSelect = false;
            this.dgvNomina.Name = "dgvNomina";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNomina.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNomina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNomina.Size = new System.Drawing.Size(1008, 459);
            this.dgvNomina.TabIndex = 1;
            // 
            // IDNomina
            // 
            this.IDNomina.DataPropertyName = "IDNomina";
            this.IDNomina.HeaderText = "IDNomina";
            this.IDNomina.Name = "IDNomina";
            this.IDNomina.ReadOnly = true;
            this.IDNomina.Visible = false;
            // 
            // TipoNomina
            // 
            this.TipoNomina.DataPropertyName = "TipoNomina";
            this.TipoNomina.HeaderText = "Tipo de nómina";
            this.TipoNomina.Name = "TipoNomina";
            this.TipoNomina.ReadOnly = true;
            this.TipoNomina.Width = 200;
            // 
            // ClaveNomina
            // 
            this.ClaveNomina.DataPropertyName = "ClaveNomina";
            this.ClaveNomina.HeaderText = "Clave de nómina";
            this.ClaveNomina.Name = "ClaveNomina";
            this.ClaveNomina.ReadOnly = true;
            this.ClaveNomina.Width = 200;
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
            this.FechaFin.HeaderText = "Fecha Fin";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ReadOnly = true;
            this.FechaFin.Width = 200;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.PanelMenu);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 459);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1008, 80);
            this.panel7.TabIndex = 0;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.Gray;
            this.PanelMenu.Controls.Add(this.btnReporteDetalle);
            this.PanelMenu.Controls.Add(this.btnReporteSaldos);
            this.PanelMenu.Controls.Add(this.btnNuevaNomina);
            this.PanelMenu.Controls.Add(this.btnSalir);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1008, 80);
            this.PanelMenu.TabIndex = 1;
            // 
            // btnReporteDetalle
            // 
            this.btnReporteDetalle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReporteDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnReporteDetalle.BorderColor = System.Drawing.Color.Red;
            this.btnReporteDetalle.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnReporteDetalle.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReporteDetalle.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnReporteDetalle.FocusRectangle = true;
            this.btnReporteDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteDetalle.ForeColor = System.Drawing.Color.White;
            this.btnReporteDetalle.Image = null;
            this.btnReporteDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReporteDetalle.ImageBorderColor = System.Drawing.Color.Red;
            this.btnReporteDetalle.ImageFocused = null;
            this.btnReporteDetalle.ImageInactive = null;
            this.btnReporteDetalle.ImageMouseOver = global::StephManager.Properties.Resources.icons_steph_vino_nomina_reporte_detalle_n;
            this.btnReporteDetalle.ImageNormal = global::StephManager.Properties.Resources.icons_steph_vino_nomina_reporte_detalle;
            this.btnReporteDetalle.ImagePressed = null;
            this.btnReporteDetalle.ImageSize = new System.Drawing.Size(44, 44);
            this.btnReporteDetalle.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnReporteDetalle.KeyButtonView = false;
            this.btnReporteDetalle.Location = new System.Drawing.Point(650, 5);
            this.btnReporteDetalle.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnReporteDetalle.MouseOverColor = System.Drawing.Color.Red;
            this.btnReporteDetalle.Name = "btnReporteDetalle";
            this.btnReporteDetalle.OffsetPressedContent = true;
            this.btnReporteDetalle.Size = new System.Drawing.Size(80, 70);
            this.btnReporteDetalle.TabIndex = 23;
            this.btnReporteDetalle.Text = "Rpt Detalle";
            this.btnReporteDetalle.TextDropShadow = true;
            this.btnReporteDetalle.UseVisualStyleBackColor = false;
            this.btnReporteDetalle.Click += new System.EventHandler(this.btnReporteDetalle_Click);
            // 
            // btnReporteSaldos
            // 
            this.btnReporteSaldos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReporteSaldos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnReporteSaldos.BorderColor = System.Drawing.Color.Red;
            this.btnReporteSaldos.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnReporteSaldos.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReporteSaldos.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnReporteSaldos.FocusRectangle = true;
            this.btnReporteSaldos.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteSaldos.ForeColor = System.Drawing.Color.White;
            this.btnReporteSaldos.Image = null;
            this.btnReporteSaldos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReporteSaldos.ImageBorderColor = System.Drawing.Color.Red;
            this.btnReporteSaldos.ImageFocused = null;
            this.btnReporteSaldos.ImageInactive = null;
            this.btnReporteSaldos.ImageMouseOver = global::StephManager.Properties.Resources.icons_steph_vino_nomina_reporte_saldo_n;
            this.btnReporteSaldos.ImageNormal = global::StephManager.Properties.Resources.icons_steph_vino_nomina_reporte_saldo;
            this.btnReporteSaldos.ImagePressed = null;
            this.btnReporteSaldos.ImageSize = new System.Drawing.Size(44, 44);
            this.btnReporteSaldos.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnReporteSaldos.KeyButtonView = false;
            this.btnReporteSaldos.Location = new System.Drawing.Point(736, 5);
            this.btnReporteSaldos.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnReporteSaldos.MouseOverColor = System.Drawing.Color.Red;
            this.btnReporteSaldos.Name = "btnReporteSaldos";
            this.btnReporteSaldos.OffsetPressedContent = true;
            this.btnReporteSaldos.Size = new System.Drawing.Size(80, 70);
            this.btnReporteSaldos.TabIndex = 22;
            this.btnReporteSaldos.Text = "Rpt Saldos";
            this.btnReporteSaldos.TextDropShadow = true;
            this.btnReporteSaldos.UseVisualStyleBackColor = false;
            this.btnReporteSaldos.Click += new System.EventHandler(this.btnReporteSaldos_Click);
            // 
            // btnNuevaNomina
            // 
            this.btnNuevaNomina.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevaNomina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnNuevaNomina.BorderColor = System.Drawing.Color.Red;
            this.btnNuevaNomina.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.btnNuevaNomina.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNuevaNomina.BorderNoFocusColor = System.Drawing.Color.Maroon;
            this.btnNuevaNomina.FocusRectangle = true;
            this.btnNuevaNomina.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaNomina.ForeColor = System.Drawing.Color.White;
            this.btnNuevaNomina.Image = null;
            this.btnNuevaNomina.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevaNomina.ImageBorderColor = System.Drawing.Color.Red;
            this.btnNuevaNomina.ImageFocused = null;
            this.btnNuevaNomina.ImageInactive = null;
            this.btnNuevaNomina.ImageMouseOver = global::StephManager.Properties.Resources.icons_steph_vino_nuevo_nomina_generar_n;
            this.btnNuevaNomina.ImageNormal = global::StephManager.Properties.Resources.icons_steph_vino_nuevo_nomina_generar;
            this.btnNuevaNomina.ImagePressed = null;
            this.btnNuevaNomina.ImageSize = new System.Drawing.Size(44, 44);
            this.btnNuevaNomina.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnNuevaNomina.KeyButtonView = false;
            this.btnNuevaNomina.Location = new System.Drawing.Point(822, 5);
            this.btnNuevaNomina.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNuevaNomina.MouseOverColor = System.Drawing.Color.Red;
            this.btnNuevaNomina.Name = "btnNuevaNomina";
            this.btnNuevaNomina.OffsetPressedContent = true;
            this.btnNuevaNomina.Size = new System.Drawing.Size(80, 70);
            this.btnNuevaNomina.TabIndex = 21;
            this.btnNuevaNomina.Text = "Generar";
            this.btnNuevaNomina.TextDropShadow = true;
            this.btnNuevaNomina.UseVisualStyleBackColor = false;
            this.btnNuevaNomina.Click += new System.EventHandler(this.btnNuevaNomina_Click);
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
            this.panel4.Controls.Add(this.panel10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 69);
            this.panel4.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Silver;
            this.panel10.Controls.Add(this.dtpFechaFin);
            this.panel10.Controls.Add(this.dtpFechaInicio);
            this.panel10.Controls.Add(this.rbPeriodo);
            this.panel10.Controls.Add(this.rbClaveNomina);
            this.panel10.Controls.Add(this.btnBuscar);
            this.panel10.Controls.Add(this.txtBusq);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1008, 69);
            this.panel10.TabIndex = 2;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(507, 36);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(122, 25);
            this.dtpFechaFin.TabIndex = 61;
            this.dtpFechaFin.Enter += new System.EventHandler(this.dtpFechaInicio_Enter);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(379, 36);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(122, 25);
            this.dtpFechaInicio.TabIndex = 60;
            this.dtpFechaInicio.Enter += new System.EventHandler(this.dtpFechaInicio_Enter);
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbPeriodo.AutoSize = true;
            this.rbPeriodo.Location = new System.Drawing.Point(379, 9);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(152, 24);
            this.rbPeriodo.TabIndex = 59;
            this.rbPeriodo.TabStop = true;
            this.rbPeriodo.Text = "Período de nómina";
            this.rbPeriodo.UseVisualStyleBackColor = true;
            // 
            // rbClaveNomina
            // 
            this.rbClaveNomina.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbClaveNomina.AutoSize = true;
            this.rbClaveNomina.Location = new System.Drawing.Point(70, 9);
            this.rbClaveNomina.Name = "rbClaveNomina";
            this.rbClaveNomina.Size = new System.Drawing.Size(139, 24);
            this.rbClaveNomina.TabIndex = 57;
            this.rbClaveNomina.TabStop = true;
            this.rbClaveNomina.Text = "Clave de Nómina";
            this.rbClaveNomina.UseVisualStyleBackColor = true;
            this.rbClaveNomina.CheckedChanged += new System.EventHandler(this.rbTicket_CheckedChanged);
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
            this.btnBuscar.Location = new System.Drawing.Point(690, 36);
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
            // txtBusq
            // 
            this.txtBusq.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBusq.Location = new System.Drawing.Point(70, 36);
            this.txtBusq.Name = "txtBusq";
            this.txtBusq.Size = new System.Drawing.Size(215, 25);
            this.txtBusq.TabIndex = 13;
            this.txtBusq.TabStop = false;
            this.txtBusq.Enter += new System.EventHandler(this.txtFolioBusq_Enter);
            this.txtBusq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
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
            this.pictureBox1.Location = new System.Drawing.Point(857, 9);
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
            this.label42.Size = new System.Drawing.Size(196, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Nómina";
            // 
            // MenuStripNomina
            // 
            this.MenuStripNomina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.MenuStripNomina.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.MenuStripNomina.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsm_NominaAdm,
            this.toolsm_NominaFiscal});
            this.MenuStripNomina.Name = "MenuStripCaja";
            this.MenuStripNomina.Size = new System.Drawing.Size(194, 56);
            // 
            // toolsm_NominaAdm
            // 
            this.toolsm_NominaAdm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.toolsm_NominaAdm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsm_NominaAdm.Name = "toolsm_NominaAdm";
            this.toolsm_NominaAdm.Size = new System.Drawing.Size(193, 26);
            this.toolsm_NominaAdm.Tag = "1";
            this.toolsm_NominaAdm.Text = "Administrativa";
            this.toolsm_NominaAdm.Click += new System.EventHandler(this.toolsm_Click);
            // 
            // toolsm_NominaFiscal
            // 
            this.toolsm_NominaFiscal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(114)))));
            this.toolsm_NominaFiscal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsm_NominaFiscal.Name = "toolsm_NominaFiscal";
            this.toolsm_NominaFiscal.Size = new System.Drawing.Size(193, 26);
            this.toolsm_NominaFiscal.Tag = "2";
            this.toolsm_NominaFiscal.Text = "Fiscal";
            this.toolsm_NominaFiscal.Click += new System.EventHandler(this.toolsm_Click);
            // 
            // frmNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmNomina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNomina_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).EndInit();
            this.panel7.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MenuStripNomina.ResumeLayout(false);
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
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private System.Windows.Forms.TextBox txtBusq;
        private System.Windows.Forms.Panel PanelMenu;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnSalir;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataGridView dgvNomina;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbPeriodo;
        private System.Windows.Forms.RadioButton rbClaveNomina;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnNuevaNomina;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNomina;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoNomina;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveNomina;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnReporteSaldos;
        private System.Windows.Forms.ContextMenuStrip MenuStripNomina;
        private System.Windows.Forms.ToolStripMenuItem toolsm_NominaAdm;
        private System.Windows.Forms.ToolStripMenuItem toolsm_NominaFiscal;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnReporteDetalle;
    }
}

