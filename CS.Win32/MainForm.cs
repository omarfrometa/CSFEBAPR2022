using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS.Win32
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            lblMsg.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oForm = new UserForm();
            oForm.MdiParent = this;
            oForm.Show();

            newToolStripButton.Enabled = true;
            saveToolStripButton.Enabled = true;
            toolStripButton1.Enabled = true;
        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oForm = new CountryForm();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oForm = new PlaceBirthForm();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Estas seguro que deseas salir del sistema?", "CONSTRUCCION DE SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dr == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }   
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void iconosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            var formControl = (Form)ActiveMdiChild;
            if(formControl != null)
            {
                ((MyInterface)formControl).New();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            var formControl = (Form)ActiveMdiChild;
            if (formControl != null)
            {
                ((MyInterface)formControl).Save();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var formControl = (Form)ActiveMdiChild;
            if (formControl != null)
            {
                ((MyInterface)formControl).Remove();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var formControl = (Form)ActiveMdiChild;
            if (formControl != null)
            {
                ((MyInterface)formControl).Search(txtSearch.Text);
            }
        }
    }
}
