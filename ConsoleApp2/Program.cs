using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace ConsoleApp2
{
    class Program
    {
        private static string _XML_WAFER = "Wafer";
        private static string _XML_RAW_DATA = "RawData";
        private static string _XML_UPCDLINESCAN = "UPCDLineScan";


        static void Main(string[] args)
        {
            // copy metadata from one image to another image: ---------------------------------------------------

            //string metaData;
            //ushort[][] kep_in_for_metadatareading = LoadPNG16WithMetadata(@"x:\Sorter_images\PLI\HanwhaK_diamond_mono\0106201717521318_raw_withMetaData.png", out metaData);
            //ushort[][] kep_in = LoadPNG16(@"x:\Sorter_images\PLI\HanwhaK_diamond_mono\shift_right.png");

            //string kep_out_name = @"x:\Sorter_images\PLI\HanwhaK_diamond_mono\shift_right_withMetaData.png";

            //SavePNG16(kep_in, kep_out_name, metaData);


            // copy upcd into image: ---------------------------------------------------

            // upcd data:

            UPCDLineScan lineScan = new UPCDLineScan();
            lineScan.DateTime = DateTime.Now;
            lineScan.ToolId = "Wml";
            lineScan.WaferId = "";
            lineScan.TimeLifetime = new IuPCDPoint[23];
            lineScan.TimeLifetime[0] = new UpcdPoint { Time = 0.0000, Lifetime_us = 2060.4435 };
            lineScan.TimeLifetime[1] = new UpcdPoint { Time = 0.0271, Lifetime_us = 1411.7537 };
            lineScan.TimeLifetime[2] = new UpcdPoint { Time = 0.0742, Lifetime_us = 786.7278 };
            lineScan.TimeLifetime[3] = new UpcdPoint { Time = 0.1113, Lifetime_us = 644.9882 };
            lineScan.TimeLifetime[4] = new UpcdPoint { Time = 0.1584, Lifetime_us = 655.0679 };
            lineScan.TimeLifetime[5] = new UpcdPoint { Time = 0.1955, Lifetime_us = 586.7407 };
            lineScan.TimeLifetime[6] = new UpcdPoint { Time = 0.2416, Lifetime_us = 507.7310 };
            lineScan.TimeLifetime[7] = new UpcdPoint { Time = 0.2787, Lifetime_us = 499.4311 };
            lineScan.TimeLifetime[8] = new UpcdPoint { Time = 0.3259, Lifetime_us = 546.1551 };
            lineScan.TimeLifetime[9] = new UpcdPoint { Time = 0.3640, Lifetime_us = 515.5002 };
            lineScan.TimeLifetime[10] = new UpcdPoint { Time = 0.4021, Lifetime_us = 540.1024 };
            lineScan.TimeLifetime[11] = new UpcdPoint { Time = 0.4492, Lifetime_us = 561.7783 };
            lineScan.TimeLifetime[12] = new UpcdPoint { Time = 0.4863, Lifetime_us = 544.1311 };
            lineScan.TimeLifetime[13] = new UpcdPoint { Time = 0.5324, Lifetime_us = 554.6868 };
            lineScan.TimeLifetime[14] = new UpcdPoint { Time = 0.5695, Lifetime_us = 506.3257 };
            lineScan.TimeLifetime[15] = new UpcdPoint { Time = 0.6156, Lifetime_us = 477.6313 };
            lineScan.TimeLifetime[16] = new UpcdPoint { Time = 0.6527, Lifetime_us = 531.9679 };
            lineScan.TimeLifetime[17] = new UpcdPoint { Time = 0.6999, Lifetime_us = 488.8227 };
            lineScan.TimeLifetime[18] = new UpcdPoint { Time = 0.7370, Lifetime_us = 520.0927 };
            lineScan.TimeLifetime[19] = new UpcdPoint { Time = 0.7831, Lifetime_us = 1178.2263 };
            lineScan.TimeLifetime[20] = new UpcdPoint { Time = 0.8202, Lifetime_us = 880.4538 };
            lineScan.TimeLifetime[21] = new UpcdPoint { Time = 0.8693, Lifetime_us = 599.9916 };
            lineScan.TimeLifetime[22] = new UpcdPoint { Time = 0.9074, Lifetime_us = 3674.7332 };


            XElement upcdLineScanXElement = new XElement(_XML_UPCDLINESCAN);
            lineScan.SaveToXml(upcdLineScanXElement);

            var xDoc = new XDocument();
            XElement xmlWaferXElement = new XElement(_XML_WAFER);
            XElement xmlRawDataXElement = new XElement(_XML_RAW_DATA);
            xDoc.Add(xmlWaferXElement);
            xmlWaferXElement.Add(xmlRawDataXElement);
            xmlRawDataXElement.Add(upcdLineScanXElement);


            // kép  ebolvasása:

            string metadata;

            string extension = ".png";
            string ipnutKepPath = @"d:\PLI_Images\From_Levente\withmeta\";

            string[] fileNames = new string[] { @"d:\PLI_Images\From_Levente\withmeta\11221122_20190926_dark-1.png" };//Directory.GetFiles(ipnutKepPath, "*.png");

            foreach (string fileName in fileNames)
            {
                ushort[][] kep_in_for_metadatareading = LoadPNG16WithoutMetadata($"{fileName}");
                SavePNG16(kep_in_for_metadatareading, $"{Path.GetFileNameWithoutExtension(fileName)}_With_MetaData{extension}", xDoc.ToString());
            }


        }


        public static ushort[][] LoadPNG16(string filename)
        {
            ushort[][] result = null;
            // Open a Stream and decode a PNG image
            using (Stream imageStreamSource = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                PngBitmapDecoder decoder = new PngBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource = decoder.Frames[0];

                if (bitmapSource.Format == System.Windows.Media.PixelFormats.Gray16)
                {
                    int w = bitmapSource.PixelWidth;
                    int h = bitmapSource.PixelHeight;
                    int stride = w * 2;
                    byte[] ba = new byte[h * stride];
                    bitmapSource.CopyPixels(ba, stride, 0);
                    result = new ushort[h][];
                    int i = 0;
                    for (int y = 0; y < h; y++)
                    {
                        result[y] = new ushort[w];
                        for (int x = 0; x < w; x++)
                        {
                            result[y][x] = (ushort)(ba[i++] + 256 * ba[i++]);
                        }
                    }
                }
            }
            return result;
        }



        public static ushort[][] LoadPNG16WithMetadata(string filename, out string metaData)
        {
            ushort[][] result = null;
            // Open a Stream and decode a PNG image
            using (Stream imageStreamSource = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                PngBitmapDecoder decoder = new PngBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource = decoder.Frames[0];
                if (bitmapSource.Format == System.Windows.Media.PixelFormats.Gray16)
                {
                    int w = bitmapSource.PixelWidth;
                    int h = bitmapSource.PixelHeight;
                    int stride = w * 2;
                    byte[] ba = new byte[h * stride];
                    bitmapSource.CopyPixels(ba, stride, 0);
                    result = JaggedArray<ushort>.A2(h, w);
                    int i = 0;
                    for (int y = 0; y < h; y++)
                        for (int x = 0; x < w; x++)
                        {
                            result[y][x] = (ushort)(ba[i++] + 256 * ba[i++]);
                        }
                }
                BitmapMetadata metadata = (BitmapMetadata)decoder.Frames[0].Metadata;
                if (metadata.GetQuery("/text/WaferData") == null)
                    throw new Exception("There is no metadata in the image: " + filename);
                metaData = metadata.GetQuery("/text/WaferData").ToString();
            }
            return result;
        }



        public static ushort[][] LoadPNG16WithoutMetadata(string filename)
        {
            ushort[][] result = null;
            // Open a Stream and decode a PNG image
            using (Stream imageStreamSource = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                PngBitmapDecoder decoder = new PngBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                BitmapSource bitmapSource = decoder.Frames[0];
                if (bitmapSource.Format == System.Windows.Media.PixelFormats.Gray16)
                {
                    int w = bitmapSource.PixelWidth;
                    int h = bitmapSource.PixelHeight;
                    int stride = w * 2;
                    byte[] ba = new byte[h * stride];
                    bitmapSource.CopyPixels(ba, stride, 0);
                    result = JaggedArray<ushort>.A2(h, w);
                    int i = 0;
                    for (int y = 0; y < h; y++)
                        for (int x = 0; x < w; x++)
                        {
                            result[y][x] = (ushort)(ba[i++] + 256 * ba[i++]);
                        }
                }
                BitmapMetadata metadata = (BitmapMetadata)decoder.Frames[0].Metadata;
            }
            return result;
        }



        public static void SavePNG16(ushort[][] upixels, string filename, string metaData = null)
        {

            int width = upixels[0].Length;
            int height = upixels.Length;
            int stride = width * 2;
            byte[] pixels = new byte[height * stride];

            int cnt = 0;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    pixels[cnt] = (byte)(upixels[y][x] & 0xFF);
                    cnt++;
                    pixels[cnt] = (byte)(upixels[y][x] >> 8);
                    cnt++;
                }

            // Define the image palette
            BitmapPalette myPalette = BitmapPalettes.Gray16;

            BitmapMetadata metadata = null;
            if (metaData != null)
            {
                metadata = new BitmapMetadata("png");
                metadata.SetQuery("/text/WaferData", metaData);
            }

            // Creates a new empty image with the pre-defined palette
            BitmapSource image = BitmapSource.Create(
                width,
                height,
                96,
                96,
                System.Windows.Media.PixelFormats.Gray16,
                myPalette,
                pixels,
                stride);

            BitmapFrame frame = BitmapFrame.Create(image,
                                                   null,
                                                   metadata,
                                                   null);

            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Interlace = PngInterlaceOption.Off;
                encoder.Frames.Add(frame);
                encoder.Save(stream);
            }
        }


    }


    public class JaggedArray<T>
    {
        /// <summary>
        /// Creates a two-dimensional jagged array.
        /// </summary>
        /// <param name="lenght0"></param>
        /// <param name="lenght1"></param>
        /// <returns></returns>
        public static T[][] A2(int lenght0, int lenght1)
        {
            T[][] result = new T[lenght0][];
            for (int i = 0; i < lenght0; i++) result[i] = new T[lenght1];
            return result;
        }

        /// <summary>
        /// Creates a three-dimensional jagged array.
        /// </summary>
        /// <param name="lenght0"></param>
        /// <param name="lenght1"></param>
        /// <param name="lenght2"></param>
        /// <returns></returns>
        public static T[][][] A3(int lenght0, int lenght1, int length2)
        {
            T[][][] result = new T[lenght0][][];
            for (int i = 0; i < lenght0; i++)
            {
                result[i] = new T[lenght1][];
                for (int j = 0; j < lenght1; j++)
                {
                    result[i][j] = new T[length2];
                }
            }
            return result;
        }

    }

}
