
namespace CS.Win32
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCountry = new System.Windows.Forms.Button();
            this.btnPlaceBirth = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCountry
            // 
            this.btnCountry.Location = new System.Drawing.Point(58, 117);
            this.btnCountry.Name = "btnCountry";
            this.btnCountry.Size = new System.Drawing.Size(198, 150);
            this.btnCountry.TabIndex = 0;
            this.btnCountry.Text = "PAISES";
            this.btnCountry.UseVisualStyleBackColor = true;
            this.btnCountry.Click += new System.EventHandler(this.btnCountry_Click);
            // 
            // btnPlaceBirth
            // 
            this.btnPlaceBirth.Location = new System.Drawing.Point(333, 117);
            this.btnPlaceBirth.Name = "btnPlaceBirth";
            this.btnPlaceBirth.Size = new System.Drawing.Size(198, 150);
            this.btnPlaceBirth.TabIndex = 1;
            this.btnPlaceBirth.Text = "LUGARES DE NACIMIENTO";
            this.btnPlaceBirth.UseVisualStyleBackColor = true;
            this.btnPlaceBirth.Click += new System.EventHandler(this.btnPlaceBirth_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(58, 306);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(198, 150);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "USUARIOS";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "ADMINISTRACION";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 515);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnPlaceBirth);
            this.Controls.Add(this.btnCountry);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCountry;
        private System.Windows.Forms.Button btnPlaceBirth;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Label label1;
    }
}