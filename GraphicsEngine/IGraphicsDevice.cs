using System;

namespace GraphicsEngine
{
    /// <summary>
    /// Defines an Interface of a Graphics Device.
    /// </summary>
    public interface IGraphicsDevice : IDisposable
    {
        /// <summary>
        /// Sets render Target to the Device.
        /// </summary>
        /// <param name="index">Index of the Render Target.</param>
        /// <param name="surface">Render Target Instance.</param>
        void SetRenderTarget(int index, object surface);

        /// <summary>
        /// Creates a Texture to render to.
        /// </summary>
        /// <param name="width">Width of the Render Target.</param>
        /// <param name="height">Height of the Render Target.</param>
        /// <returns>Render Target Instance.</returns>
        object CreateRenderTargetTexture(int width, int height);
    }
}
