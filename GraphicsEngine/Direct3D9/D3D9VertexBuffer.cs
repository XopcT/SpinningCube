using SharpDX.Direct3D9;

namespace GraphicsEngine.Direct3D9
{
    /// <summary>
    /// Vertex Buffer for Direct3D 9.
    /// </summary>
    public class D3D9VertexBuffer : VertexBufferBase
    {
        #region Properties

        /// <summary>
        /// Sets/retrieves the Buffer Instance.
        /// </summary>
        public VertexBuffer Buffer { get; set; }

        /// <summary>
        /// Sets/retrieves the Vertex Format.
        /// </summary>
        public VertexFormat VertexFormat { get; set; }

        /// <summary>
        /// Sets/retrieves the Vertex Declaration.
        /// </summary>
        public VertexDeclaration VertexDeclaration { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
