
namespace GraphicsEngine
{
    /// <summary>
    /// Buffer containing Model's Vertices.
    /// </summary>
    public class VertexBuffer
    {
        #region Properties

        /// <summary>
        /// Sets/retrieves the Buffer Instance.
        /// </summary>
        public object Buffer { get; set; }

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
