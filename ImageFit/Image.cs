using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System;
using System.IO;

namespace ImageFit
{
    public static class Image
    {
        private enum FitMethod
        {
            None,
            Contain,
            Cover,
            Fill,
            ScaleDown
        }


        /// <summary>
        /// Generates an image that is scaled to maintain its aspect ratio while fitting within the box defined by the width and height parameter.
        /// </summary>
        /// <param name="source">The byte array containing the source image data.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will be contained inside.</param>
        /// <param name="height">The height of the box the generated image will be contained inside.</param>
        public static void Contain(byte[] source, string destination, int width, int height)
        {
            Generate(source, destination, width, height, FitMethod.Contain, null);    
        }

        /// <summary>
        /// Generates an image that is scaled to maintain its aspect ratio while fitting within the box defined by the width and height parameter.
        /// </summary>
        /// <param name="source">The byte array containing the source image data.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will be contained inside.</param>
        /// <param name="height">The height of the box the generated image will be contained inside.</param>
        /// <param name="encoder">The encoder to save the generated image with.</param>
        public static void Contain(byte[] source, string destination, int width, int height, IEncoder encoder)
        {
            Generate(source, destination, width, height, FitMethod.Contain, encoder);
        }

        /// <summary>
        /// Generates an image that is scaled to maintain its aspect ratio while fitting within the box defined by the width and height parameter.
        /// </summary>
        /// <param name="source">The file-path to the source image.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will be contained inside.</param>
        /// <param name="height">The height of the box the generated image will be contained inside.</param>
        public static void Contain(string source, string destination, int width, int height)
        {
            Generate(source, destination, width, height, FitMethod.Contain, null);
        }

        /// <summary>
        /// Generates an image that is scaled to maintain its aspect ratio while fitting within the box defined by the width and height parameter.
        /// </summary>
        /// <param name="source">The file-path to the source image.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will be contained inside.</param>
        /// <param name="height">The height of the box the generated image will be contained inside.</param>
        /// <param name="encoder">The encoder to save the generated image with.</param>
        public static void Contain(string source, string destination, int width, int height, IEncoder encoder)
        {
            Generate(source, destination, width, height, FitMethod.Contain, encoder);
        }



        /// <summary>
        /// Generates an image that is scaled to maintain its aspect ratio while covering the entire box defined by the width and height parameter. If the image aspect ratio does not match the aspect ratio of the box, then the image will be cropped to fit.
        /// </summary>
        /// <param name="source">The byte array containing the source image data.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will cover.</param>
        /// <param name="height">The height of the box the generated image will cover.</param>
        public static void Cover(byte[] source, string destination, int width, int height)
        {
            Generate(source, destination, width, height, FitMethod.Cover, null);
        }

        /// <summary>
        /// Generates an image that is scaled to maintain its aspect ratio while covering the entire box defined by the width and height parameter. If the image aspect ratio does not match the aspect ratio of the box, then the image will be cropped to fit.
        /// </summary>
        /// <param name="source">The byte array containing the source image data.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will cover.</param>
        /// <param name="height">The height of the box the generated image will cover.</param>
        /// <param name="encoder">The encoder to save the generated image with.</param>
        public static void Cover(byte[] source, string destination, int width, int height, IEncoder encoder)
        {
            Generate(source, destination, width, height, FitMethod.Cover, encoder);
        }

        /// <summary>
        /// Generates an image that is scaled to maintain its aspect ratio while covering the entire box defined by the width and height parameter. If the image aspect ratio does not match the aspect ratio of the box, then the image will be cropped to fit.
        /// </summary>
        /// <param name="source">The file-path to the source image.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will cover.</param>
        /// <param name="height">The height of the box the generated image will cover.</param>
        public static void Cover(string source, string destination, int width, int height)
        {
            Generate(source, destination, width, height, FitMethod.Cover, null);
        }

        /// <summary>
        /// Generates an image that is scaled to maintain its aspect ratio while covering the entire box defined by the width and height parameter. If the image aspect ratio does not match the aspect ratio of the box, then the image will be cropped to fit.
        /// </summary>
        /// <param name="source">The file-path to the source image.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will cover.</param>
        /// <param name="height">The height of the box the generated image will cover.</param>
        /// <param name="encoder">The encoder to save the generated image with.</param>
        public static void Cover(string source, string destination, int width, int height, IEncoder encoder)
        {
            Generate(source, destination, width, height, FitMethod.Cover, encoder);
        }



        /// <summary>
        /// Generates an image that is scaled to fill the box defined by the width and height parameter. If the image aspect ratio does not match the aspect ratio of the box, then the image will be stretched to fit.
        /// </summary>
        /// <param name="source">The byte array containing the source image data.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will fill.</param>
        /// <param name="height">The height of the box the generated image will fill.</param>
        public static void Fill(byte[] source, string destination, int width, int height)
        {
            Generate(source, destination, width, height, FitMethod.Fill, null);
        }

        /// <summary>
        /// Generates an image that is scaled to fill the box defined by the width and height parameter. If the image aspect ratio does not match the aspect ratio of the box, then the image will be stretched to fit.
        /// </summary>
        /// <param name="source">The byte array containing the source image data.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will fill.</param>
        /// <param name="height">The height of the box the generated image will fill.</param>
        /// <param name="encoder">The encoder to save the generated image with.</param>
        public static void Fill(byte[] source, string destination, int width, int height, IEncoder encoder)
        {
            Generate(source, destination, width, height, FitMethod.Fill, encoder);
        }

        /// <summary>
        /// Generates an image that is scaled to fill the box defined by the width and height parameter. If the image aspect ratio does not match the aspect ratio of the box, then the image will be stretched to fit.
        /// </summary>
        /// <param name="source">The file-path to the source image.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will fill.</param>
        /// <param name="height">The height of the box the generated image will fill.</param>
        public static void Fill(string source, string destination, int width, int height)
        {
            Generate(source, destination, width, height, FitMethod.Fill, null);
        }

        /// <summary>
        /// Generates an image that is scaled to fill the box defined by the width and height parameter. If the image aspect ratio does not match the aspect ratio of the box, then the image will be stretched to fit.
        /// </summary>
        /// <param name="source">The file-path to the source image.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will fill.</param>
        /// <param name="height">The height of the box the generated image will fill.</param>
        /// <param name="encoder">The encoder to save the generated image with.</param>
        public static void Fill(string source, string destination, int width, int height, IEncoder encoder)
        {
            Generate(source, destination, width, height, FitMethod.Fill, encoder);
        }



        /// <summary>
        /// Generates an image that is scaled down to maintain its aspect ratio while fitting within the box defined by the width and height parameter. If the image dimensions are smaller than the defined box, then the image will not be scaled up to fit.
        /// </summary>
        /// <param name="source">The byte array containing the source image data.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will be contained inside.</param>
        /// <param name="height">The height of the box the generated image will be contained inside.</param>
        public static void ScaleDown(byte[] source, string destination, int width, int height)
        {
            Generate(source, destination, width, height, FitMethod.ScaleDown, null);
        }

        /// <summary>
        /// Generates an image that is scaled down to maintain its aspect ratio while fitting within the box defined by the width and height parameter. If the image dimensions are smaller than the defined box, then the image will not be scaled up to fit.
        /// </summary>
        /// <param name="source">The byte array containing the source image data.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will be contained inside.</param>
        /// <param name="height">The height of the box the generated image will be contained inside.</param>
        /// <param name="encoder">The encoder to save the generated image with.</param>
        public static void ScaleDown(byte[] source, string destination, int width, int height, IEncoder encoder)
        {
            Generate(source, destination, width, height, FitMethod.ScaleDown, encoder);
        }

        /// <summary>
        /// Generates an image that is scaled down to maintain its aspect ratio while fitting within the box defined by the width and height parameter. If the image dimensions are smaller than the defined box, then the image will not be scaled up to fit.
        /// </summary>
        /// <param name="source">The file-path to the source image.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will be contained inside.</param>
        /// <param name="height">The height of the box the generated image will be contained inside.</param>
        public static void ScaleDown(string source, string destination, int width, int height)
        {
            Generate(source, destination, width, height, FitMethod.ScaleDown, null);
        }

        /// <summary>
        /// Generates an image that is scaled down to maintain its aspect ratio while fitting within the box defined by the width and height parameter. If the image dimensions are smaller than the defined box, then the image will not be scaled up to fit.
        /// </summary>
        /// <param name="source">The file-path to the source image.</param>
        /// <param name="destination">The file-path to the generated image.</param>
        /// <param name="width">The width of the box the generated image will be contained inside.</param>
        /// <param name="height">The height of the box the generated image will be contained inside.</param>
        /// <param name="encoder">The encoder to save the generated image with.</param>
        public static void ScaleDown(string source, string destination, int width, int height, IEncoder encoder)
        {
            Generate(source, destination, width, height, FitMethod.ScaleDown, encoder);
        }



        private static void Generate(byte[] source, string destination, int width, int height, FitMethod method, IEncoder encoder)
        {
            using (Image<Rgba32> image = SixLabors.ImageSharp.Image.Load(source))
            {
                Generate(image, destination, width, height, method, encoder);
            }
        }

        private static void Generate(string source, string destination, int width, int height, FitMethod method, IEncoder encoder)
        {
            using (Image<Rgba32> image = SixLabors.ImageSharp.Image.Load(source))
            {
                Generate(image, destination, width, height, method, encoder);
            }
        }

        private static void Generate(Image<Rgba32> image, string destination, int width, int height, FitMethod method, IEncoder encoder)
        {
            Validate(width, height);
            Transform(image, width, height, method);
            Save(image, destination, encoder);
        }

        private static void Validate(int width, int height)
        {
            if (width < 1)
            {
                throw new ArgumentException("Width must be greater than zero.", "width");
            }

            if (height < 1)
            {
                throw new ArgumentException("Height must be greater than zero.", "height");
            }
        }

        private static void Transform(Image<Rgba32> image, int width, int height, FitMethod method)
        {
            ResizeMode? resizeMode = null;

            switch (method)
            {
                case FitMethod.Contain:
                    resizeMode = ResizeMode.Max;
                    break;

                case FitMethod.Cover:
                    resizeMode = ResizeMode.Crop;
                    break;

                case FitMethod.Fill:
                    resizeMode = ResizeMode.Stretch;
                    break;

                case FitMethod.ScaleDown:
                    if (image.Width > width || image.Height > height)
                    {
                        resizeMode = ResizeMode.Max;
                    }
                    break;
            }

            if (resizeMode.HasValue)
            {
                image.Mutate(x => x.Resize(new ResizeOptions()
                {
                    Size = new Size(width, height),
                    Mode = resizeMode.Value,
                    Position = AnchorPositionMode.Center
                }));
            }
        }

        private static void Save(Image<Rgba32> image, string destination, IEncoder encoder)
        {
            string destinationDirectory = Path.GetDirectoryName(destination);
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            if (encoder != null)
            {
                IImageEncoder imageEncoder = encoder.ConvertEncoder();
                image.Save(destination, imageEncoder);
            }
            else
            {
                image.Save(destination);
            }
        }
    }
}
