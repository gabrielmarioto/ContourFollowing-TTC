using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GabrielMarioto
{
    public partial class Form1 : Form
    {
        private Image image;
        private Bitmap imageBitmap;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Imagem (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictBoxImg1.Image = image;
                if (image.Width > pictBoxImg1.Width || image.Height > pictBoxImg1.Height)
                {
                    pictBoxImg1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictBoxImg2.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pictBoxImg1.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictBoxImg2.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }

        private void btn_Contour_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image.Width, image.Height);
            imageBitmap = (Bitmap)image;
            Function.convert_to_WB(imageBitmap, imageBitmap);
            Function.convert_to_White(imgDest, imgDest);
            Function.ContourFollowing(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }
    }
}
