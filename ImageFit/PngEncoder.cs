using SixLabors.ImageSharp.Formats;

namespace ImageFit
{
    /// <summary>
    /// Encoder for saving image in png format.
    /// </summary>
    public class PngEncoder : IEncoder
    {
        private int? _compressionLevel;

        /// <summary>
        /// Encoder for saving image in png format with the default compression level.
        /// </summary>
        public PngEncoder()
        {
        }

        /// <summary>
        /// Encoder for saving image in png format with a specific compression level.
        /// </summary>
        /// <param name="compressionLevel">Compression level must be in the range 1 to 9.</param>
        public PngEncoder(int compressionLevel)
        {
            _compressionLevel = compressionLevel;
        }

        public IImageEncoder ConvertEncoder()
        {
            SixLabors.ImageSharp.Formats.Png.PngEncoder encoder = new SixLabors.ImageSharp.Formats.Png.PngEncoder();
            if (_compressionLevel.HasValue)
            {
                encoder.CompressionLevel = _compressionLevel.Value;
            }
            return encoder;
        }
    }
}
