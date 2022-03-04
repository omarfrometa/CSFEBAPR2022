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
    public partial class UserForm : Form
    {
        CSFEBAPR2022Entities db = new CSFEBAPR2022Entities();
        public UserForm()
        {
            InitializeComponent();

            getRecords();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                DisplayName = txtDisplayName.Text,
                Email = txtEmail.Text,
                Enabled = true,
                CreatedDate = DateTime.Now
            };
            db.User.Add(user);
            var rUser = db.SaveChanges() > 0;

            if (rUser)
            {
                var profile = new UserProfile();
                profile.Id = Guid.NewGuid();
                profile.UserId = user.Id;
                profile.FirstName = txtFirstName.Text;
                profile.LastName = txtLastName.Text;
                profile.PlaceBirthId = 1; //Convert.ToInt32(cbBirthPlace.SelectedValue);
                profile.CountryId = 1; // Convert.ToInt32(cbCountry.SelectedValue);
                profile.Gender = rbMale.Checked ? "M" : "F";
                profile.AddressLine1 = txtAddress1.Text;
                profile.Phone = txtPhone.Text;

                db.UserProfile.Add(profile);
                var rProfile = db.SaveChanges() > 0;

                if (rProfile)
                {
                    clearFields();
                    getRecords();

                    MessageBox.Show("Usuario Creado.");
                    return;
                }
            }

            MessageBox.Show("Hubo un error en la creacion del usuario.");
        }

        private void getRecords()
        {
            var users = db.User.ToList();
            dgvRecords.DataSource = users;
        }

        private void clearFields()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            dtpDOB.Value = DateTime.Now.AddYears(-18);
            //cbBirthPlace.SelectedIndex = 0;
            //cbCountry.SelectedIndex = 0;
            txtAddress1.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDisplayName.Text = string.Empty;

            txtSearch.Text = string.Empty;

            gbUserInfo.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            gbUserInfo.Enabled = true;
        }
    }
}
