using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmBase : Form
    {        
        public frmBase()
        {
            InitializeComponent();
        }


        private void frmBase_ResizeBegin(object sender, EventArgs e)
        {
            try
            {
                //SizeXAnterior = this.Size.Width;
                //SizeYAnterior = this.Size.Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBase_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                //int DiferenciaX = 0;
                //int DiferenciaY = 0;
                //DiferenciaX = this.Size.Width - SizeXAnterior;
                //DiferenciaY = this.Size.Height - SizeYAnterior;
                //this.panel3.Size = new Size(this.panel3.Width + (DiferenciaX / 2), this.panel3.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBase_Resize(object sender, EventArgs e)
        {
            try
            {
                int Porcentaje = 39;
                int WidthPanel = (this.Size.Width * Porcentaje) / 100;
                this.panel3.Size = new Size(WidthPanel, this.panel3.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddTheme_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(this.textBox1.Text);
            TreeNode Aux = new TreeNode();        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Nodes.Add(this.textBox2.Text);
        }
    }
}
