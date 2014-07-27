
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
        public VertexBufferBase VertexBuffer { get; set; }

        /// <summary>
        /// Sets/retrieves Buffer of Model Indices.
        /// </summary>
        public IndexBufferBase IndexBuffer { get; set; }

        /// <summary>
        /// Sets/retrieves an Effect to render the Model.
        /// </summary>
        public EffectBase Effect { get; set; }

        /// <summary>
        /// Sets/retrieves the X-Coordinate of the Model.
        /// </summary>
        public float PositionX { get; set; }

        /// <summary>
        /// Sets/retrieves the Y-Coordinate of the Model.
        /// </summary>
        public float PositionY { get; set; }

        /// <summary>
        /// Sets/retrieves the Z-Coordinate of the Model.
        /// </summary>
        public float PositionZ { get; set; }

        /// <summary>
        /// Sets/retrieves the Model Rotation over the X-Axis.
        /// </summary>
        public float RotationX { get; set; }

        /// <summary>
        /// Sets/retrieves the Model Rotation over the Y-Axis.
        /// </summary>
        public float RotationY { get; set; }

        /// <summary>
        /// Sets/retrieves the Model Rotation over the Z-Axis.
        /// </summary>
        public float RotationZ { get; set; }

    }
}
