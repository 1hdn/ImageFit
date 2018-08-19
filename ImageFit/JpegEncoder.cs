using SixLabors.ImageSharp.Formats;

namespace ImageFit
{
    /// <summary>
    /// Encoder for saving image in jpeg format.
    /// </summary>
    public class JpegEncoder : IEncoder
    {
        private int? _quality;

        /// <summary>
        /// Encoder for saving image in jpeg format with the default quality setting.
        /// </summary>
        public JpegEncoder()
        {
        }

        /// <summary>
        /// Encoder for saving image in jpeg format with a specific quality setting.
        /// </summary>
        /// <param name="quality">Quality must be in the range 0 to 100.</param>
        public JpegEncoder(int quality)
        {
            _quality = quality;
        }

        public IImageEncoder ConvertEncoder()
        {
            SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder encoder = new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder();
            if (_quality.HasValue)
            {
                encoder.Quality = _quality.Value;
            }
            return encoder;
        }
    }
}
