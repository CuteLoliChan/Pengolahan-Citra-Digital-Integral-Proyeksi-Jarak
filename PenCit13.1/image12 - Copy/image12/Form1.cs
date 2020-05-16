using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image12
{
    public partial class Form1 : Form
    {
        Bitmap objBitmap1;
        Bitmap objBitmap2;
        int[,] mat1 = new int[1000, 1000];
        int[,] mat2 = new int[1000, 1000];
        int[] konx1 = new int[1000];
        int[] konx2 = new int[1000];
        int[] kony1 = new int[1000];
        int[] kony2 = new int[1000];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap1 = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objBitmap1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < objBitmap1.Width; x++)
                for (int y = 0; y < objBitmap1.Height; y++)
                {
                    mat1[x, y] = 0;
                    Color w = objBitmap1.GetPixel(x, y);
                    int wr = w.R;
                    int wg = w.G;
                    int wb = w.B;
                    int xg = (int)((wr + wg + wb) / 3);
                    if (xg > 127)
                        xg = 255;
                    else
                        xg = 0;
                    mat1[x, y] = (int)xg / 255;
                    Color new_c = Color.FromArgb(xg, xg, xg);
                    objBitmap1.SetPixel(x, y, new_c);
                }
            pictureBox1.Image = objBitmap1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] konx = new int[1000]; 
            int[] ii = new int[1000];
            int[,] matx = new int[1000, 1000];

            for (int i = 0; i < objBitmap1.Width; i++)
            {
                konx[i] = 0;
                for (int j = 0; j < objBitmap1.Height; j++)
                {
                    if (mat1[i, j] == 0)
                        matx[i, j] = 1;
                    else 
                        matx[i, j] = 0;

                    konx[i] = konx[i] + matx[i, j];
                    ii[i] = i + 1;
                    konx1[i] = matx[i, j];
                }
                chart1.Series["Series1"].Points.DataBindXY(ii, konx);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] kony = new int[1000];
            int[] ii = new int[1000];
            int[,] maty = new int[1000, 1000];

            for (int i = 0; i < objBitmap1.Height; i++)
            {
                kony[i] = 0;
                for (int j = 0; j < objBitmap1.Width; j++)
                {
                    if (mat1[j, i] == 0)
                        maty[j, i] = 1;
                    else
                        maty[j, i] = 0;

                    kony[i] = kony[i] + maty[j, i];
                    ii[i] = i + 1;
                    kony1[i] = maty[j, i];
                }
                
                chart2.Series["Series1"].Points.DataBindXY(ii, kony);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap2 = new Bitmap(openFileDialog1.FileName);
                pictureBox2.Image = objBitmap2;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < objBitmap2.Width; x++)
                for (int y = 0; y < objBitmap2.Height; y++)
                {
                    mat2[x, y] = 0;
                    Color w = objBitmap2.GetPixel(x, y);
                    int wr = w.R;
                    int wg = w.G;
                    int wb = w.B;
                    int xg = (int)((wr + wg + wb) / 3);
                    if (xg > 127)
                        xg = 255;
                    else
                        xg = 0;
                    mat2[x, y] = (int)xg / 255;
                    Color new_c = Color.FromArgb(xg, xg, xg);
                    objBitmap2.SetPixel(x, y, new_c);
                }
            pictureBox2.Image = objBitmap2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] konx = new int[1000];
            int[] ii = new int[1000];
            int[,] matx = new int[1000, 1000];

            for (int i = 0; i < objBitmap2.Width; i++)
            {
                konx[i] = 0;
                for (int j = 0; j < objBitmap2.Height; j++)
                {
                    if (mat2[i, j] == 0)
                        matx[i, j] = 1;
                    else
                        matx[i, j] = 0;

                    konx[i] = konx[i] + matx[i, j];
                    ii[i] = i + 1;
                    konx2[i] = matx[i, j];
                }
                chart3.Series["Series1"].Points.DataBindXY(ii, konx);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] kony = new int[1000];
            int[] ii = new int[1000];
            int[,] maty = new int[1000, 1000];

            for (int i = 0; i < objBitmap2.Height; i++)
            {
                kony[i] = 0;
                for (int j = 0; j < objBitmap2.Width; j++)
                {
                    if (mat2[j, i] == 0)
                        maty[j, i] = 1;
                    else
                        maty[j, i] = 0;

                    kony[i] = kony[i] + maty[j, i];
                    ii[i] = i + 1;
                    kony2[i] = maty[j, i];
                }
                chart4.Series["Series1"].Points.DataBindXY(ii, kony);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            float d = 0;
            for(int i = 0; i < 1000; i++)
            {
                for(int j = 0; j < 1000; j++)
                {
                    d = d + Math.Abs((float)mat1[i, j] - mat2[i, j]);
                }                
            }
            d = d / 1000;
            label2.Text = d.ToString();
        }
    }
}
