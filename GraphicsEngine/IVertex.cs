
namespace GraphicsEngine
{
    /// <summary>
    /// Defines an Interface of a Vertex.
    /// </summary>
    public interface IVertex
    {
        /// <summary>
        /// Retrieves the Size of a Vertex in Bytes.
        /// </summary>
        /// <returns>Size of a Vertex in Bytes.</returns>
        int GetSize();

        /// <summary>
        /// Serializes a Vertex to Float Array to send to GPU.
        /// </summary>
        /// <returns>Serialized Vertex.</returns>
        float[] Serialize();
    }
}
