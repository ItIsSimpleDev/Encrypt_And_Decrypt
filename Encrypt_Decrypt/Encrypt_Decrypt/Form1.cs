using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encrypt_Decrypt
{
    public partial class Form1 : Form
    {
        private static string key;
        public Form1()
        {
            InitializeComponent();
            key = Encrypt_Decrypt.generatePrivateKey();
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string inputValue = inputTextBox.Text;
                if (string.IsNullOrEmpty(inputValue)) return;
                encryptedTextBox.Text = Encrypt_Decrypt.encryptStringWithKey(inputValue, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string decryptedValue = encryptedTextBox.Text;
                if (string.IsNullOrEmpty(decryptedValue)) return;
                decrpytedTextBox.Text = Encrypt_Decrypt.decryptStringWithKey(decryptedValue, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
        }

    }
}
