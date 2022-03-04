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
    public partial class CountryForm : Form
    {
        CSFEBAPR2022Entities db = new CSFEBAPR2022Entities();
        List<string> msgList = new List<string>();
        public CountryForm()
        {
            InitializeComponent();

            getRecords();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            msgList = new List<string>();
            if (formIsValid())
            {
                save();
            }
            else
            {
                foreach (var item in msgList)
                {
                    MessageBox.Show(item);
                }
            }
        }

        private bool formIsValid()
        {
            var result = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msgList.Add("El campo nombre es requerido.");
                result = false;
            }

            return result;
        }

        private void save()
        {
            var country = new Country();
            country.Name = txtName.Text;
            country.Description = txtDescription.Text;
            country.Enabled = chkEnabled.Checked;
            country.CreatedDate = DateTime.Now;

            db.Country.Add(country);
            var result = db.SaveChanges() > 0;

            if (result)
            {
                clearfields();
                getRecords();

                MessageBox.Show("Pais Creado!");
            }
        }

        private void clearfields()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkEnabled.Checked = false;
        }

        private void getRecords()
        {
            var countries = db.Country.ToList();

            dgvRecords.DataSource = countries;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearfields();
        }
    }
}
