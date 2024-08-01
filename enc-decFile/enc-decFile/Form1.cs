using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
namespace enc_decFile
{//نرم افزار کد گذاری یا رمز گذاری فایل ها که قابل دسترسی همه نباشند

    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
              (
              int nLeftRect, int nTopRect, int nRightRect, int BottomRect, int nWidthEllipse, int nHeightEllipse
              );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            try
            {
                byte[] b = File.ReadAllBytes(op.FileName);

                for (int i = 0; i < b.Length; i++)
                {
                    b[i] += (byte)i;
                }
                System.IO.File.WriteAllBytes(op.FileName, b);
                MessageBox.Show("Replaced!!!");
            }
            catch
            {


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            try
            {
                byte[] b = System.IO.File.ReadAllBytes(op.FileName);
                for (int i = 0; i < b.Length; i++)
                {
                    b[i] -= (byte)i;
                }
                System.IO.File.WriteAllBytes(op.FileName, b);
                MessageBox.Show("Done");
            }
            catch
            {


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }
    }
}
