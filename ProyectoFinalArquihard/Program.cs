using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalArquihard
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap img = new Bitmap("*imagePath*");
            Bitmap img2 = (Bitmap) img.Clone();
            Int64 count = 0;
            Int64 version = 1;
            switch (version)
            {

                case 1:
                    /*
                     * Versión 1 del algoritmo. 
                     */
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            byte green = (byte)(255 - pixel.G);
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(red, green, blue);
                            img2.SetPixel(i, j, newCo);
                            count += 3;
                        }
                    }
                    break;

                case 2:
                    /*
                     * Versión 2 del algoritmo
                     */

                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            byte green = pixel.G;
                            byte blue = pixel.B;
                            Color newCo = Color.FromArgb(red, green, blue);
                            img2.SetPixel(i, j, newCo);
                            count += 1;
                        }
                    }

                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = img2.GetPixel(i, j).R;
                            byte green = (byte)(255 - pixel.G);
                            byte blue = img2.GetPixel(i, j).B;
                            Color newCo = Color.FromArgb(red, green, blue);
                            img2.SetPixel(i, j, newCo);
                            count += 1;
                        }
                    }

                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = img2.GetPixel(i, j).R;
                            byte green = img2.GetPixel(i, j).G;
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(red, green, blue);
                            img2.SetPixel(i, j, newCo);
                            count += 1;
                        }
                    }
                    break;

                case 3:
                    /**
                     * Versión 3
                     */
                    for (int i = 0; i < img.Height; i++)
                    {
                        for (int j = 0; j < img.Width; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            byte green = (byte)(255 - pixel.G);
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(red, green, blue);
                            img2.SetPixel(i, j, newCo);
                            count += 3;
                        }
                    }
                    break;

                case 4:
                    /*
                     * Versión 4
                     */
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            byte green = pixel.G;
                            byte blue = pixel.B;
                            Color newCo = Color.FromArgb(red, green, blue);
                            img2.SetPixel(i, j, newCo);
                            count += 1;
                        }
                    }

                    for (int i = img.Width; i >= 0; i--)
                    {
                        for (int j = img.Height; j >= 0; j--)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = img2.GetPixel(i, j).R;
                            byte green = (byte)(255 - pixel.G);
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(red, green, blue);
                            img2.SetPixel(i, j, newCo);
                            count += 2;
                        }
                    }
                    break;

                case 5:
                    /*
                     * Versión 5
                     */
                    for (int i = 0; i < img.Width; i += 2)
                    {
                        for (int j = 0; j < img.Height; j += 2)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            byte green = (byte)(255 - pixel.G);
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(red, green, blue);
                            img2.SetPixel(i, j, newCo);

                            Color pixel2 = img.GetPixel(i + 1, j);
                            byte red2 = (byte)(255 - pixel2.R);
                            byte green2 = (byte)(255 - pixel2.G);
                            byte blue2 = (byte)(255 - pixel2.B);
                            Color newCo2 = Color.FromArgb(red2, green2, blue2);
                            img2.SetPixel(i + 1, j, newCo2);

                            Color pixel3 = img.GetPixel(i, j + 1);
                            byte red3 = (byte)(255 - pixel3.R);
                            byte green3 = (byte)(255 - pixel3.G);
                            byte blue3 = (byte)(255 - pixel3.B);
                            Color newCo3 = Color.FromArgb(red3, green3, blue3);
                            img2.SetPixel(i, j + 1, newCo3);

                            Color pixel4 = img.GetPixel(i + 1, j + 1);
                            byte red4 = (byte)(255 - pixel4.R);
                            byte green4 = (byte)(255 - pixel4.G);
                            byte blue4 = (byte)(255 - pixel4.B);
                            Color newCo4 = Color.FromArgb(red4, green4, blue4);
                            img2.SetPixel(i + 1, j + 1, newCo4);

                            count += 12;
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Re manco.");
                    break;

            }

        }
    }
}
