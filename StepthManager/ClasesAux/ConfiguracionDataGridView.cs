using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager.ClasesAux
{
    public class ConfiguracionDataGridView
    {
        public void AddColumnsDataGridView(DataGridView dgv, int columnas, object[,] propiedades)
        {
            try
            {
                DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                dgv.RowHeadersWidth = 25;
                dgv.ColumnHeadersHeight = 25;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToResizeColumns = false;
                dgv.AllowUserToResizeRows = false;
                dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
                dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
                dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, FontStyle.Regular);
                dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
                dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

                for (int i = 0; i < columnas; i++)
                {
                    switch ((int)propiedades[i, 3])
                    {
                        case 1: DataGridViewTextBoxColumn columnT = new DataGridViewTextBoxColumn();
                            columnT.CellTemplate = new DataGridViewTextBoxCell();
                            columnT.HeaderText = propiedades[i, 0].ToString();
                            columnT.DataPropertyName = propiedades[i, 1].ToString();
                            columnT.Name = propiedades[i, 2].ToString();
                            columnT.Visible = (bool)propiedades[i, 4];
                            columnT.Width = (int)propiedades[i, 5];
                            columnT.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnT.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnT.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
                            columnT.HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                            columnT.SortMode = DataGridViewColumnSortMode.NotSortable;
                            columnT.DefaultCellStyle.Format = propiedades[i, 7].ToString();
                            dgv.Columns.Add(columnT);
                            break;
                        case 2: DataGridViewImageColumn columnI = new DataGridViewImageColumn();
                            columnI.CellTemplate = new DataGridViewImageCell();
                            columnI.HeaderText = propiedades[i, 0].ToString();
                            columnI.DataPropertyName = propiedades[i, 1].ToString();
                            columnI.Name = propiedades[i, 2].ToString();
                            columnI.Visible = (bool)propiedades[i, 4];
                            columnI.Width = (int)propiedades[i, 5];
                            columnI.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnI.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnI.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
                            columnI.HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                            columnI.SortMode = DataGridViewColumnSortMode.NotSortable;
                            columnI.DefaultCellStyle.Format = propiedades[i, 7].ToString();
                            dgv.Columns.Add(columnI);
                            break;
                        case 3: DataGridViewCheckBoxColumn columnC = new DataGridViewCheckBoxColumn();
                            columnC.CellTemplate = new DataGridViewCheckBoxCell();
                            columnC.HeaderText = propiedades[i, 0].ToString();
                            columnC.DataPropertyName = propiedades[i, 1].ToString();
                            columnC.Name = propiedades[i, 2].ToString();
                            columnC.Visible = (bool)propiedades[i, 4];
                            columnC.Width = (int)propiedades[i, 5];
                            columnC.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnC.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnC.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
                            columnC.HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                            columnC.SortMode = DataGridViewColumnSortMode.NotSortable;
                            columnC.DefaultCellStyle.Format = propiedades[i, 7].ToString();
                            dgv.Columns.Add(columnC);
                            break;
                        case 4: DataGridViewButtonColumn columnB = new DataGridViewButtonColumn();
                            columnB.CellTemplate = new DataGridViewButtonCell();
                            columnB.HeaderText = propiedades[i, 0].ToString();
                            columnB.DataPropertyName = propiedades[i, 1].ToString();
                            columnB.Name = propiedades[i, 2].ToString();
                            columnB.Visible = (bool)propiedades[i, 4];
                            columnB.Width = (int)propiedades[i, 5];
                            columnB.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnB.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnB.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
                            columnB.HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                            columnB.SortMode = DataGridViewColumnSortMode.NotSortable;
                            columnB.DefaultCellStyle.Format = propiedades[i, 7].ToString();
                            columnB.Text = columnB.HeaderText;
                            columnB.UseColumnTextForButtonValue = true;
                            dgv.Columns.Add(columnB);
                            break;
                    }
                }
                dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddColumnsDataGridViewReadOnly(DataGridView dgv, int columnas, object[,] propiedades)
        {
            try
            {
                DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
                //dgv.RowHeadersWidth = 25;
                //dgv.ColumnHeadersHeight = 25;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToResizeColumns = true;
                dgv.AllowUserToResizeRows = false;
                dgv.AutoSize = true;
                dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
                dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
                dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, FontStyle.Regular);
                dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
                dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                //dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

                for (int i = 0; i < columnas; i++)
                {
                    switch ((int)propiedades[i, 3])
                    {
                        case 1: DataGridViewTextBoxColumn columnT = new DataGridViewTextBoxColumn();
                            columnT.CellTemplate = new DataGridViewTextBoxCell();
                            columnT.HeaderText = propiedades[i, 0].ToString();
                            columnT.DataPropertyName = propiedades[i, 1].ToString();
                            columnT.Name = propiedades[i, 2].ToString();
                            columnT.Visible = (bool)propiedades[i, 4];
                            columnT.Width = (int)propiedades[i, 5];
                            columnT.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnT.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnT.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
                            columnT.HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                            columnT.SortMode = DataGridViewColumnSortMode.NotSortable;
                            columnT.DefaultCellStyle.Format = propiedades[i, 7].ToString();
                            columnT.ReadOnly = (bool)propiedades[i, 8];
                            dgv.Columns.Add(columnT);
                            break;
                        case 2: DataGridViewImageColumn columnI = new DataGridViewImageColumn();
                            columnI.CellTemplate = new DataGridViewImageCell();
                            columnI.HeaderText = propiedades[i, 0].ToString();
                            columnI.DataPropertyName = propiedades[i, 1].ToString();
                            columnI.Name = propiedades[i, 2].ToString();
                            columnI.Visible = (bool)propiedades[i, 4];
                            columnI.Width = (int)propiedades[i, 5];
                            columnI.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnI.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnI.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
                            columnI.HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                            columnI.SortMode = DataGridViewColumnSortMode.NotSortable;
                            columnI.DefaultCellStyle.Format = propiedades[i, 7].ToString();
                            columnI.ReadOnly = (bool)propiedades[i, 8];
                            dgv.Columns.Add(columnI);
                            break;
                        case 3: DataGridViewCheckBoxColumn columnC = new DataGridViewCheckBoxColumn();
                            columnC.CellTemplate = new DataGridViewCheckBoxCell();
                            columnC.HeaderText = propiedades[i, 0].ToString();
                            columnC.DataPropertyName = propiedades[i, 1].ToString();
                            columnC.Name = propiedades[i, 2].ToString();
                            columnC.Visible = (bool)propiedades[i, 4];
                            columnC.Width = (int)propiedades[i, 5];
                            columnC.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnC.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnC.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
                            columnC.HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                            columnC.SortMode = DataGridViewColumnSortMode.NotSortable;
                            columnC.DefaultCellStyle.Format = propiedades[i, 7].ToString();
                            columnC.ReadOnly = (bool)propiedades[i, 8];
                            dgv.Columns.Add(columnC);
                            break;
                        case 4: DataGridViewButtonColumn columnB = new DataGridViewButtonColumn();
                            columnB.CellTemplate = new DataGridViewButtonCell();
                            columnB.HeaderText = propiedades[i, 0].ToString();
                            columnB.DataPropertyName = propiedades[i, 1].ToString();
                            columnB.Name = propiedades[i, 2].ToString();
                            columnB.Visible = (bool)propiedades[i, 4];
                            columnB.Width = (int)propiedades[i, 5];
                            columnB.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnB.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)propiedades[i, 6];
                            columnB.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Regular);
                            columnB.HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                            columnB.SortMode = DataGridViewColumnSortMode.NotSortable;
                            columnB.DefaultCellStyle.Format = propiedades[i, 7].ToString();
                            columnB.ReadOnly = (bool)propiedades[i, 8];
                            columnB.Text = columnB.HeaderText;
                            columnB.UseColumnTextForButtonValue = true;
                            dgv.Columns.Add(columnB);
                            break;
                    }
                }
                dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DataPropertyNameGridHome(int numColum, string nombre, DataGridView actual)
        {
            try
            {
                actual.Columns[numColum].DataPropertyName = nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void HeaderTextGridHome(int numColum, string nombre, DataGridView actual)
        {
            try
            {
                actual.Columns[numColum].HeaderText = nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void NameGridHome(int numColum, string nombre, DataGridView actual)
        {
            try
            {
                actual.Columns[numColum].Name = nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RecorrerForGridHome(List<string> HeaderText, List<string> Name, List<string> DataProperty, DataGridView actual)
        {
            try
            {
                if (HeaderText.Count == Name.Count && Name.Count == DataProperty.Count)
                {
                    if (actual.Columns.Count >= HeaderText.Count)
                    {
                        for (var index = 0; index < actual.Columns.Count; index++)
                        {
                            this.HeaderTextGridHome(index, HeaderText[index], actual);
                            this.NameGridHome(index, Name[index], actual);
                            if (!string.IsNullOrEmpty(DataProperty[index]))
                                this.DataPropertyNameGridHome(index, DataProperty[index], actual);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            try
            {
                return (Image)(new Bitmap(imgToResize, size));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public void ImagenGrid(DataGridView actual, string nameColValue, string nameColImage)
        //{
        //    try
        //    {
        //        foreach (DataGridViewRow Grid in actual.Rows)
        //        {
        //            if (Convert.ToInt32(Grid.Cells[nameColValue].Value) == 1)
        //                Grid.Cells[nameColImage].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status01S.png"), new Size(20, 25));
        //            else if (Convert.ToInt32(Grid.Cells[nameColValue].Value) == 2)
        //                Grid.Cells[nameColImage].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status02S.png"), new Size(20, 25));
        //            else if (Convert.ToInt32(Grid.Cells[nameColValue].Value) == 3)
        //                Grid.Cells[nameColImage].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status03S.png"), new Size(20, 25));
        //            else if (Convert.ToInt32(Grid.Cells[nameColValue].Value) == 4)
        //                Grid.Cells[nameColImage].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status04S.png"), new Size(20, 25));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void ImagenGrid(DataGridView actual, string nameColValueTipo, string nameColImageTipo, string nameColValueEstatus, string nameColImageEstatus)
        //{
        //    try
        //    {

        //        foreach (DataGridViewRow Grid in actual.Rows)
        //        {

        //            switch (Convert.ToInt32(Grid.Cells[nameColValueTipo].Value))
        //            {
        //                case 1: Grid.Cells[nameColImageTipo].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\TipoSolicitud\solicitud01.png"), new Size(20, 20));
        //                    break;
        //                case 2: Grid.Cells[nameColImageTipo].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\TipoSolicitud\solicitud02.png"), new Size(20, 20));
        //                    break;
        //                case 3: Grid.Cells[nameColImageTipo].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\TipoSolicitud\solicitud03.png"), new Size(20, 20));
        //                    break;
        //                case 4: Grid.Cells[nameColImageTipo].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\TipoSolicitud\solicitud04.png"), new Size(20, 20));
        //                    break;
        //                case 5: Grid.Cells[nameColImageTipo].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\TipoSolicitud\solicitud05.png"), new Size(20, 20));
        //                    break;
        //                default: break;
        //            }

        //            switch (Convert.ToInt32(Grid.Cells[nameColValueEstatus].Value))
        //            {
        //                case 1: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status01.png"), new Size(80, 20));
        //                    break;
        //                case 2: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status02.png"), new Size(80, 20));
        //                    break;
        //                case 3: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status03.png"), new Size(80, 20));
        //                    break;
        //                case 4: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status04.png"), new Size(80, 20));
        //                    break;
        //                case 5: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status05.png"), new Size(80, 20));
        //                    break;
        //                case 6: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status06.png"), new Size(80, 20));
        //                    break;
        //                case 7: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status07.png"), new Size(80, 20));
        //                    break;
        //                case 8: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status08.png"), new Size(80, 20));
        //                    break;
        //                case 9: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status09.png"), new Size(80, 20));
        //                    break;
        //                case 10: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status10.png"), new Size(80, 20));
        //                    break;
        //                case 11: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status11.png"), new Size(80, 20));
        //                    break;
        //                case 12: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status12.png"), new Size(80, 20));
        //                    break;
        //                case 13: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status13.png"), new Size(80, 20));
        //                    break;
        //                case 14: Grid.Cells[nameColImageEstatus].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\Status14.png"), new Size(80, 20));
        //                    break;
        //                default: break;
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
