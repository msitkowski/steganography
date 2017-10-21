using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Drawing.Imaging;

namespace techniki_steganografi_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private byte[] EncryptMessage(string text, string passwd)
        {
            byte[] msg = null;
            // setup message encryption
            using (Aes encryptor = Aes.Create())
            {
                // hash password
                SHA512 sha512 = new SHA512Managed();
                byte[] hash = sha512.ComputeHash(Encoding.ASCII.GetBytes(passwd));
                byte[] key = new byte[32];
                byte[] iv = new byte[16];
                Array.Copy(hash, key, 32);
                Array.Copy(hash, iv, 16);
                encryptor.Key = key;
                encryptor.IV = iv;

                // encrypt message
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(encryptor.Key, encryptor.IV), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(msgTextBox.Text);
                        }
                        msg = ms.ToArray();
                    }
                }
            }
            return msg;
        }

        private string DecryptMessage(byte[] msg, string passwd)
        {
            string res = null;

            using (Aes decryptor = Aes.Create())
            {
                // hash password
                SHA512 sha512 = new SHA512Managed();
                byte[] hash = sha512.ComputeHash(Encoding.ASCII.GetBytes(passwd));
                byte[] key = new byte[32];
                byte[] iv = new byte[16];
                Array.Copy(hash, key, 32);
                Array.Copy(hash, iv, 16);
                decryptor.Key = key;
                decryptor.IV = iv;

                using (MemoryStream ms = new MemoryStream(msg))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor.CreateDecryptor(decryptor.Key, decryptor.IV), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            res = sr.ReadToEnd();
                        }
                    }
                }
            }
            return res;
        }

        private void HideMessageInBmp(Bitmap bmp, byte[] msg)
        {
            int msg_len_mask = 1 << 30;
            int mask = 128;
            int msg_iter = 0;
            int next_msg_byte_counter = 0;
            int px = 0;

            // operations on image
            for (int i = 0; i < bmp.Height; ++i)
            {
                for (int j = 0; j < bmp.Width; ++j)
                {
                    Color pixel = bmp.GetPixel(j, i);
                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    // get LSB
                    int a1 = pixel.R & 1;
                    int a2 = pixel.G & 1;
                    int a3 = pixel.B & 1;

                    int x1, x2;

                    if (msg_len_mask > 0)
                    {
                        // get x1 and x2 bits value from msg.Length value
                        x1 = ((msg.Length & msg_len_mask) == msg_len_mask) ? 1 : 0;
                        msg_len_mask = msg_len_mask >> 1;
                        x2 = ((msg.Length & msg_len_mask) == msg_len_mask) ? 1 : 0;
                        msg_len_mask = msg_len_mask >> 1;
                        px++;
                    }
                    else
                    {
                        // get x1 and x2 bits value from msg
                        x1 = ((msg[msg_iter] & mask) == mask) ? 1 : 0;
                        mask = mask >> 1;
                        x2 = ((msg[msg_iter] & mask) == mask) ? 1 : 0;
                        mask = mask >> 1;

                        next_msg_byte_counter++;
                        // when 4 pixels was encoded get next message byte
                        // increment msg_iter, set mask to 128 and next_msg_byte_counter to 0
                        if (next_msg_byte_counter == 4)
                        {
                            msg_iter++;
                            mask = 128;
                            next_msg_byte_counter = 0;
                        }
                    }

                    // parity encoding
                    if (x1 == (a1 ^ a3))
                    {
                        if (x2 != (a2 ^ a3))
                        {
                            // change a2
                            green = (a2 == 1) ? pixel.G & 254 : pixel.G | 1;
                        }
                        // else change nothing
                    }
                    else
                    {
                        if (x2 == (a2 ^ a3))
                        {
                            // change a1
                            red = (a1 == 1) ? pixel.R & 254 : pixel.R | 1;
                        }
                        else
                        {
                            // change a3
                            blue = (a3 == 1) ? pixel.B & 254 : pixel.B | 1;
                        }
                    }
                    // change pixel
                    bmp.SetPixel(j, i, Color.FromArgb(red, green, blue));

                    // break when all msg bytes are encrypted
                    if (msg_iter >= msg.Length)
                    {
                        pictureBox2.Image = bmp;
                        return;
                    }
                }
            }
        }

        private byte[] ReadHiddenMessageFromBmp(Bitmap bmp)
        {
            byte[] msg = null;

            int counter = 0;
            int msg_len = 0;
            int pixel_count = 0;
            int decoded_bytes = 0;

            // operations on image
            for (int i = 0; i < bmp.Height; ++i)
            {
                for (int j = 0; j < bmp.Width; ++j)
                {
                    Color pixel = bmp.GetPixel(j, i);
                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    // get LSB
                    int a1 = pixel.R & 1;
                    int a2 = pixel.G & 1;
                    int a3 = pixel.B & 1;

                    int x1 = a1 ^ a3;
                    int x2 = a2 ^ a3;

                    // decoding msg length
                    if (counter < 16)
                    {
                        msg_len |= x1;
                        if (counter < 15)
                        {
                            msg_len <<= 1;
                            msg_len |= x2;
                            msg_len <<= 1;
                        }
                        counter++;
                    }
                    else
                    {
                        // initialize byte array for msg
                        if (msg == null)
                        {
                            msg = new byte[msg_len];
                            //for (int k = 0; k < msg.Length; ++k)
                            //{
                            //    msg[k] = 0;
                            //}
                        }

                        int el = msg[decoded_bytes];
                        el |= x1;
                        el <<= 1;
                        el |= x2;

                        if (pixel_count < 3)
                        {
                            el <<= 1;
                        }
                        msg[decoded_bytes] = (byte)el;
                        pixel_count++;

                        // 4 pixels == 1 byte so read data to next msg array element
                        if (pixel_count == 4)
                        {
                            pixel_count = 0;
                            decoded_bytes++;
                        }

                        // check if all bytes decoded
                        if (msg.Length == decoded_bytes)
                        {
                            return msg;
                        }
                    }
                }
            }
            return msg;
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog sourceDlg = new OpenFileDialog();
            sourceDlg.Filter = "Bitmap (*.bmp)|*.bmp";

            if (sourceDlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(sourceDlg.FileName);
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            // encrypt msg
            byte[] msg = EncryptMessage(msgTextBox.Text, encryptionPasswordTextBox.Text);
            HideMessageInBmp(new Bitmap(pictureBox1.Image), msg);
        }
        
        private void readHiddenMsgButton_Click(object sender, EventArgs e)
        {
            byte[] encrypted_msg = ReadHiddenMessageFromBmp(new Bitmap(pictureBox2.Image));
            string msg = DecryptMessage(encrypted_msg, encryptionPasswordTextBox.Text);
            steganographicKeyTextBox.Text = msg;
        }

        private void saveModifiedFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Bitmap (*.bmp)|*.bmp";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(pictureBox2.Image);
                image.Save(saveDlg.FileName, ImageFormat.Bmp);
            }
        }
    }
}
