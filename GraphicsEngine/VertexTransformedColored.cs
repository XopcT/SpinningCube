
namespace GraphicsEngine
{
    /// <summary>
    /// Vertex which has a Position and a Color.
    /// </summary>
    public struct VertexTransformedColored : IVertex
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="x">X-Coordinate of the Vertex.</param>
        /// <param name="y">Y-Coordinate of the Vertex.</param>
        /// <param name="z">Z-Coordinate of the Vertex.</param>
        /// <param name="rhw">RHW.</param>
        /// <param name="colorR">Red Component of Vertex' Color.</param>
        /// <param name="colorG">Green Component of Vertex' Color.</param>
        /// <param name="colorB">Blue Component of Vertex' Color.</param>
        /// <param name="colorA">Alpha Component of Vertex' Color.</param>
        public VertexTransformedColored(float x, float y, float z, float rhw, float colorR, float colorG, float colorB, float colorA)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Rhw = rhw;
            this.ColorR = colorR;
            this.ColorG = colorG;
            this.ColorB = colorB;
            this.ColorA = colorA;
        }

        /// <summary>
        /// Retrieves the Size of a Vertex in Bytes.
        /// </summary>
        /// <returns>Size of a Vertex in Bytes.</returns>
        public int GetSize()
        {
            return sizeof(float) * 8;
        }

        /// <summary>
        /// Serializes a Vertex to Float Array to send to GPU.
        /// </summary>
        /// <returns>Serialized Vertex.</returns>
        public float[] Serialize()
        {
            return new float[] { this.X, this.Y, this.Z, this.Rhw, this.ColorR, this.ColorG, this.ColorB, this.ColorA };
        }

        #region Fields

        /// <summary>X-Coordinate of the Vertex.</summary>
        public readonly float X;

        /// <summary>X-Coordinate of the Vertex.</summary>
        public readonly float Y;

        /// <summary>X-Coordinate of the Vertex.</summary>
        public readonly float Z;

        /// <summary>RHW.</summary>
        public readonly float Rhw;

        /// <summary>Red Component of Vertex' Color.</summary>
        public readonly float ColorR;

        /// <summary>Green Component of Vertex' Color.</summary>
        public readonly float ColorG;

        /// <summary>Blue Component of Vertex' Color.</summary>
        public readonly float ColorB;

        /// <summary>Alpha Component of Vertex' Color.</summary>
        public readonly float ColorA;

        #endregion
    }
}
