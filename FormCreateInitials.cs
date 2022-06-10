using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signature
{
    public partial class FormCreateInitials : Form
    {
        private ComboBox box;
        public FormCreateInitials(ComboBox box)
        {
            InitializeComponent();
            this.box = box;
            progressBarLoad.Visible = false;
        }

        async private void buttonCreateInitials_Click(object sender, EventArgs e)
        {
            string initials = textBoxInitials.Text;
            if (!string.IsNullOrEmpty(initials))
            {
                buttonCreateInitials.Enabled = false;
                textBoxInitials.Enabled = false;

                progressBarLoad.Visible = true;
                await Task.Run(() =>
                {
                    RSA_Encrypt.KeyPair kp = RSA_Encrypt.RSA.GenerateKeyPair(2048);
                    Settings.CreateInitials(initials, kp);
                });
                MessageBox.Show("Электронная подпись пользователя успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonCreateInitials.Enabled = true;
                textBoxInitials.Enabled = true;
                progressBarLoad.Visible = false;
                box.Items.Clear();
                Settings.GetDirInitials(box);
            }
            else
            {
                MessageBox.Show("Заполните все текстовы поля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
