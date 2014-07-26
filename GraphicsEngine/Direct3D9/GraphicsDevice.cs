using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using D3D9 = SharpDX.Direct3D9;

namespace GraphicsEngine.Direct3D9
{
    /// <summary>
    /// Defines a Graphics Device based on Direct3D 9.
    /// </summary>
    public class GraphicsDevice : IGraphicsDevice
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public GraphicsDevice(IntPtr handle)
        {
            D3D9.PresentParameters presentParams = new D3D9.PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = D3D9.SwapEffect.Discard;
            presentParams.PresentationInterval = D3D9.PresentInterval.Default;
            presentParams.DeviceWindowHandle = handle;

            this.context = new D3D9.Direct3D();
            this.device = new D3D9.Device(this.context, 0, D3D9.DeviceType.Hardware, IntPtr.Zero, D3D9.CreateFlags.HardwareVertexProcessing, presentParams);
        }

        /// <summary>
        /// Begins Frame Rendering.
        /// </summary>
        /// <param name="color">Color to fill the Frame.</param>
        public void BeginFrame(int color)
        {
            this.BeginFrame(color, 1.0f, 0);
        }

        /// <summary>
        /// Begins Frame Rendering.
        /// </summary>
        /// <param name="color">Color to fill the Frame.</param>
        /// <param name="depth">Value to fill the Depth.</param>
        /// <param name="stencil">Value to fill the Stencil.</param>
        public void BeginFrame(int color, float depth, int stencil)
        {
            this.device.Clear(D3D9.ClearFlags.Target, SharpDX.ColorBGRA.FromRgba(color), depth, stencil);
            this.device.BeginScene();
        }

        /// <summary>
        /// Ends Frame Rendering.
        /// </summary>
        public void EndFrame()
        {
            this.device.EndScene();
            this.device.Present();
        }

        /// <summary>
        /// Draws specified Model.
        /// </summary>
        /// <param name="model">Model to draw.</param>
        /// <param name="effect">Effect to draw Model with.</param>
        public void DrawModel(Model model, object effect)
        {
            VertexBuffer vertexBuffer = (VertexBuffer)model.VertexBuffer;
            this.device.SetStreamSource(0, (D3D9.VertexBuffer)vertexBuffer.Buffer, 0, vertexBuffer.VertexSize);
            // TODO Apply Vertex Declaration
            this.device.Indices = (D3D9.IndexBuffer)model.IndexBuffer.Buffer;
            this.device.DrawIndexedPrimitive(D3D9.PrimitiveType.TriangleList, 0, 0, vertexBuffer.VertexCount, 0, model.IndexBuffer.PrimitiveCount);
        }

        /// <summary>
        /// Creates a Vertex Buffer.
        /// </summary>
        /// <typeparam name="VertexType">Type of Vertices.</typeparam>
        /// <param name="vertices">Vertices to create Buffer from.</param>
        /// <returns>Vertex Buffer Instance.</returns>
        public GraphicsEngine.VertexBuffer CreateVertexBuffer<VertexType>(IEnumerable<VertexType> vertices)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an Index Buffer.
        /// </summary>
        /// <typeparam name="IndexType">Type of Indices.</typeparam>
        /// <param name="indices">Indices to create Buffer from.</param>
        /// <returns>Index Buffer Instance.</returns>
        public IndexBuffer CreateIndexBuffer<IndexType>(IEnumerable<IndexType> indices)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a Texture to render to.
        /// </summary>
        /// <param name="width">Width of the Render Target.</param>
        /// <param name="height">Height of the Render Target.</param>
        /// <returns>Render Target Instance.</returns>
        public object CreateRenderTargetTexture(int width, int height)
        {
            return new D3D9.Texture(this.device, width, height, 1, D3D9.Usage.RenderTarget, D3D9.Format.A8R8G8B8, D3D9.Pool.Default);
        }

        /// <summary>
        /// Sets render Target to the Device.
        /// </summary>
        /// <param name="index">Index of the Render Target.</param>
        /// <param name="surface">Render Target Instance.</param>
        public void SetRenderTarget(int index, object surface)
        {
            this.device.SetRenderTarget(0, (D3D9.Surface)surface);
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
        private D3D9.Direct3D context = null;
        private D3D9.Device device = null;

        #endregion
    }
}
