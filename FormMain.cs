using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Signature
{
    public partial class FormMain : Form
    {
        private static string filePath = "";
        private static string initials = "";

        public FormMain()
        {
            InitializeComponent();
        }

        private void panelDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                labelDragDrop.Text = "Отпустите мышь";
               
            }
        }

        private void panelDragDrop_DragLeave(object sender, EventArgs e)
        {
            labelDragDrop.Text = "Перетащите файл сюда";
        }

        private void panelDragDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxFilePath.Text = file[0];
        }

        private void textBoxFilePath_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            if(dlg.ShowDialog() == DialogResult.OK)
                textBoxFilePath.Text = dlg.FileName;
        }

        private void buttonSigned_Click(object sender, EventArgs e)
        {
            initials = textBoxInitials.Text;
            filePath = textBoxFilePath.Text;
            string dirPath = filePath.Substring(0, filePath.LastIndexOf('\\') + 1);
            string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            fileName = fileName.Substring(0, fileName.LastIndexOf('.') + 0);

            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
            if (fileInfo.Length > 2147483648)
            {
                MessageBox.Show("Размер файла привышает 2 Гб", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //TODO::
            if (initials.Length > 0 && filePath.Length > 0)
            {

                RSA_Encrypt.KeyPair kp = Settings.GetInitialsKey(@"Initials\" + initials);              

                byte[] bytesFile = System.IO.File.ReadAllBytes(filePath);
                byte[] bytesInitials = Encoding.ASCII.GetBytes(initials);

                byte[] bytesFinals = bytesFile.Union(bytesInitials).ToArray();

                byte[] encrypted = RSA_Encrypt.RSA.EncryptBytes(Settings.GetHashSignature(bytesFinals), kp.public_);

                Console.WriteLine("\nSIG 1:" + Encoding.ASCII.GetString(encrypted));

                if (Settings.CreateFileSignature(fileName, dirPath, encrypted))
                {
                    MessageBox.Show("Файл успешно подписан!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Заполните все текстовы поля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCheckSigned_Click(object sender, EventArgs e)
        {
            initials = textBoxInitials.Text;
            filePath = textBoxFilePath.Text;
            string dirPath = filePath.Substring(0, filePath.LastIndexOf('\\') + 1);
            string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            fileName = fileName.Substring(0, fileName.LastIndexOf('.') + 0);

            if (initials.Length > 0 && filePath.Length > 0)
            {

                RSA_Encrypt.KeyPair kp = Settings.GetInitialsKey(@"Initials\" + initials);

                byte[] bytesFile = System.IO.File.ReadAllBytes(filePath);
                byte[] bytesInitials = Encoding.ASCII.GetBytes(initials);
                byte[] bytesFinals = bytesFile.Union(bytesInitials).ToArray();

                if(!System.IO.File.Exists(dirPath + fileName + ".sig"))
                {
                    MessageBox.Show("Отсутствует электронная подпись", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                   
                byte[] signatures = Settings.GetFileSignature(dirPath + fileName + ".sig");

                byte[] decrypted = RSA_Encrypt.RSA.DecryptBytes(signatures, kp.private_);

                Console.WriteLine("\nSIG 2:" + Encoding.ASCII.GetString(signatures));

                Console.WriteLine("\nFINAL: " + Encoding.ASCII.GetString(bytesFinals));

                Console.WriteLine("\nDecrypted: " + Encoding.ASCII.GetString(decrypted));

                if(Encoding.ASCII.GetString(Settings.GetHashSignature(bytesFinals)) == Encoding.ASCII.GetString(decrypted))
                {
                    MessageBox.Show("Электронная подпись является действительной", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                else
                {
                    MessageBox.Show("Электронная подпись не действительна", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCreateUser_Click(object sender, EventArgs e)
        {
            FormCreateInitials formCreateInitials = new FormCreateInitials(textBoxInitials);
            formCreateInitials.Show();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            textBoxInitials.Items.Clear();
            Settings.GetDirInitials(textBoxInitials);
        }

        private void textBoxInitials_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDeleteSignature.Enabled = !string.IsNullOrEmpty(textBoxInitials.Text);
        }

        private void buttonDeleteSignature_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить электронную подпись " + textBoxInitials.Text + " ?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                System.IO.File.Delete(@"Initials\" + textBoxInitials.Text);
                MessageBox.Show("Электронную подпись " + textBoxInitials.Text + " удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonDeleteSignature.Enabled = false;
                textBoxInitials.Items.Clear();
                Settings.GetDirInitials(textBoxInitials);
            }
            
            
        }
    }
}
