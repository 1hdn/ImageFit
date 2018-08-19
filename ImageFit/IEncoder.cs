using SixLabors.ImageSharp.Formats;

namespace ImageFit
{
    public interface IEncoder
    {
        /// <summary>
        /// Converts the IEncoder implementation to the SixLabors.ImageSharp.Formats.IImageEncoder that will be used when saving the image.
        /// </summary>
        IImageEncoder ConvertEncoder();
    }
}
