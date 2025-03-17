namespace DataEncryptionStandard
{
    partial class DataEncryptionStandard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnDecrypt = new Button();
            TxtPlain = new TextBox();
            TxtEncrypted = new TextBox();
            BtnEncrypt = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // BtnDecrypt
            // 
            BtnDecrypt.Location = new Point(224, 137);
            BtnDecrypt.Name = "BtnDecrypt";
            BtnDecrypt.Size = new Size(75, 23);
            BtnDecrypt.TabIndex = 0;
            BtnDecrypt.Text = "Decrypt";
            BtnDecrypt.UseVisualStyleBackColor = true;
            BtnDecrypt.Click += BtnDecrypt_Click;
            // 
            // TxtPlain
            // 
            TxtPlain.Location = new Point(12, 30);
            TxtPlain.Name = "TxtPlain";
            TxtPlain.Size = new Size(372, 23);
            TxtPlain.TabIndex = 1;
            // 
            // TxtEncrypted
            // 
            TxtEncrypted.Location = new Point(12, 79);
            TxtEncrypted.Name = "TxtEncrypted";
            TxtEncrypted.Size = new Size(372, 23);
            TxtEncrypted.TabIndex = 3;
            // 
            // BtnEncrypt
            // 
            BtnEncrypt.Location = new Point(305, 137);
            BtnEncrypt.Name = "BtnEncrypt";
            BtnEncrypt.Size = new Size(75, 23);
            BtnEncrypt.TabIndex = 2;
            BtnEncrypt.Text = "Encrypt";
            BtnEncrypt.UseVisualStyleBackColor = true;
            BtnEncrypt.Click += BtnEncrypt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Plain Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "Encrypted";
            // 
            // DataEncryptionStandard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 174);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtEncrypted);
            Controls.Add(BtnEncrypt);
            Controls.Add(TxtPlain);
            Controls.Add(BtnDecrypt);
            Name = "DataEncryptionStandard";
            Text = "DataEncryptionStandard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnDecrypt;
        private TextBox TxtPlain;
        private TextBox TxtEncrypted;
        private Button BtnEncrypt;
        private Label label1;
        private Label label2;
    }
}
