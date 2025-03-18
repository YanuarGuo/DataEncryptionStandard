using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DataEncryptionStandard
{
    public partial class DataEncryptionStandard : Form
    {
        public string? Key { get; set; }
        public string? IV { get; set; }
        public string Padding { get; set; }

        public DataEncryptionStandard()
        {
            InitializeComponent();
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            if (Key == null || IV == null || Padding == null)
            {
                MessageBox.Show("Key and IV cannot be null!");
                return;
            }
            string encrypted = Encrypt(TxtPlain.Text, Key, IV, Padding);
            TxtEncrypted.Text = encrypted;
            MessageBox.Show("Encrypted text: " + encrypted);
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            if (Key == null || IV == null)
            {
                MessageBox.Show("Key and IV cannot be null.");
                return;
            }
            string decrypted = Decrypt(TxtEncrypted.Text, Key, IV);
            TxtPlain.Text = decrypted;
            MessageBox.Show("Decrypted text: " + decrypted);
        }

        public static string Decrypt(string cipherText, string key, string iv)
        {
            using var provider = DES.Create();
            provider.Key = Encoding.UTF8.GetBytes(key.PadRight(8).Substring(0, 8));
            provider.IV = Encoding.UTF8.GetBytes(iv.PadRight(8).Substring(0, 8));

            using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using var cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        public static string Encrypt(string plainText, string key, string iv, string paddingType)
        {
            using var provider = DES.Create();

            byte[] keyBytes = PadKeyTo8Bytes(Encoding.ASCII.GetBytes(key), paddingType);

            byte[] ivBytes = Encoding.ASCII.GetBytes(iv);
            if (ivBytes.Length != 8)
                throw new ArgumentException("IV must be exactly 8 bytes long");

            provider.Key = keyBytes;
            provider.IV = ivBytes;
            provider.Padding = PaddingMode.PKCS7;

            using var ms = new MemoryStream();
            using (
                var cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write)
            )
            {
                byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);
                cs.Write(plainBytes, 0, plainBytes.Length);
                cs.FlushFinalBlock();
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        private static byte[] PadKeyTo8Bytes(byte[] key, string paddingType)
        {
            int keyLength = key.Length;

            if (keyLength > 8)
                throw new ArgumentException("Key must be at most 8 bytes long");

            int padLength = 8 - keyLength;

            if (paddingType == "PKCS7")
            {
                byte padByte = (byte)padLength;
                Debug.WriteLine($"Padding key with {padLength} bytes of {padByte} (PKCS7)");
                return key.Concat(Enumerable.Repeat(padByte, padLength)).ToArray();
            }
            else if (paddingType == "ZeroPadding")
            {
                Debug.WriteLine($"Padding key with {padLength} bytes of 0x00 (ZeroPadding)");
                return key.Concat(new byte[padLength]).ToArray();
            }
            else
            {
                throw new ArgumentException(
                    "Invalid padding type. Choose 'PKCS7' or 'ZeroPadding'."
                );
            }
        }

        private void BtnConfirmAll_Click(object sender, EventArgs e)
        {
            string key = TxtKey.Text;
            string iv = TxtIV.Text;
            string padding = CbPadding.Text;
        }
    }
}
