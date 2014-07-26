using System;

namespace GraphicsEngine
{
    /// <summary>
    /// Vertex which has a Position and a Color.
    /// </summary>
    public struct VertexPositionColor
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="x">X-Coordinate of the Vertex.</param>
        /// <param name="y">Y-Coordinate of the Vertex.</param>
        /// <param name="z">Z-Coordinate of the Vertex.</param>
        /// <param name="color">Vertex Color.</param>
        public VertexPositionColor(float x, float y, float z, Int32 color)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Color = color;
        }

        /// <summary>X-Coordinate of the Vertex.</summary>
        public readonly float X;

        /// <summary>X-Coordinate of the Vertex.</summary>
        public readonly float Y;

        /// <summary>X-Coordinate of the Vertex.</summary>
        public readonly float Z;

        /// <summary>Vertex Color.</summary>
        public readonly Int32 Color;
    }
}
