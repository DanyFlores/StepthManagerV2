namespace StephManager
{
    partial class frmCatalogoWeb
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
            this.dgvCatalogoWeb = new System.Windows.Forms.DataGridView();
            this.IDImagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagImagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombrePagina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.Aprobada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TipoArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnAprobar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnSalir = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnEliminar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnModificar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelarBusq = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.btnBuscar = new CreativaSL.LibControls.WinForms.Button_Creativa();
            this.txtTagBusqueda = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoWeb)).BeginInit();
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
            this.panel12.Controls.Add(this.dgvCatalogoWeb);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1008, 478);
            this.panel12.TabIndex = 2;
            // 
            // dgvCatalogoWeb
            // 
            this.dgvCatalogoWeb.AllowUserToAddRows = false;
            this.dgvCatalogoWeb.AllowUserToDeleteRows = false;
            this.dgvCatalogoWeb.AllowUserToOrderColumns = true;
            this.dgvCatalogoWeb.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCatalogoWeb.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvCatalogoWeb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatalogoWeb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDImagen,
            this.IDSucursal,
            this.TagImagen,
            this.Descripcion,
            this.NombreServicio,
            this.Alt,
            this.Title,
            this.NombreArchivo,
            this.NombrePagina,
            this.Imagen,
            this.Aprobada,
            this.TipoArchivo,
            this.IDProducto});
            this.dgvCatalogoWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCatalogoWeb.Location = new System.Drawing.Point(0, 0);
            this.dgvCatalogoWeb.Name = "dgvCatalogoWeb";
            this.dgvCatalogoWeb.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCatalogoWeb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogoWeb.Size = new System.Drawing.Size(1008, 478);
            this.dgvCatalogoWeb.TabIndex = 12;
            // 
            // IDImagen
            // 
            this.IDImagen.DataPropertyName = "IDImagen";
            this.IDImagen.HeaderText = "IDImagen";
            this.IDImagen.Name = "IDImagen";
            this.IDImagen.ReadOnly = true;
            this.IDImagen.Visible = false;
            // 
            // IDSucursal
            // 
            this.IDSucursal.DataPropertyName = "IDSucursal";
            this.IDSucursal.HeaderText = "IDSucursal";
            this.IDSucursal.Name = "IDSucursal";
            this.IDSucursal.ReadOnly = true;
            this.IDSucursal.Visible = false;
            // 
            // TagImagen
            // 
            this.TagImagen.DataPropertyName = "Tag";
            this.TagImagen.HeaderText = "Tag";
            this.TagImagen.Name = "TagImagen";
            this.TagImagen.ReadOnly = true;
            this.TagImagen.Width = 330;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 400;
            // 
            // NombreServicio
            // 
            this.NombreServicio.DataPropertyName = "NombreServicio";
            this.NombreServicio.HeaderText = "Nombre Servicio";
            this.NombreServicio.Name = "NombreServicio";
            this.NombreServicio.ReadOnly = true;
            this.NombreServicio.Width = 250;
            // 
            // Alt
            // 
            this.Alt.DataPropertyName = "Alt";
            this.Alt.HeaderText = "Alt";
            this.Alt.Name = "Alt";
            this.Alt.ReadOnly = true;
            this.Alt.Width = 200;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 200;
            // 
            // NombreArchivo
            // 
            this.NombreArchivo.DataPropertyName = "NombreArchivo";
            this.NombreArchivo.HeaderText = "NombreArchivo";
            this.NombreArchivo.Name = "NombreArchivo";
            this.NombreArchivo.ReadOnly = true;
            this.NombreArchivo.Width = 200;
            // 
            // NombrePagina
            // 
            this.NombrePagina.DataPropertyName = "NombrePagina";
            this.NombrePagina.HeaderText = "NombrePagina";
            this.NombrePagina.Name = "NombrePagina";
            this.NombrePagina.ReadOnly = true;
            this.NombrePagina.Width = 200;
            // 
            // Imagen
            // 
            this.Imagen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Imagen.DataPropertyName = "ImagenDGV";
            this.Imagen.HeaderText = "Imagen";
            this.Imagen.Name = "Imagen";
            this.Imagen.ReadOnly = true;
            this.Imagen.Width = 64;
            // 
            // Aprobada
            // 
            this.Aprobada.DataPropertyName = "PublicarImagen";
            this.Aprobada.HeaderText = "Aprobada";
            this.Aprobada.Name = "Aprobada";
            this.Aprobada.ReadOnly = true;
            // 
            // TipoArchivo
            // 
            this.TipoArchivo.DataPropertyName = "TipoArchivo";
            this.TipoArchivo.HeaderText = "TipoArchivo";
            this.TipoArchivo.Name = "TipoArchivo";
            this.TipoArchivo.ReadOnly = true;
            this.TipoArchivo.Visible = false;
            // 
            // IDProducto
            // 
            this.IDProducto.DataPropertyName = "IDProducto";
            this.IDProducto.HeaderText = "IDProducto";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.ReadOnly = true;
            this.IDProducto.Visible = false;
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
            this.btnAprobar.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0000_subir_imagen_a;
            this.btnAprobar.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0000_subir_imagen;
            this.btnAprobar.ImagePressed = null;
            this.btnAprobar.ImageSize = new System.Drawing.Size(44, 44);
            this.btnAprobar.KeyButton = System.Windows.Forms.Keys.F1;
            this.btnAprobar.KeyButtonView = false;
            this.btnAprobar.Location = new System.Drawing.Point(651, 7);
            this.btnAprobar.ModeGradient = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAprobar.MouseOverColor = System.Drawing.Color.Red;
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.OffsetPressedContent = true;
            this.btnAprobar.Size = new System.Drawing.Size(80, 70);
            this.btnAprobar.TabIndex = 21;
            this.btnAprobar.Text = "Subir Imagen";
            this.btnAprobar.TextDropShadow = true;
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
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
            this.btnEliminar.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0004_eliminar_a;
            this.btnEliminar.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0004_eliminar;
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
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.btnModificar.ImageMouseOver = global::StephManager.Properties.Resources._0000s_0000s_0005_modificar_a;
            this.btnModificar.ImageNormal = global::StephManager.Properties.Resources._0000s_0000s_0005_modificar;
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
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnCancelarBusq);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Controls.Add(this.txtTagBusqueda);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1008, 50);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(210, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 37);
            this.label1.TabIndex = 59;
            this.label1.Text = "Tag";
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
            this.btnCancelarBusq.Location = new System.Drawing.Point(769, 15);
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
            this.btnBuscar.Location = new System.Drawing.Point(670, 15);
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
            this.txtTagBusqueda.Location = new System.Drawing.Point(292, 15);
            this.txtTagBusqueda.MaxLength = 20;
            this.txtTagBusqueda.Name = "txtTagBusqueda";
            this.txtTagBusqueda.Size = new System.Drawing.Size(377, 25);
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
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(21, 9);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(341, 55);
            this.label42.TabIndex = 24;
            this.label42.Text = "Catálogo Web";
            // 
            // frmCatalogoWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 688);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 726);
            this.Name = "frmCatalogoWeb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steph v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCatalogoWeb_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogoWeb)).EndInit();
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
        private CreativaSL.LibControls.WinForms.Button_Creativa btnModificar;
        private System.Windows.Forms.Panel panel12;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnBuscar;
        private System.Windows.Forms.TextBox txtTagBusqueda;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnCancelarBusq;
        private System.Windows.Forms.DataGridView dgvCatalogoWeb;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnEliminar;
        private System.Windows.Forms.Label label1;
        private CreativaSL.LibControls.WinForms.Button_Creativa btnAprobar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombrePagina;
        private System.Windows.Forms.DataGridViewImageColumn Imagen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aprobada;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
    }
}

