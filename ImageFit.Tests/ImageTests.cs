using System;
using System.IO;
using Xunit;

namespace ImageFit.Tests
{
    public class ImageTests
    {
        private string _sourcePath;
        private byte[] _sourceBytes;
        private int _sourceWidth;
        private int _sourceHeight;


        public ImageTests()
        {
            _sourcePath = Path.Combine(AppContext.BaseDirectory, "source.jpg");
            _sourceBytes = File.ReadAllBytes(_sourcePath);
            var info = GetImageInfo(_sourcePath);
            _sourceWidth = info.width;
            _sourceHeight = info.height;
        }


        [Fact]
        public void TestInvalidWidth()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "invalid.jpg");
            Assert.Throws<ArgumentException>(() => { Image.Cover(_sourceBytes, destination, 0, 100); });
        }

        [Fact]
        public void TestInvalidHeight()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "invalid.jpg");
            Assert.Throws<ArgumentException>(() => { Image.Cover(_sourceBytes, destination, 100, 0); });
        }

        [Fact]
        public void TestCover()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "cover.jpg");
            Image.Cover(_sourceBytes, destination, _sourceWidth * 2, _sourceHeight / 2);
            var info = GetImageInfo(destination);
            Assert.True(info.width == _sourceWidth * 2 && info.height == _sourceHeight / 2);
        }

        [Fact]
        public void TestCoverUpscale()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "cover_upscale.jpg");
            Image.Cover(_sourceBytes, destination, _sourceWidth * 3, _sourceHeight * 2);
            var info = GetImageInfo(destination);
            Assert.True(info.width == _sourceWidth * 3 && info.height == _sourceHeight * 2);
        }

        [Fact]
        public void TestContain()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "contain.jpg");
            Image.Contain(_sourceBytes, destination, _sourceWidth * 2, _sourceHeight / 2);
            var info = GetImageInfo(destination);
            Assert.True(info.width == _sourceWidth / 2 && info.height == _sourceHeight / 2);
        }

        [Fact]
        public void TestContainUpscale()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "contain_upscale.jpg");
            Image.Contain(_sourceBytes, destination, _sourceWidth * 2, _sourceHeight * 4);
            var info = GetImageInfo(destination);
            Assert.True(info.width == _sourceWidth * 2 && info.height == _sourceHeight * 2);
        }

        [Fact]
        public void TestFill()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "fill.jpg");
            Image.Fill(_sourceBytes, destination, _sourceWidth, _sourceHeight / 2);
            var info = GetImageInfo(destination);
            Assert.True(info.width == _sourceWidth && info.height == _sourceHeight / 2);
        }

        [Fact]
        public void TestFillUpscale()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "fill_upscale.jpg");
            Image.Fill(_sourceBytes, destination, _sourceWidth, _sourceHeight * 2);
            var info = GetImageInfo(destination);
            Assert.True(info.width == _sourceWidth && info.height == _sourceHeight * 2);
        }

        [Fact]
        public void TestScaleDown()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "scaledown.jpg");
            Image.ScaleDown(_sourceBytes, destination, _sourceWidth / 1, _sourceHeight / 2);
            var info = GetImageInfo(destination);
            Assert.True(info.width == _sourceWidth / 2 && info.height == _sourceHeight / 2);
        }

        [Fact]
        public void TestScaleDownUpscale()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "scaledown_upscale.jpg");
            Image.ScaleDown(_sourceBytes, destination, _sourceWidth * 2, _sourceHeight * 2);
            var info = GetImageInfo(destination);
            Assert.True(info.width == _sourceWidth && info.height == _sourceHeight);
        }

        [Fact]
        public void TestJpegQuality()
        {
            string destination0 = Path.Combine(AppContext.BaseDirectory, "quality_0.jpg");
            string destination100 = Path.Combine(AppContext.BaseDirectory, "quality_100.jpg");
            Image.Contain(_sourceBytes, destination0, _sourceWidth, _sourceHeight, new JpegEncoder(0));
            Image.Contain(_sourceBytes, destination100, _sourceWidth, _sourceHeight, new JpegEncoder(100));
            var info0 = GetImageInfo(destination0);
            var info100 = GetImageInfo(destination100);
            Assert.True(info0.size < info100.size);
        }

        [Fact]
        public void TestPngCompression()
        {
            string destination1 = Path.Combine(AppContext.BaseDirectory, "compression_level_1.png");
            string destination9 = Path.Combine(AppContext.BaseDirectory, "compression_level_9.png");
            Image.Contain(_sourceBytes, destination1, _sourceWidth, _sourceHeight, new PngEncoder(1));
            Image.Contain(_sourceBytes, destination9, _sourceWidth, _sourceHeight, new PngEncoder(9));
            var info1 = GetImageInfo(destination1);
            var info9 = GetImageInfo(destination9);
            Assert.True(info1.size > info9.size);
        }

        [Fact]
        public void TestFileSource()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "file_source.jpg");
            Image.ScaleDown(_sourcePath, destination, _sourceWidth, _sourceHeight);
            var info = GetImageInfo(destination);
            Assert.True(info.size > 0);
        }

        [Fact]
        public void TestGifEncoder()
        {
            string destination = Path.Combine(AppContext.BaseDirectory, "gif_encoder.gif");
            Image.ScaleDown(_sourcePath, destination, _sourceWidth, _sourceHeight, new GifEncoder());
            var info = GetImageInfo(destination);
            Assert.True(info.size > 0);
        }



        private (int width, int height, long size) GetImageInfo(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            long size = bytes.LongLength;
            int width = 0;
            int height = 0;

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                var info = SixLabors.ImageSharp.Image.Identify(ms);
                width = info.Width;
                height = info.Height;
            }

            return (width: width, height: height, size: size);
        }
    }
}
