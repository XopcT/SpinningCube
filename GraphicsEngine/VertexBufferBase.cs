
namespace GraphicsEngine
{
    /// <summary>
    /// Base Class for Vertex Buffers.
    /// </summary>
    public abstract class VertexBufferBase
    {
        #region Properties

        /// <summary>
        /// Sets/retrieves the Size of a single Vector.
        /// </summary>
        public int VertexSize { get; set; }

        /// <summary>
        /// Sets/retrieves the Number of Vertices in the Buffer.
        /// </summary>
        public int VertexCount { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
