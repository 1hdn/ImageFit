using SixLabors.ImageSharp.Formats;

namespace ImageFit
{
    /// <summary>
    /// Encoder for saving image in gif format.
    /// </summary>
    public class GifEncoder : IEncoder
    {
        public GifEncoder()
        {
        }

        public IImageEncoder ConvertEncoder()
        {
            return new SixLabors.ImageSharp.Formats.Gif.GifEncoder();
        }
    }
}
