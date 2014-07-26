using System;
using SharpDX.Direct3D9;

namespace GraphicsEngine.Direct3D9
{
    /// <summary>
    /// Forward Shading Renderer based on Direct3D 9.
    /// </summary>
    public class ForwardRenderer : IRenderer
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="device">Device to render with.</param>
        public ForwardRenderer(IGraphicsDevice device)
        {
            if (device == null)
                throw new ArgumentNullException("device");
        }

        /// <summary>
        /// Resets the Renderer.
        /// </summary>
        /// <param name="width">Width of the Viewport.</param>
        /// <param name="height">Height of the Viewport.</param>
        public void Reset(int width, int height)
        {
            // Validating new Size of the Viewport:
            if (width < 1) throw new ArgumentOutOfRangeException("width");
            if (height < 1) throw new ArgumentOutOfRangeException("height");
            // Resetting the Render Target:
            if (this.renderTarget != null)
                this.renderTarget.Dispose();
            this.renderTarget = (Texture)this.device.CreateRenderTargetTexture(width, height);
        }

        /// <summary>
        /// Renders a Scene.
        /// </summary>
        /// <param name="scene">Scene to render.</param>
        /// <param name="elapsedTime">Time elapsed since previous Frame.</param>
        public void Render(Scene scene, TimeSpan elapsedTime)
        {
            this.device.BeginFrame();

            this.device.EndFrame();
        }

        /// <summary>
        /// Cleans up Resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (this.device != null)
            {
                this.device.Dispose();
                this.device = null;
            }
        }

        #region Properties

        #endregion

        #region Fields
        private IGraphicsDevice device = null;
        private Texture renderTarget = null;

        #endregion
    }
}
