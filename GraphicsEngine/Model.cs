
namespace GraphicsEngine
{
    /// <summary>
    /// Graphics Model.
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Sets/retrieves Buffer of Model Vertices.
        /// </summary>
        public object VertexBuffer { get; set; }

        /// <summary>
        /// Sets/retrieves Buffer of Model Indices.
        /// </summary>
        public object IndexBuffer { get; set; }

        /// <summary>
        /// Sets/retrieves an Effect to render the Model.
        /// </summary>
        public object Effect { get; set; }
    }
}
