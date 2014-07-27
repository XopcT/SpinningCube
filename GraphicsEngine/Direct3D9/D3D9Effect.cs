
namespace GraphicsEngine.Direct3D9
{
    /// <summary>
    /// Shader Effect for Direct3D 9.
    /// </summary>
    public class D3D9Effect : EffectBase
    {
        /// <summary>
        /// Sets/retrieves the Vertex Shader.
        /// </summary>
        public SharpDX.Direct3D9.VertexShader VertexShader { get; set; }

        /// <summary>
        /// Sets/retrieves the Pixel Shader.
        /// </summary>
        public SharpDX.Direct3D9.PixelShader PixelShader { get; set; }
    }
}
