using Xunit;

namespace ImageFit.Tests
{
    public class EncoderTests
    {
        [Fact]
        public void TestGifEncoder()
        {
            var encoder = new GifEncoder();
            var convertedEncoder = encoder.ConvertEncoder();
            Assert.True(convertedEncoder is SixLabors.ImageSharp.Formats.Gif.GifEncoder);
        }

        [Fact]
        public void TestJpegEncoder()
        {
            var encoder = new JpegEncoder(42);
            var convertedEncoder = encoder.ConvertEncoder();
            Assert.True(convertedEncoder is SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder);
            Assert.True(((SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder)convertedEncoder).Quality == 42);
        }

        [Fact]
        public void TestPngEncoder()
        {
            var encoder = new PngEncoder(3);
            var convertedEncoder = encoder.ConvertEncoder();
            Assert.True(convertedEncoder is SixLabors.ImageSharp.Formats.Png.PngEncoder);
            Assert.True(((SixLabors.ImageSharp.Formats.Png.PngEncoder)convertedEncoder).CompressionLevel == 3);
        }
    }
}
