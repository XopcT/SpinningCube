
namespace GraphicsEngine
{
    /// <summary>
    /// Creates Graphics Engine Objects.
    /// </summary>
    public interface IGraphicsFactory
    {
        /// <summary>
        /// Creates a Renderer.
        /// </summary>
        /// <returns>Renderer Instance.</returns>
        IRenderer CreateRenderer();
    }
}
