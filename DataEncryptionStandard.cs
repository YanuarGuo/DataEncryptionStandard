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
        public string? Mode { get; set; }
        public new string? Padding { get; set; }

        public DataEncryptionStandard()
        {
            InitializeComponent();
            GbEnc.Enabled = false;
            GbDec.Enabled = false;
        }

        private void BtnConfirmAll_Click(object sender, EventArgs e)
        {
            Padding = CbPadding.Text;
            Key = TxtKey.Text;
            Mode = CbMode.Text;
            GbEnc.Enabled = true;
            GbDec.Enabled = true;
            if (CbMode.Text == "ECB")
            {
                TxtIVEnc.Text = "";
                TxtIVDec.Text = "";
                TxtIVEnc.Enabled = false;
                TxtIVDec.Enabled = false;
            }
            else
            {
                TxtIVEnc.Enabled = true;
                TxtIVDec.Enabled = true;
            }
            if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Padding))
            {
                MessageBox.Show("Key / Padding cannot be null or empty!");
                return;
            }
            MessageBox.Show("Key / Padding confirmed!");
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            IV = TxtIVEnc.Text;
            if (
                string.IsNullOrEmpty(Key)
                || string.IsNullOrEmpty(Padding)
                || string.IsNullOrEmpty(Mode)
            )
            {
                MessageBox.Show("Key / IV / Padding cannot be null or empty!");
                return;
            }

            string encrypted = Encrypt(TxtPlain.Text, Key, IV, Padding, CbOutputFormat.Text, Mode);
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
                || string.IsNullOrEmpty(Padding)
                || string.IsNullOrEmpty(Mode)
            )
            {
                MessageBox.Show("Key / IV / Padding cannot be null or empty!");
                return;
            }
            string decrypted = Decrypt(
                TxtEncrypted.Text,
                Key,
                IV,
                Padding,
                CbInputFormat.Text,
                Mode
            );
            TxtPlain.Text = decrypted;
            MessageBox.Show("Decrypted text: " + decrypted);
        }

        private void BtnClearDec_Click(object sender, EventArgs e)
        {
            TxtEncrypted.Text = "";
            TxtIVDec.Text = "";
            CbInputFormat.SelectedIndex = -1;
        }

        public static string Encrypt(
            string plainText,
            string Key,
            string IV,
            string Padding,
            string OutputFormat,
            string CipherMode
        )
        {
            using var provider = DES.Create();

            byte[] keyBytes = PadKeyTo8Bytes(Encoding.ASCII.GetBytes(Key), Padding);
            Debug.WriteLine($"Key: {BitConverter.ToString(keyBytes)}");

            provider.Key = keyBytes;

            provider.Mode = CipherMode.ToUpper() switch
            {
                "CBC" => System.Security.Cryptography.CipherMode.CBC,
                "ECB" => System.Security.Cryptography.CipherMode.ECB,
                _ => throw new ArgumentException(
                    "Invalid Cipher Mode. Choose either 'CBC' or 'ECB'."
                ),
            };

            if (provider.Mode == System.Security.Cryptography.CipherMode.CBC)
            {
                byte[] ivBytes = Encoding.ASCII.GetBytes(IV);
                if (ivBytes.Length != 8)
                    throw new ArgumentException("IV must be exactly 8 bytes long");
                provider.IV = ivBytes;
            }

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

        public static string Decrypt(
            string cipherText,
            string Key,
            string IV,
            string Padding,
            string InputFormat,
            string CipherMode
        )
        {
            using var provider = DES.Create();

            byte[] keyBytes = PadKeyTo8Bytes(Encoding.ASCII.GetBytes(Key), Padding);
            Debug.WriteLine($"Key: {BitConverter.ToString(keyBytes)}");

            provider.Key = keyBytes;

            provider.Mode = CipherMode.ToUpper() switch
            {
                "CBC" => System.Security.Cryptography.CipherMode.CBC,
                "ECB" => System.Security.Cryptography.CipherMode.ECB,
                _ => throw new ArgumentException(
                    "Invalid Cipher Mode. Choose either 'CBC' or 'ECB'."
                ),
            };

            if (provider.Mode == System.Security.Cryptography.CipherMode.CBC)
            {
                byte[] ivBytes = Encoding.ASCII.GetBytes(IV);
                if (ivBytes.Length != 8)
                    throw new ArgumentException("IV must be exactly 8 bytes long");
                provider.IV = ivBytes;
            }

            byte[] cipherBytes = InputFormat switch
            {
                "HEX" => Enumerable
                    .Range(0, cipherText.Length / 2)
                    .Select(i => Convert.ToByte(cipherText.Substring(i * 2, 2), 16))
                    .ToArray(),
                "Base64" => Convert.FromBase64String(cipherText),
                _ => throw new ArgumentException(
                    "Invalid Input Format. Choose either 'HEX' or 'Base64'."
                ),
            };

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

        private static byte[] PadKeyTo8Bytes(byte[] Key, string Padding)
        {
            int keyLength = Key.Length;
            int padLength = 8 - keyLength;

            if (Padding == "PKCS7")
            {
                byte padByte = (byte)padLength;
                return [.. Key, .. Enumerable.Repeat(padByte, padLength)];
            }
            else if (Padding == "ZeroPadding")
            {
                return [.. Key, .. new byte[padLength]];
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
