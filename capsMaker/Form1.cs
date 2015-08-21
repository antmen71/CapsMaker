using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace capsMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        bool resimVarmi;
        bool kirmiziFon;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Load pictures
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bit = new Bitmap(open.FileName);
                    pictureBox1.Image = bit;
                    int yukseklik;
                    int genislik;
                    yukseklik = bit.Height;
                    genislik = bit.Width;
                    resimVarmi = true;



                    if (bit.Height > pictureBox1.Height && bit.Width > pictureBox1.Width)
                    {

                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


                    }
                    else
                    {

                        pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                    }

                }
            }
            catch (Exception)
            {
                throw new ApplicationException("No pic loaded!");
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (resimVarmi == true)
            {
                //insert caps background and text
                int yukseklik = pictureBox1.Image.Height;
                int yukseklik1 = pictureBox1.Height;
                int bantYukseklik = yukseklik / 100 * 20;
                int genislik = pictureBox1.Image.Width;
                int genislik1 = pictureBox1.Width;

                Pen PenStyle = new Pen(Color.Red, 10);
                Rectangle rect = new Rectangle(0, yukseklik - bantYukseklik, genislik, bantYukseklik);
                Graphics g = pictureBox1.CreateGraphics();
                System.Drawing.SolidBrush myBrush;
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                float fontSize = (float)numericUpDown1.Value;




                using (Graphics grp = Graphics.FromImage(pictureBox1.Image))
                {
                    grp.FillRectangle(myBrush, rect);
                    kirmiziFon = true;
                    //TextFormatFlags flags = TextFormatFlags.WordBreak;
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    SizeF sizF = new SizeF(rect.Width, rect.Height);
                    PointF poinF = new PointF(0, yukseklik - bantYukseklik);
                    RectangleF recF = new RectangleF(poinF, sizF);

                    grp.DrawString(capsYazisi.Text, new Font("Comic Sans MS", fontSize), new SolidBrush(Color.White), recF, stringFormat);
                }

                pictureBox1.Refresh();
                myBrush.Dispose();
                g.Dispose();
                PenStyle.Dispose();
            }
            else
            {

                MessageBox.Show("Lütfen bir resim yükleyiniz");
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (resimVarmi == true)
            {
                //save file
                saveFileDialog1.Filter = "Jpg Dosyası(*.jpg; *.jpeg)|*.jpg; *.jpeg|Gif Dosyası(*.gif)|*.gif|Bmp Dosyası (*.bmp)|*.bmp";

                saveFileDialog1.AddExtension = true;
                saveFileDialog1.FileName = "*.jpg";

                DialogResult dialogResult = saveFileDialog1.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    Bitmap grp = new Bitmap(pictureBox1.Image);

                    ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder =
                    System.Drawing.Imaging.Encoder.Quality;

                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, trackBar1.Value);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    grp.Save(saveFileDialog1.FileName, jgpEncoder, myEncoderParameters);

                }
                else if (dialogResult == DialogResult.Cancel )
                { }

            }
            else
            {
                MessageBox.Show("Lütfen bir resim yükleyiniz");
            }

        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {




            if (resimVarmi == false)
            {

            }

            else
            {

                int yukseklik = pictureBox1.Image.Height;
                int yukseklik1 = pictureBox1.Height;
                int bantYukseklik = yukseklik / 100 * 20;
                int genislik = pictureBox1.Image.Width;
                int genislik1 = pictureBox1.Width;

                Pen PenStyle = new Pen(Color.Red, 10);
                Rectangle rect = new Rectangle(0, yukseklik - bantYukseklik, genislik, bantYukseklik);
                Graphics g = pictureBox1.CreateGraphics();
                System.Drawing.SolidBrush myBrush;
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                float fontSize = (float)numericUpDown1.Value;
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                SizeF sizF = new SizeF(rect.Width, rect.Height);
                PointF poinF = new PointF(0, yukseklik - bantYukseklik);
                RectangleF recF = new RectangleF(poinF, sizF);
                using (Graphics grp = Graphics.FromImage(pictureBox1.Image))
                {
                    grp.FillRectangle(myBrush, rect);
                    grp.DrawString(capsYazisi.Text, new Font("Comic Sans MS", fontSize), new SolidBrush(Color.White), recF, stringFormat);
                    pictureBox1.Refresh();
                    myBrush.Dispose();
                    g.Dispose();
                    PenStyle.Dispose();

                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            if (kirmiziFon == false)
            {


            }

            else
            {
                int yukseklik = pictureBox1.Image.Height;
                int yukseklik1 = pictureBox1.Height;
                int bantYukseklik = yukseklik / 100 * 20;
                int genislik = pictureBox1.Image.Width;
                int genislik1 = pictureBox1.Width;


                Pen PenStyle = new Pen(Color.Red, 10);
                Rectangle rect = new Rectangle(0, yukseklik - bantYukseklik, genislik, bantYukseklik);
                Graphics g = pictureBox1.CreateGraphics();
                System.Drawing.SolidBrush myBrush;
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                float fontSize = (float)numericUpDown1.Value;


                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;


                SizeF sizF = new SizeF(rect.Width, rect.Height);
                PointF poinF = new PointF(0, yukseklik - bantYukseklik);
                RectangleF recF = new RectangleF(poinF, sizF);
                using (Graphics grp = Graphics.FromImage(pictureBox1.Image))
                {
                    grp.FillRectangle(myBrush, rect);
                    grp.DrawString(capsYazisi.Text, new Font("Comic Sans MS", fontSize), new SolidBrush(Color.White), recF, stringFormat);
                    pictureBox1.Refresh();
                    myBrush.Dispose();
                    g.Dispose();
                    PenStyle.Dispose();

                }
                //using (Graphics grp1 = Graphics.FromImage(pictureBox1.Image))
                //{
                //    grp1.FillRectangle(myBrush, rect);
                //    grp1.DrawString(capsYazisi.Text, new Font(fontDialog1.Font.Name, fontSize), new SolidBrush(Color.White), 20, yukseklik - bantYukseklik + 5);
                //    pictureBox1.Refresh();

                //    myBrush.Dispose();
                //    g.Dispose();
                //    PenStyle.Dispose();
                //}


            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}

