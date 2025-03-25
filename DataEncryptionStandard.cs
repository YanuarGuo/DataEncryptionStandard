using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

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
            byte[] keyBytes = KeyPad(Encoding.ASCII.GetBytes(Key));
            byte[] inputBytes = Encoding.ASCII.GetBytes(plainText);
            inputBytes = DataPad(inputBytes, 8, Padding);

            byte[] ivBytes = Encoding.ASCII.GetBytes(IV);

            if (
                CipherMode.Equals("CBC", StringComparison.CurrentCultureIgnoreCase)
                && ivBytes.Length != 8
            )
                throw new ArgumentException("IV must be exactly 8 bytes long");

            IBlockCipher engine = new DesEngine();
            IBlockCipher cipher = CipherMode.ToUpper() switch
            {
                "CBC" => new CbcBlockCipher(new DesEngine()),
                "ECB" => new EcbBlockCipher(new DesEngine()),
                _ => throw new ArgumentException(
                    "Invalid Cipher Mode. Choose either 'CBC' or 'ECB'."
                ),
            };

            BufferedBlockCipher blockCipher = new((IBlockCipherMode)cipher);
            KeyParameter keyParam = new(keyBytes);
            ICipherParameters cipherParams = CipherMode.Equals(
                "CBC",
                StringComparison.CurrentCultureIgnoreCase
            )
                ? new ParametersWithIV(keyParam, ivBytes)
                : keyParam;

            blockCipher.Init(true, cipherParams);
            byte[] encryptedBytes = new byte[blockCipher.GetOutputSize(inputBytes.Length)];
            int len = blockCipher.ProcessBytes(inputBytes, 0, inputBytes.Length, encryptedBytes, 0);
            blockCipher.DoFinal(encryptedBytes, len);

            return OutputFormat.Equals("HEX", StringComparison.CurrentCultureIgnoreCase)
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
            byte[] keyBytes = KeyPad(Encoding.ASCII.GetBytes(Key));

            byte[] ivBytes = Encoding.ASCII.GetBytes(IV);
            if (
                CipherMode.Equals("CBC", StringComparison.CurrentCultureIgnoreCase)
                && ivBytes.Length != 8
            )
                throw new ArgumentException("IV must be exactly 8 bytes long");

            byte[] cipherBytes = InputFormat switch
            {
                "HEX" => Enumerable
                    .Range(0, cipherText.Length / 2)
                    .Select(i => Convert.ToByte(cipherText.Substring(i * 2, 2), 16))
                    .ToArray(),
                "Base64" => Convert.FromBase64String(cipherText),
                _ => throw new ArgumentException("Invalid Input Format. Choose 'HEX' or 'Base64'."),
            };

            IBlockCipher desEngine = new DesEngine();
            IBlockCipher cipher = CipherMode switch
            {
                "CBC" => new CbcBlockCipher(desEngine),
                "ECB" => new EcbBlockCipher(desEngine),
                _ => throw new ArgumentException("Invalid Cipher Mode. Choose 'CBC' or 'ECB'."),
            };

            ICipherParameters parameters = CipherMode.Equals(
                "CBC",
                StringComparison.CurrentCultureIgnoreCase
            )
                ? new ParametersWithIV(new KeyParameter(keyBytes), ivBytes)
                : new KeyParameter(keyBytes);

            PaddedBufferedBlockCipher decryptCipher = Padding switch
            {
                "PKCS7" => new PaddedBufferedBlockCipher(cipher, new Pkcs7Padding()),
                "ZeroPadding" => new PaddedBufferedBlockCipher(cipher, new ZeroBytePadding()),
                _ => throw new ArgumentException(
                    "Invalid padding type. Choose 'PKCS7' or 'ZeroPadding'."
                ),
            };
            decryptCipher.Init(false, parameters);

            byte[] outputBytes = new byte[decryptCipher.GetOutputSize(cipherBytes.Length)];
            int outputLen = decryptCipher.ProcessBytes(
                cipherBytes,
                0,
                cipherBytes.Length,
                outputBytes,
                0
            );
            outputLen += decryptCipher.DoFinal(outputBytes, outputLen);

            return Encoding.ASCII.GetString(outputBytes, 0, outputLen);
        }

        private static byte[] DataPad(byte[] data, int blockSize, string paddingType)
        {
            int paddingLength = blockSize - (data.Length % blockSize);

            return paddingType switch
            {
                "PKCS7" => [.. data, .. Enumerable.Repeat((byte)paddingLength, paddingLength)],
                "ZeroPadding" => [.. data, .. new byte[paddingLength]],
                _ => throw new ArgumentException(
                    "Invalid padding type. Choose 'PKCS7' or 'ZeroPadding'."
                ),
            };
        }

        private static byte[] KeyPad(byte[] Key)
        {
            if (Key.Length >= 8)
                return [.. Key.Take(8)];

            return [.. Key, .. new byte[8 - Key.Length]];
        }

        // SSC VERSION
        // WINDOWS ENCRYPTION
        //public static string Encrypt(
        //    string plainText,
        //    string Key,
        //    string IV,
        //    string Padding,
        //    string OutputFormat,
        //    string CipherMode
        //)
        //{
        //    using var provider = DES.Create();

        //    byte[] keyBytes = KeyPad(Encoding.ASCII.GetBytes(Key), Padding);
        //    Debug.WriteLine($"Key: {BitConverter.ToString(keyBytes)}");

        //    provider.Key = keyBytes;

        //    provider.Mode = CipherMode.ToUpper() switch
        //    {
        //        "CBC" => System.Security.Cryptography.CipherMode.CBC,
        //        "ECB" => System.Security.Cryptography.CipherMode.ECB,
        //        _ => throw new ArgumentException(
        //            "Invalid Cipher Mode. Choose either 'CBC' or 'ECB'."
        //        ),
        //    };

        //    if (provider.Mode == System.Security.Cryptography.CipherMode.CBC)
        //    {
        //        byte[] ivBytes = Encoding.ASCII.GetBytes(IV);
        //        if (ivBytes.Length != 8)
        //            throw new ArgumentException("IV must be exactly 8 bytes long");
        //        provider.IV = ivBytes;
        //    }

        //    using var ms = new MemoryStream();
        //    using (
        //        var cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write)
        //    )
        //    {
        //        byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);
        //        cs.Write(plainBytes, 0, plainBytes.Length);
        //        cs.FlushFinalBlock();
        //    }

        //    byte[] encryptedBytes = ms.ToArray();

        //    return OutputFormat == "HEX"
        //        ? BitConverter.ToString(encryptedBytes).Replace("-", "")
        //        : Convert.ToBase64String(encryptedBytes);
        //}
        // WINDOWS DECRYPTION
        //public static string Decrypt(
        //    string cipherText,
        //    string Key,
        //    string IV,
        //    string Padding,
        //    string InputFormat,
        //    string CipherMode
        //)
        //{
        //    using var provider = DES.Create();

        //    byte[] keyBytes = KeyPad(Encoding.ASCII.GetBytes(Key), Padding);
        //    Debug.WriteLine($"Key: {BitConverter.ToString(keyBytes)}");

        //    provider.Key = keyBytes;

        //    provider.Mode = CipherMode.ToUpper() switch
        //    {
        //        "CBC" => System.Security.Cryptography.CipherMode.CBC,
        //        "ECB" => System.Security.Cryptography.CipherMode.ECB,
        //        _ => throw new ArgumentException(
        //            "Invalid Cipher Mode. Choose either 'CBC' or 'ECB'."
        //        ),
        //    };

        //    if (provider.Mode == System.Security.Cryptography.CipherMode.CBC)
        //    {
        //        byte[] ivBytes = Encoding.ASCII.GetBytes(IV);
        //        if (ivBytes.Length != 8)
        //            throw new ArgumentException("IV must be exactly 8 bytes long");
        //        provider.IV = ivBytes;
        //    }

        //    byte[] cipherBytes = InputFormat switch
        //    {
        //        "HEX" => Enumerable
        //            .Range(0, cipherText.Length / 2)
        //            .Select(i => Convert.ToByte(cipherText.Substring(i * 2, 2), 16))
        //            .ToArray(),
        //        "Base64" => Convert.FromBase64String(cipherText),
        //        _ => throw new ArgumentException(
        //            "Invalid Input Format. Choose either 'HEX' or 'Base64'."
        //        ),
        //    };

        //    using var ms = new MemoryStream();
        //    using (
        //        var cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Write)
        //    )
        //    {
        //        cs.Write(cipherBytes, 0, cipherBytes.Length);
        //        cs.FlushFinalBlock();
        //    }

        //    return Encoding.ASCII.GetString(ms.ToArray());
        //}
        //private static byte[] KeyPad(byte[] Key, string Padding)
        //{
        //    int keyLength = Key.Length;
        //    int padLength = 8 - keyLength;

        //    if (Padding == "PKCS7")
        //    {
        //        byte padByte = (byte)padLength;
        //        return [.. Key, .. Enumerable.Repeat(padByte, padLength)];
        //    }
        //    else if (Padding == "ZeroPadding")
        //    {
        //        return [.. Key, .. new byte[padLength]];
        //    }
        //    else
        //    {
        //        throw new ArgumentException(
        //            "Invalid padding type. Choose 'PKCS7' or 'ZeroPadding'."
        //        );
        //    }
        //}
    }
}
