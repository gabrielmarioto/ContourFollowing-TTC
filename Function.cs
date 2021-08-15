using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielMarioto
{
    class Function
    {
        public static void convert_to_gray(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int r, g, b;
            Int32 gs;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    r = cor.R;
                    g = cor.G;
                    b = cor.B;
                    gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);

                    //nova cor
                    Color newcolor = Color.FromArgb(gs, gs, gs);

                    imageBitmapDest.SetPixel(x, y, newcolor);
                }
            }
        }

        public static void convert_to_WB(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            Int32 gs;
            int r, g, b;
            Color newcolor;
            convert_to_gray(imageBitmapSrc, imageBitmapDest);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    r = cor.R;
                    g = cor.G;
                    b = cor.B;
                    gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);

                    if (gs > 127)
                    {
                        newcolor = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        newcolor = Color.FromArgb(0, 0, 0);
                    }
                    imageBitmapDest.SetPixel(x, y, newcolor);
                }
            }
        }
        public static void convert_to_White(Bitmap imgSrc, Bitmap imgDst)
        {
            int width = imgSrc.Width;
            int height = imgSrc.Height;
            Color newcolor;
            convert_to_gray(imgSrc, imgDst);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //obtendo a cor do pixel
                    Color cor = imgSrc.GetPixel(x, y);
                    newcolor = Color.FromArgb(255, 255, 255);                    
                    imgDst.SetPixel(x, y, newcolor);
                }
            }
        }

        public static void ContourFollowing(Bitmap imgSrc, Bitmap imgDst)
        {
            List<Point> aux = new List<Point>();
            int width = imgSrc.Width;
            int height = imgSrc.Height;
            Color atual;
            for (int y = 1; y < height; y++)
            {
                for (int x = 1; x < width; x++)
                {
                    Color cor = imgSrc.GetPixel(x, y);
                    int tempX = x;
                    int tempY = y;

                    if (cor.R == 0)
                    {
                        y++;x--;
                        bool temp = false;
                        while(!temp)
                        {
                            Color coord0 = imgSrc.GetPixel(x + 1, y);
                            Color coord1 = imgSrc.GetPixel(x + 1, y - 1);
                            Color coord2 = imgSrc.GetPixel(x, y - 1);
                            Color coord3 = imgSrc.GetPixel(x - 1, y - 1);
                            Color coord4 = imgSrc.GetPixel(x - 1, y);
                            Color coord5 = imgSrc.GetPixel(x - 1, y + 1);
                            Color coord6 = imgSrc.GetPixel(x, y + 1);
                            Color coord7 = imgSrc.GetPixel(x + 1, y + 1);

                            aux.Add(new Point(x, y));
                            atual = imgSrc.GetPixel(x, y);
                            if (atual.R == 255)
                                imgDst.SetPixel(x, y, Color.Black);
                            
                           if(coord0.R == 0)
                            {
                                x -= 1;
                            }
                            else if(coord1.R == 0)
                            {
                                x += 1;
                            }
                            else 
                            {
                                if (coord2.R == 0)
                                {
                                    x += 1;
                                    y -= 1;
                                }
                                else
                                {
                                    if(coord3.R == 0)
                                    {
                                        y -= 1;
                                    }                                        
                                    else
                                    {
                                        if(coord4.R == 0)
                                        {
                                            x -= 1;
                                            y -= 1;
                                        }
                                        else
                                        {
                                            if(coord5.R == 0)
                                            {
                                                x -= 1;
                                            }                                                
                                            else
                                            {
                                                if(coord6.R == 0)
                                                {
                                                    x -= 1;
                                                    y += 1;
                                                }
                                                else
                                                {
                                                    if(coord7.R == 0)
                                                    {
                                                        y += 1;
                                                    }
                                                }
                                            }
                                        }
                                    }                                 
                                }
                            }
                            Point pixel = new Point(x, y);
                            temp = (aux.Contains(pixel)) ? true : false;
                        }
                        aux.Clear();
                    }
                    x = tempX;
                    y = tempY;
                }
            }
        }
    }
}
