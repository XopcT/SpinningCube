using System;
using SharpDX.Direct3D9;

namespace GraphicsEngine.Direct3D9
{
    /// <summary>
    /// Defines a Graphics Device based on Direct3D 9.
    /// </summary>
    public class D3D9Device : IGraphicsDevice
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public D3D9Device(IntPtr handle)
        {
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.DeviceWindowHandle = handle;
            presentParams.PresentationInterval = PresentInterval.Default;

            this.context = new Direct3DEx();
            this.device = new DeviceEx(this.context, 0, DeviceType.Hardware, IntPtr.Zero,
                CreateFlags.HardwareVertexProcessing | CreateFlags.Multithreaded | CreateFlags.FpuPreserve,
                presentParams);
        }

        /// <summary>
        /// Creates a Texture to render to.
        /// </summary>
        /// <param name="width">Width of the Render Target.</param>
        /// <param name="height">Height of the Render Target.</param>
        /// <returns>Render Target Instance.</returns>
        public object CreateRenderTargetTexture(int width, int height)
        {
            return new Texture(this.device, width, height, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
        }

        /// <summary>
        /// Sets render Target to the Device.
        /// </summary>
        /// <param name="index">Index of the Render Target.</param>
        /// <param name="surface">Render Target Instance.</param>
        public void SetRenderTarget(int index, object surface)
        {
            this.device.SetRenderTarget(0, (Surface)surface);
        }

        /// <summary>
        /// Cleans up Resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (this.context != null)
            {
                this.context.Dispose();
                this.context = null;
            }
            if (this.device != null)
            {
                this.device.Dispose();
                this.context = null;
            }
        }

        #region Properties

        #endregion

        #region Fields
        private Direct3DEx context = null;
        private DeviceEx device = null;

        #endregion



    }
}
