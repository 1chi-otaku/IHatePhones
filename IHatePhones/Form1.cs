using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHatePhones
{
    public partial class Form1 : Form
    {
        public string current_word;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            textBox1.Text += button.Text;
            current_word += button.Text;
            string result = IsFound(current_word);
            if (result != null)
            {
                textBox1.Text = textBox1.Text.ToString().Remove(textBox1.Text.Length-current_word.Length,current_word.Length);
                textBox1.Text += result;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += " ";
            current_word = null;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length> 0)
            {
                textBox1.Text = textBox1.Text.ToString().Remove(textBox1.Text.Length - 1);
                current_word = null;
            }
           
        }
        private async void button31_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("words.txt", true))
            {
                await writer.WriteLineAsync(textBox1.Text);
            }
        }

        private string IsFound(string text)
        {
            using (StreamReader reader = new StreamReader("words.txt"))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith(text))
                    {
                        DialogResult res =  MessageBox.Show(line + " ? ", "", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            return line;
                        }
                        
                    }
                }
            }
            return null;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
