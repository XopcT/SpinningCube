
namespace GraphicsEngine
{
    /// <summary>
    /// Defines an Interface of a Content Manager.
    /// </summary>
    public interface IContentManager
    {
        /// <summary>
        /// Loads a Cube Model.
        /// </summary>
        /// <param name="sideSize">Size of the Cube Size.</param>
        /// <returns>Loaded Model Instance.</returns>
        Model LoadCube(float sideSize);

        /// <summary>
        /// Loads a Model from specified File.
        /// </summary>
        /// <param name="fullName">File to load Model from.</param>
        /// <returns>Loaded Model Instance.</returns>
        Model LoadModel(string fullName);
    }
}
