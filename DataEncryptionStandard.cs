using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DataEncryptionStandard
{
    public partial class DataEncryptionStandard : Form
    {
        public string? Key { get; set; }

        public DataEncryptionStandard()
        {
            InitializeComponent();
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            if (Key == null)
            {
                MessageBox.Show("Key cannot be null!");
                return;
            }
            string encrypted = Encrypt(TxtPlain.Text, Key);
            TxtEncrypted.Text = encrypted;
            MessageBox.Show("Encrypted text: " + encrypted);
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            if (Key == null)
            {
                MessageBox.Show("Key cannot be null.");
                return;
            }
            string decrypted = Decrypt(TxtEncrypted.Text, Key);
            TxtPlain.Text = decrypted;
            MessageBox.Show("Decrypted text: " + decrypted);
        }

        public static string Encrypt(string plainText, string key)
        {
            using var provider = DES.Create();
            provider.Key = Encoding.UTF8.GetBytes(key);
            provider.IV = Encoding.UTF8.GetBytes(key);

            using var ms = new MemoryStream();
            using (
                var cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write)
            )
            {
                using var sw = new StreamWriter(cs);
                sw.Write(plainText);
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipherText, string key)
        {
            using var provider = DES.Create();
            provider.Key = Encoding.UTF8.GetBytes(key.PadRight(8).Substring(0, 8));
            provider.IV = Encoding.UTF8.GetBytes(key.PadRight(8).Substring(0, 8));

            using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using var cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        private void BtnKey_Click(object sender, EventArgs e)
        {
            Key = TxtKey.Text;
            MessageBox.Show("Key Added!");
        }
    }
}
