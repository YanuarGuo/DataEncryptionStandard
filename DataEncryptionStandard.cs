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
        public new string? Padding { get; set; }

        public DataEncryptionStandard()
        {
            InitializeComponent();
        }

        private void BtnConfirmAll_Click(object sender, EventArgs e)
        {
            Padding = CbPadding.Text;
            Key = TxtKey.Text;
            MessageBox.Show("Key / Padding confirmed!");
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            IV = TxtIVEnc.Text;
            if (
                string.IsNullOrEmpty(Key)
                || string.IsNullOrEmpty(IV)
                || string.IsNullOrEmpty(Padding)
            )
            {
                MessageBox.Show("Key / IV / Padding cannot be null or empty!");
                return;
            }

            string encrypted = Encrypt(TxtPlain.Text, Key, IV, Padding, CbOutputFormat.Text);
            TxtEncrypted.Text = encrypted;
            MessageBox.Show("Encrypted text: " + encrypted);
        }

        private void BtnClearEnc_Click(object sender, EventArgs e)
        {
            TxtPlain.Text = "";
            TxtIVEnc.Text = "";
            CbOutputFormat.SelectedIndex = -1;
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            IV = TxtIVDec.Text;
            if (
                string.IsNullOrEmpty(Key)
                || string.IsNullOrEmpty(IV)
                || string.IsNullOrEmpty(Padding)
            )
            {
                MessageBox.Show("Key / IV / Padding cannot be null or empty!");
                return;
            }
            string decrypted = Decrypt(TxtEncrypted.Text, Key, IV, Padding, CbInputFormat.Text);
            TxtPlain.Text = decrypted;
            MessageBox.Show("Decrypted text: " + decrypted);
        }

        private void BtnClearDec_Click(object sender, EventArgs e)
        {
            TxtEncrypted.Text = "";
            TxtIVDec.Text = "";
            CbInputFormat.SelectedIndex = -1;
        }

        public static string Decrypt(
            string cipherText,
            string Key,
            string IV,
            string Padding,
            string InputFormat
        )
        {
            using var provider = DES.Create();

            byte[] keyBytes = PadKeyTo8Bytes(Encoding.ASCII.GetBytes(Key), Padding);
            byte[] ivBytes = Encoding.ASCII.GetBytes(IV);

            if (ivBytes.Length != 8)
                throw new ArgumentException("IV must be exactly 8 bytes long");

            provider.Key = keyBytes;
            provider.IV = ivBytes;
            provider.Padding = PaddingMode.PKCS7;

            // Convert input based on format
            byte[] cipherBytes =
                InputFormat == "HEX"
                    ? ConvertHexToBytes(cipherText)
                    : Convert.FromBase64String(cipherText);

            using var ms = new MemoryStream();
            using (
                var cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Write)
            )
            {
                cs.Write(cipherBytes, 0, cipherBytes.Length);
                cs.FlushFinalBlock();
            }

            return Encoding.ASCII.GetString(ms.ToArray());
        }

        public static string Encrypt(
            string plainText,
            string Key,
            string IV,
            string Padding,
            string OutputFormat
        )
        {
            using var provider = DES.Create();

            byte[] keyBytes = PadKeyTo8Bytes(Encoding.ASCII.GetBytes(Key), Padding);
            byte[] ivBytes = Encoding.ASCII.GetBytes(IV);

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

            byte[] encryptedBytes = ms.ToArray();

            return OutputFormat == "HEX"
                ? BitConverter.ToString(encryptedBytes).Replace("-", "")
                : Convert.ToBase64String(encryptedBytes);
        }

        private static byte[] ConvertHexToBytes(string hex)
        {
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Invalid HEX input length.");

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);

            return bytes;
        }

        private static byte[] PadKeyTo8Bytes(byte[] Key, string Padding)
        {
            int keyLength = Key.Length;

            if (keyLength > 8)
                throw new ArgumentException("Key must be at most 8 bytes long");

            int padLength = 8 - keyLength;

            if (Padding == "PKCS7")
            {
                byte padByte = (byte)padLength;
                Debug.WriteLine($"Padding Key with {padLength} bytes of {padByte} (PKCS7)");
                return Key.Concat(Enumerable.Repeat(padByte, padLength)).ToArray();
            }
            else if (Padding == "ZeroPadding")
            {
                Debug.WriteLine($"Padding Key with {padLength} bytes of 0x00 (ZeroPadding)");
                return Key.Concat(new byte[padLength]).ToArray();
            }
            else
            {
                throw new ArgumentException(
                    "Invalid padding type. Choose 'PKCS7' or 'ZeroPadding'."
                );
            }
        }
    }
}
