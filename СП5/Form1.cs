using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СП5
{
    public partial class Form1 : Form
    {
        private int shift = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.SelectedText))
                Clipboard.SetText(textBox1.SelectedText);
            else
                textBox2.Text = "Текст не выделен в текстовом поле 1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDataObject IData = Clipboard.GetDataObject();
            if (IData.GetDataPresent(DataFormats.Text))
            {
                textBox2.Text = (string)IData.GetData(DataFormats.Text);
            }
            else
            {
                textBox2.Text = "Буфер обмена не содержит текст.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            MessageBox.Show("Буфер обмена очищен.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox2.Text = Encrypt(textBox1.Text, shift);
            }
            else
            {
                textBox2.Text = "Введите текст для шифрования.";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox2.Text = Decrypt(textBox1.Text, shift);
            }
            else
            {
                textBox2.Text = "Введите текст для дешифрования.";
            }

        }
        public static string Decrypt(string text, int shift)
        {
            int shift1 = 26 - shift;
            return Encrypt(text, shift1);
        }
        public static string Encrypt(string text, int shift)
        {
            StringBuilder result = new StringBuilder();

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    char shiftedChar = (char)(ch + shift);
                    if ((char.IsLower(ch) && shiftedChar > 'z') || (char.IsUpper(ch) && shiftedChar > 'Z'))
                    {
                        shiftedChar = (char)(ch - (26 - shift));
                    }
                    result.Append(shiftedChar);
                }
                else
                {
                    result.Append(ch);
                }
            }

            return result.ToString();
        }
    }
}
