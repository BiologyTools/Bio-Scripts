//css_reference Bio.dll;

using System;
using System.Windows.Forms;
using System.Drawing;
using Bio;
using System.Threading;

public class Loader
{
    //Filter Example
    public string Load()
    {
        Bio.BioImage im = ImageView.SelectedImage;
        Random rd = new Random();
        int w = im.SizeX;
        int h = im.SizeY;

        for (int i = 0; i < im.Buffers.Count; i++)
        {
            Bio.BufferInfo bts = im.Buffers[i];
            if (bts.RGBChannelsCount == 3)
            {
                if (bts.BitsPerPixel > 8)
                {
                    for (int y = 0; y < h; y++)
                    {
                        //getting the pixels of current row
                        int rowRGB = y * (w * 2 * 3);
                        //iterating through all the pixels in x direction
                        for (int x = 0; x < w; x++)
                        {
                            int indexRGB = x * 6;
                            float rf = (float)(BitConverter.ToUInt16(bts.Bytes, rowRGB + indexRGB) / (float)ushort.MaxValue) * (float)rd.NextDouble();
                            float gf = (float)(BitConverter.ToUInt16(bts.Bytes, rowRGB + indexRGB + 2) / (float)ushort.MaxValue) * (float)rd.NextDouble();
                            float bf = (float)(BitConverter.ToUInt16(bts.Bytes, rowRGB + indexRGB + 4) / (float)ushort.MaxValue) * (float)rd.NextDouble();
                            ushort rs = (ushort)(rf * ushort.MaxValue);
                            ushort gs = (ushort)(gf * ushort.MaxValue);
                            ushort bs = (ushort)(bf * ushort.MaxValue);
                            byte[] rbb = BitConverter.GetBytes(rs);
                            byte[] gbb = BitConverter.GetBytes(gs);
                            byte[] bbb = BitConverter.GetBytes(bs);
                            //R
                            bts.Bytes[rowRGB + indexRGB] = rbb[0];
                            bts.Bytes[rowRGB + indexRGB + 1] = rbb[1];
                            //G
                            bts.Bytes[rowRGB + indexRGB + 2] = gbb[0];
                            bts.Bytes[rowRGB + indexRGB + 3] = gbb[1];
                            //B
                            bts.Bytes[rowRGB + indexRGB + 4] = bbb[0];
                            bts.Bytes[rowRGB + indexRGB + 5] = bbb[1];
                        }
                    }
                }
                else
                {
                    for (int y = 0; y < bts.SizeY; y++)
                    {
                        //getting the pixels of current row
                        int rowRGB = y * (bts.SizeX * 3);
                        //iterating through all the pixels in x direction
                        for (int x = 0; x < bts.SizeX; x++)
                        {
                            int indexRGB = x * 3;
                            float rf = (float)(bts.Bytes[rowRGB + indexRGB] / 255f) * (float)rd.NextDouble();
                            float gf = (float)(bts.Bytes[rowRGB + indexRGB + 1] / 255f) * (float)rd.NextDouble();
                            float bf = (float)(bts.Bytes[rowRGB + indexRGB + 2] / 255f) * (float)rd.NextDouble();
                            byte rs = (byte)(rf * byte.MaxValue);
                            byte gs = (byte)(gf * byte.MaxValue);
                            byte bs = (byte)(bf * byte.MaxValue);
                            //R
                            bts.Bytes[rowRGB + indexRGB] = rs;
                            //G
                            bts.Bytes[rowRGB + indexRGB + 1] = gs;
                            //B
                            bts.Bytes[rowRGB + indexRGB + 2] = bs;
                        }
                    }
                }
            }
            else
            {
                if (bts.BitsPerPixel > 8)
                {
                    for (int y = 0; y < h; y++)
                    {
                        //getting the pixels of current row
                        int row = y * bts.Stride;
                        //iterating through all the pixels in x direction
                        for (int x = 0; x < w; x++)
                        {
                            int indexRGB = x * 2;
                            float rf = (float)(BitConverter.ToUInt16(bts.Bytes, row + indexRGB) / (float)ushort.MaxValue) * (float)rd.NextDouble();
                            ushort rs = (ushort)(rf * ushort.MaxValue);
                            byte[] rbb = BitConverter.GetBytes(rs);
                            //R
                            bts.Bytes[row + indexRGB] = rbb[0];
                            bts.Bytes[row + indexRGB + 1] = rbb[1];
                        }
                    }
                }
                else
                {
                    for (int y = 0; y < bts.SizeY; y++)
                    {
                        //getting the pixels of current row
                        int row = y * bts.Stride;
                        //iterating through all the pixels in x direction
                        for (int x = 0; x < bts.SizeX; x++)
                        {
                            int indexRGB = x * 3;
                            float rf = (float)(bts.Bytes[row + indexRGB] / 255f) * (float)rd.NextDouble();
                            byte rs = (byte)(rf * byte.MaxValue);
                            //R
                            bts.Bytes[row + indexRGB] = rs;
                        }
                    }
                }
            }
        }
        App.viewer.UpdateImage();
        return "OK";
    }
}