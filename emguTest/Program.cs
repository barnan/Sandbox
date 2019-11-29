using Emgu.CV;
using Emgu.CV.Structure;
using System;

namespace emguTest
{
    class Program
    {
        private static int _imageCount = 0;
        private static string _resultPath = "OutputFolder";
        private static Image<Gray, ushort> _inputImage;




        static void Main(string[] args)
        {
            _inputImage = new Image<Gray, ushort>("input.png");

            Image<Gray, float> floatimage = _inputImage.Convert<Gray, float>();

            SaveDebugImage<float>(floatimage, "mentes_float.png");
            SaveDebugImage<ushort>(_inputImage, "mentes_ushort.png");

            Console.ReadKey();
        }


        private static void SaveDebugImage<TDepth>(Image<Gray, TDepth> image2Save, string nameExtension) where TDepth : new()
        {
            // itt ellenőriz, és csak a megfelelő esetben convertál, ha ugyanolyan típusú, akkor csak castol
            Image<Gray, ushort> saveImage = null;
            try
            {
                if (typeof(TDepth) == typeof(ushort))
                {
                    saveImage = (Image<Gray, ushort>)(object)image2Save;
                }
                else
                {
                    saveImage = image2Save.Convert<Gray, ushort>();
                }

                saveImage.Save(nameExtension);

            }
            catch (Exception)
            {
                // dosomething
            }
            finally
            {
                saveImage?.Dispose();
            }


            // másik megoldás, de itt mindig van konverzió
            //using (Image<Gray, ushort> saveImage = image2Save.Convert<Gray, ushort>())
            //{
            //    saveImage.Save("ment.png");
            //}
        }

    }
}
