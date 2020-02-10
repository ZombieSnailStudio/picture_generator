using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picture_generator
{
    public partial class Form1 : Form
    {
        int i = 0;
        int n;
        string default_tag = "0";
        public Form1()
        {
            InitializeComponent();
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            n = int.Parse(textBox1.Text.ToString());
            if(n>0 && n<=32)
            {
                flowLayoutPanel1.Width = n * 22;
                for (i = 1; i < (n * n) + 1; i++)
                {
                    flowLayoutPanel1.Controls.Add(btn(i));
                }
            }
            else
            {
                return;
            }
            
        }
        Button btn (int i)
        {
            Button b = new Button();
            b.Name = i.ToString();
            b.Width = 16;
            b.Height = 16;
            //b.Text = i.ToString();
            b.Tag = 0;
            b.BackColor = Color.White;
            b.Click += b_Click;
            return b;
        }

        private void b_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Tag.ToString() == default_tag)
            {
                b.BackColor = Color.Gray;
                b.Tag = 1;
            }
            else
            {
                b.BackColor = Color.White;
                b.Tag = 0;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            var list = new List<int>();
            foreach (Control btn in flowLayoutPanel1.Controls)
            {
                if(btn.Tag.ToString() == default_tag)
                {
                    list.Add(0);
                }
                else
                {
                    list.Add(1);
                }
            }
            int[] array = list.ToArray();
            textBox2.Width = n * 10;
            textBox2.Height = n * 14;
            textBox2.Text = string.Join(" ", array);
            int t = 0, k = 1;
            Bitmap bmp = new Bitmap(n, n);
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (array[t] == 0)
                    {
                        bmp.SetPixel(y, x, Color.FromArgb(255, 255, 255));
                    }
                    else if (array[t] == 1)
                    {
                        bmp.SetPixel(y, x, Color.FromArgb(0, 0, 0));
                    }
                    t++;
                    k++;
                }
                k = 0;
            }
            pictureBox1.Width = n;
            pictureBox1.Height = n;
            pictureBox1.Image = bmp;
            string fl = filename.Text.ToString();
            string cb = comboBox1.Text;
            string form = String.Format("{0}\\{1}{2}", folderBrowserDialog1.SelectedPath,fl,cb);
            bmp.Save(form);
        }
        private void path_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            pathdisplay.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
