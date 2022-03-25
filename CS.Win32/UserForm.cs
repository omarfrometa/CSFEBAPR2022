using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS.BO;

namespace CS.Win32
{
    public partial class UserForm : Form, MyInterface
    {
        CSFEBAPR2022Entities db = new CSFEBAPR2022Entities();
        public bool Adding { get; set; }
        public UserForm()
        {
            InitializeComponent();

            getRecords();
            getCountries();
            getProvinces();

            Adding = false;
        }

        private void getProvinces()
        {
            var provinces = db.PlaceBirth.Where(x=> x.Enabled).ToList();
            cbPlaceOfBirth.DataSource = provinces;
            cbPlaceOfBirth.DisplayMember = "Name";
            cbPlaceOfBirth.ValueMember = "Id";
        }

        private void getCountries()
        {
            var countries = db.Country.Where(x => x.Enabled).ToList();
            cbCountry.DataSource = countries;
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "Id";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //btnNew.Enabled = true;
            //btnSave.Enabled = false;
            //btnDelete.Enabled = false;
            gbUserInfo.Enabled = false;
            Adding = false;
            clearFields();
            getRecords();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void save()
        {
            var user = new User();
            var profile = new UserProfile();
            if (Adding)
            {
                user.Id = Guid.Parse(txtID.Text);
                user.Password = txtPassword.Text;
                user.CreatedDate = DateTime.Now;

                profile.Id = Guid.NewGuid();
            }
            else
            {
                Guid UserId = Guid.Parse(txtID.Text);
                user = db.User.FirstOrDefault(x => x.Id == UserId);

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    user.Password = txtPassword.Text;
                }

                profile = db.UserProfile.FirstOrDefault(x=> x.UserId == user.Id);
            }

            user.Username = txtUsername.Text;
            user.DisplayName = txtDisplayName.Text;
            user.Email = txtEmail.Text;
            user.Enabled = chkEnabled.Checked;

            profile.FirstName = txtFirstName.Text;
            profile.LastName = txtLastName.Text;
            profile.DOB = dtpDOB.Value;
            profile.PlaceBirthId = Convert.ToInt32(cbPlaceOfBirth.SelectedValue);
            profile.CountryId = Convert.ToInt32(cbCountry.SelectedValue);
            profile.Gender = rbMale.Checked ? "M" : "F";
            profile.AddressLine1 = txtAddress1.Text;
            profile.Phone = txtPhone.Text;

            if (Adding)
            {
                db.Entry<User>(user).State = EntityState.Added;
                user.UserProfile.Add(profile);
            }
            else
            {
                db.Entry<UserProfile>(profile).State = EntityState.Modified;
            }
            
            db.SaveChanges();

            gbUserInfo.Enabled = false;
            //btnNew.Enabled = true;
            //btnSave.Enabled = false;
            //btnDelete.Enabled = false;

            getRecords();
            clearFields();

            MessageBox.Show($"Usuario {(Adding ? "Agregado." : "Actualizado")}", "CONSTRUCCION DE SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void getRecords(string searchText = "")
        {
            using (var ctx = new CSFEBAPR2022Entities())
            {
                var users = ctx.User.ToList();

                if (!string.IsNullOrEmpty(searchText))
                {
                    users = users.Where(x => x.Username.Contains(searchText)).ToList();
                }

                dgvRecords.DataSource = users;

                dgvRecords.Columns["Id"].Visible = false;
                dgvRecords.Columns["Password"].Visible = false;
                dgvRecords.Columns["Picture"].Visible = false;
                dgvRecords.Columns["UserProfile"].Visible = false;
                dgvRecords.Columns["Username"].HeaderText = "Usuario";
                dgvRecords.Columns["Enabled"].HeaderText = "Activo";
                dgvRecords.Columns["DisplayName"].HeaderText = "Nombre a Mostrar";
                dgvRecords.Columns["CreatedDate"].HeaderText = "Fecha Creación";
            }
        }

        private void clearFields()
        {
            txtID.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            rbMale.Checked = true;
            rbFemale.Checked = false;
            dtpDOB.Value = DateTime.Now.AddYears(-18);
            cbPlaceOfBirth.SelectedIndex = 0;
            cbCountry.SelectedIndex = 0;
            txtAddress1.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDisplayName.Text = string.Empty;
            txtCreatedDate.Text = string.Empty;
            chkEnabled.Checked = false;
            //txtSearch.Text = string.Empty;

            gbUserInfo.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvRecords.Rows[e.RowIndex];
                var ID = row.Cells[0].Value.ToString();

                getRecordById(ID);
            }
        }

        private void getRecordById(string Id)
        {
            //Convert String to Guid
            Guid UserId = Guid.Parse(Id);

            using (var ctx = new CSFEBAPR2022Entities())
            {
                //Loading User by Id
                var user = ctx.User.FirstOrDefault(x => x.Id == UserId);
                if (user != null)
                {
                    //Loading UserProfile by UserId
                    var profile = ctx.UserProfile.FirstOrDefault(x => x.UserId == user.Id);

                    Adding = false;

                    txtID.Text = user.Id.ToString();
                    txtUsername.Text = user.Username;
                    txtFirstName.Text = profile.FirstName;
                    txtLastName.Text = profile.LastName;

                    if (profile.Gender == "M")
                    {
                        rbMale.Checked = true;
                        rbFemale.Checked = false;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                        rbMale.Checked = false;
                    }

                    dtpDOB.Value = profile.DOB;
                    cbPlaceOfBirth.SelectedValue = profile.PlaceBirthId;
                    cbCountry.SelectedValue = profile.CountryId;
                    txtAddress1.Text = profile.AddressLine1;
                    txtPhone.Text = profile.Phone;
                    txtEmail.Text = user.Email;
                    txtDisplayName.Text = user.DisplayName;
                    txtCreatedDate.Text = user.CreatedDate.ToString();
                    chkEnabled.Checked = user.Enabled;

                    gbUserInfo.Enabled = true;
                    //btnNew.Enabled = false;
                    //btnSave.Enabled = true;
                    //btnDelete.Enabled = true;
                }
            }
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            chkEnabled.Text = chkEnabled.Checked ? "Activo" : "Inactivo";
        }

        public void New()
        {
            txtID.Text = Guid.NewGuid().ToString();
            txtCreatedDate.Text = DateTime.Now.ToString();

            gbUserInfo.Enabled = true;
            //btnNew.Enabled = false;
            //btnSave.Enabled = true;

            Adding = true;
        }

        public void Save()
        {
            save();
        }

        public void Remove()
        {
            DialogResult dr = MessageBox.Show("Estas seguro que deseas eliminar este registro?", "CONSTRUCCION DE SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dr == DialogResult.Yes)
            {
                Guid UserId = Guid.Parse(txtID.Text);
                var user = db.User.FirstOrDefault(x => x.Id == UserId);
                if (user != null)
                {
                    var profile = db.UserProfile.FirstOrDefault(x => x.UserId == user.Id);

                    db.UserProfile.Remove(profile);
                    db.SaveChanges();

                    db.User.Remove(user);

                    var rUser = db.SaveChanges() > 0;
                    if (rUser)
                    {
                        getRecords();
                        clearFields();

                        //btnNew.Enabled = true;
                        //btnSave.Enabled = false;
                        //btnDelete.Enabled = false;
                        gbUserInfo.Enabled = false;
                        Adding = false;
                    }
                }
            }
        }

        public void Search(string input)
        {
            getRecords(input);
        }
    }
}
