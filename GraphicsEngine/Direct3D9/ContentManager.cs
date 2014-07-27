
using SharpDX;
namespace GraphicsEngine.Direct3D9
{
    /// <summary>
    /// Content Manager for Direct3D 9.
    /// </summary>
    public class ContentManager : IContentManager
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="device">Graphics Device to load Content for.</param>
        public ContentManager(IGraphicsDevice device)
        {
            this.device = device;
        }

        /// <summary>
        /// Loads a Cube Model.
        /// </summary>
        /// <param name="sideSize">Size of the Cube Size.</param>
        /// <returns>Loaded Model Instance.</returns>
        public Model LoadCube(float sideSize)
        {
            float a = sideSize / 2.0f;
            VertexPositionColor[] vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(-a, -a, -a, 1.0f, 0.0f, 0.0f, 1.0f),    // Near Plane
                new VertexPositionColor(-a, +a, -a, 0.0f, 1.0f, 0.0f, 1.0f),
                new VertexPositionColor(+a, +a, -a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(+a, +a, -a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(+a, -a, -a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, -a, -a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, -a, +a, 1.0f, 0.0f, 0.0f, 1.0f),    // Far Plane
                new VertexPositionColor(+a, -a, +a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(+a, +a, +a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(+a, +a, +a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(-a, +a, +a, 0.0f, 1.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, -a, +a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, -a, -a, 1.0f, 0.0f, 0.0f, 1.0f),    // Left Plane
                new VertexPositionColor(-a, -a, +a, 0.0f, 1.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, +a, +a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(-a, -a, -a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(-a, +a, +a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, +a, -a, 1.0f, 0.0f, 0.0f, 1.0f), 
                new VertexPositionColor(+a, +a, -a, 1.0f, 0.0f, 0.0f, 1.0f),    // Right Plane
                new VertexPositionColor(+a, +a, +a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(+a, -a, -a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(+a, +a, +a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(+a, -a, +a, 0.0f, 1.0f, 0.0f, 1.0f),
                new VertexPositionColor(+a, -a, -a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, +a, +a, 1.0f, 0.0f, 0.0f, 1.0f),    // Top Plane
                new VertexPositionColor(+a, +a, +a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, +a, -a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(+a, +a, +a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(+a, +a, -a, 0.0f, 1.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, +a, -a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, -a, -a, 1.0f, 0.0f, 0.0f, 1.0f),    // Bottom Plane
                new VertexPositionColor(+a, -a, -a, 0.0f, 1.0f, 0.0f, 1.0f),
                new VertexPositionColor(+a, -a, +a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(-a, -a, -a, 0.0f, 0.0f, 1.0f, 1.0f),
                new VertexPositionColor(+a, -a, +a, 1.0f, 0.0f, 0.0f, 1.0f),
                new VertexPositionColor(-a, -a, +a, 1.0f, 0.0f, 0.0f, 1.0f),
            };
            return new Model()
            {
                VertexBuffer = this.device.CreateVertexBuffer(vertices)
            };
        }

        /// <summary>
        /// Loads a Model from specified File.
        /// Actually this one does not load it from File. It just creates a Cube.
        /// </summary>
        /// <param name="fullName">File to load Model from.</param>
        /// <returns>Loaded Model Instance.</returns>
        public Model LoadModel(string fullName)
        {
            throw new System.NotImplementedException();
        }

        #region Properties

        #endregion

        #region Fields
        private IGraphicsDevice device = null;

        #endregion

    }
}
