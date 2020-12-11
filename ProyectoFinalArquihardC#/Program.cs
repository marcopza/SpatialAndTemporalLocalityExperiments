using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalArquihard
{
    class Program
    {
        static void Main(string[] args)
        {
            string path2 = @"resources\resultado.bmp";
            string path3 = @"resources\resultados.csv";
            StreamWriter tw = new StreamWriter(path3);

            Stopwatch sw = new Stopwatch();
            for (int j = 1; j <= 8; j++)
            {
                string path = @"resources\" + j + ".bmp";
                string result = "";
                for (int k = 1; k <= 5; k++)
                {
                    result = "";
                    for (int i = 0; i < 40; i++)
                    {
                        if (i == 39)
                        {
                            result += execute(path, k, sw, path2);
                        }
                        else
                        {
                            result += execute(path, k, sw, path2) + ";";
                        }
                    }
                    tw.WriteLine(result);
                }
            }
            tw.Close();
        }

        public static long execute(string path, int version, Stopwatch sw, string path2)
        {
            Bitmap img = (Bitmap)Image.FromFile(path);
            Int64 count = 0;
            switch (version)
            {

                case 1:
                    /*
                     * Versión 1 del algoritmo. 
                     */
                    sw.Restart();
                    sw.Start();
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            byte green = (byte)(255 - pixel.G);
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(red, green, blue);
                            img.SetPixel(i, j, newCo);
                            count += 3;
                        }
                    }
                    sw.Stop();
                    break;

                case 2:
                    /*
                     * Versión 2 del algoritmo
                     */
                    sw.Restart();
                    sw.Start();
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            Color newCo = Color.FromArgb(red, pixel.G, pixel.B);
                            img.SetPixel(i, j, newCo);
                            count += 1;
                        }
                    }

                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte green = (byte)(255 - pixel.G);
                            Color newCo = Color.FromArgb(pixel.R, green, pixel.B);
                            img.SetPixel(i, j, newCo);
                            count += 1;
                        }
                    }

                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(pixel.R, pixel.G, blue);
                            img.SetPixel(i, j, newCo);
                            count += 1;
                        }
                    }
                    sw.Stop();
                    break;

                case 3:
                    /**
                     * Versión 3
                     */
                    sw.Restart();
                    sw.Start();
                    for (int i = 0; i < img.Height; i++)
                    {
                        for (int j = 0; j < img.Width; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            byte green = (byte)(255 - pixel.G);
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(red, green, blue);
                            img.SetPixel(i, j, newCo);
                            count += 3;
                        }
                    }
                    sw.Stop();
                    break;

                case 4:
                    /*
                     * Versión 4
                     */
                    sw.Restart();
                    sw.Start();
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            Color newCo = Color.FromArgb(red, pixel.G, pixel.B);
                            img.SetPixel(i, j, newCo);
                            count += 1;
                        }
                    }

                    for (int i = img.Width - 1; i >= 0; i--)
                    {
                        for (int j = img.Height - 1; j >= 0; j--)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte green = (byte)(255 - pixel.G);
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(pixel.R, green, blue);
                            img.SetPixel(i, j, newCo);
                            count += 2;
                        }
                    }
                    sw.Stop();
                    break;

                case 5:
                    /*
                     * Versión 5
                     */
                    sw.Restart();
                    sw.Start();
                    for (int i = 0; i < img.Width - 1; i += 2)
                    {
                        for (int j = 0; j < img.Height - 1; j += 2)
                        {
                            Color pixel = img.GetPixel(i, j);
                            byte red = (byte)(255 - pixel.R);
                            byte green = (byte)(255 - pixel.G);
                            byte blue = (byte)(255 - pixel.B);
                            Color newCo = Color.FromArgb(red, green, blue);
                            img.SetPixel(i, j, newCo);

                            Color pixel2 = img.GetPixel(i + 1, j);
                            byte red2 = (byte)(255 - pixel2.R);
                            byte green2 = (byte)(255 - pixel2.G);
                            byte blue2 = (byte)(255 - pixel2.B);
                            Color newCo2 = Color.FromArgb(red2, green2, blue2);
                            img.SetPixel(i + 1, j, newCo2);

                            Color pixel3 = img.GetPixel(i, j + 1);
                            byte red3 = (byte)(255 - pixel3.R);
                            byte green3 = (byte)(255 - pixel3.G);
                            byte blue3 = (byte)(255 - pixel3.B);
                            Color newCo3 = Color.FromArgb(red3, green3, blue3);
                            img.SetPixel(i, j + 1, newCo3);

                            Color pixel4 = img.GetPixel(i + 1, j + 1);
                            byte red4 = (byte)(255 - pixel4.R);
                            byte green4 = (byte)(255 - pixel4.G);
                            byte blue4 = (byte)(255 - pixel4.B);
                            Color newCo4 = Color.FromArgb(red4, green4, blue4);
                            img.SetPixel(i + 1, j + 1, newCo4);

                            count += 12;
                        }

                    }
                    sw.Stop();
                    break;

                default:
                    Console.WriteLine("Re manco.");
                    break;

            }
            long tiempo = (long)(sw.Elapsed.TotalMilliseconds * 1000000);
            Image img1 = (Image)img.Clone();
            img1.Save(path2);
            return tiempo;
        }
    }
}
