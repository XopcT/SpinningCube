using System;
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
        /// Loads a Model from specified File.
        /// Actually this one does not load it from File. It just creates a Cube.
        /// </summary>
        /// <param name="fullName">File to load Model from.</param>
        /// <returns>Loaded Model Instance.</returns>
        public Model LoadModel(string fullName)
        {
            float d = 0.5f;
            VertexPositionColor[] vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(-d, +d, -d, (Int32)Color.Red),      // Top Plane
                new VertexPositionColor(+d, +d, -d, (Int32)Color.Red),
                new VertexPositionColor(+d, +d, +d, (Int32)Color.Red),
                new VertexPositionColor(-d, +d, +d, (Int32)Color.Red),
                new VertexPositionColor(-d, -d, +d, (Int32)Color.Blue),     // Bottom Plane
                new VertexPositionColor(+d, -d, +d, (Int32)Color.Blue),
                new VertexPositionColor(+d, -d, -d, (Int32)Color.Blue),
                new VertexPositionColor(-d, -d, -d, (Int32)Color.Blue),
                new VertexPositionColor(-d, +d, +d, (Int32)Color.Green),    // Near Plane
                new VertexPositionColor(+d, +d, +d, (Int32)Color.Green),
                new VertexPositionColor(+d, -d, +d, (Int32)Color.Green),
                new VertexPositionColor(-d, -d, +d, (Int32)Color.Green),
                new VertexPositionColor(-d, -d, +d, (Int32)Color.Yellow),   // Far Plane
                new VertexPositionColor(+d, -d, +d, (Int32)Color.Yellow),
                new VertexPositionColor(+d, +d, +d, (Int32)Color.Yellow),
                new VertexPositionColor(-d, +d, +d, (Int32)Color.Yellow),
                new VertexPositionColor(+d, +d, +d, (Int32)Color.Cyan),     // Right Plane
                new VertexPositionColor(+d, +d, -d, (Int32)Color.Cyan),
                new VertexPositionColor(+d, -d, -d, (Int32)Color.Cyan),
                new VertexPositionColor(+d, -d, +d, (Int32)Color.Cyan),
                new VertexPositionColor(-d, -d, +d, (Int32)Color.Magenta),  // Right Plane
                new VertexPositionColor(-d, -d, -d, (Int32)Color.Magenta),
                new VertexPositionColor(-d, +d, -d, (Int32)Color.Magenta),
                new VertexPositionColor(-d, +d, +d, (Int32)Color.Magenta),
            };
            int[] indices = new int[] { 0, 1, 2, 0, 2, 3, 4, 7, 6, 4, 6, 5, 8, 9, 10, 8, 10, 11, 12, 13, 14, 12, 14, 15, 16, 17, 18, 16, 18, 19, 20, 21, 22, 20, 22, 23, };

            throw new NotImplementedException();
        }

        #region Properties

        #endregion

        #region Fields
        private IGraphicsDevice device = null;

        #endregion
    }
}
