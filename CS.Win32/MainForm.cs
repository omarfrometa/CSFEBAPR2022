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
        }

        private void btnCountry_Click(object sender, EventArgs e)
        {
            CountryForm _country = new CountryForm();
            _country.ShowDialog();
        }

        private void btnPlaceBirth_Click(object sender, EventArgs e)
        {
            PlaceBirthForm _placeBirthForm = new PlaceBirthForm();
            _placeBirthForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserForm _users = new UserForm();
            _users.Show();
        }
    }
}
