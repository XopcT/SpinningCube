using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;
using SharpDX.Direct3D9;

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
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.PresentationInterval = PresentInterval.Default;
            presentParams.DeviceWindowHandle = handle;

            this.context = new Direct3D();
            this.device = new Device(this.context, 0, DeviceType.Hardware, handle, CreateFlags.HardwareVertexProcessing | CreateFlags.Multithreaded | CreateFlags.FpuPreserve, presentParams);
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
            this.device.Clear(ClearFlags.Target, ColorBGRA.FromRgba(color), depth, stencil);
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
        public void DrawModel(Model model, EffectBase effect)
        {
            // Applying Transforms:
            var world = Matrix.RotationYawPitchRoll(model.RotationY, model.RotationX, model.RotationZ)
                * Matrix.Translation(model.PositionX, model.PositionY, model.PositionZ);

            // Setting up Shaders:
            this.device.VertexShader = ((D3D9Effect)effect).VertexShader;
            this.device.PixelShader = ((D3D9Effect)effect).PixelShader;
            this.device.SetVertexShaderConstant(0, world * this.view * this.projection);

            // Setting up Vertex Buffer:
            D3D9VertexBuffer vertexBuffer = (D3D9VertexBuffer)model.VertexBuffer;
            this.device.VertexFormat = vertexBuffer.VertexFormat;
            this.device.VertexDeclaration = vertexBuffer.VertexDeclaration;
            this.device.SetStreamSource(0, vertexBuffer.Buffer, 0, vertexBuffer.VertexSize);

            // TODO Setup Index Buffer

            // Drawing the Model:
            // TODO Draw via DrawIndexedPrimitives
            this.device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3);
        }

        /// <summary>
        /// Sets up a Camera to draw with.
        /// </summary>
        /// <param name="camera">Camera to draw with.</param>
        public void SetupCamera(Camera camera)
        {
            Matrix view = Matrix.LookAtLH(
                new Vector3(camera.PositionX, camera.PositionY, camera.PositionZ),
                new Vector3(0.0f, 0.0f, 0.0f),
                Vector3.Up);
            Matrix projection = Matrix.PerspectiveFovLH(camera.Fov, camera.AspectRatio, camera.NearPlane, camera.FarPlane);
            this.view = view;
            this.projection = projection;
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
        /// Creates a Vertex Buffer.
        /// </summary>
        /// <typeparam name="VertexType">Type of Vertices.</typeparam>
        /// <param name="vertices">Vertices to create Buffer from.</param>
        /// <returns>Vertex Buffer Instance.</returns>
        public GraphicsEngine.VertexBufferBase CreateVertexBuffer<VertexType>(IEnumerable<VertexType> vertices)
            where VertexType : IVertex
        {
            if (!vertices.Any())
                throw new ArgumentException("vertices");

            // Computing Buffer Parameters:
            float[] data = vertices.SelectMany(vertex => vertex.Serialize()).ToArray();
            Type vertexType = typeof(VertexType);
            int vertexCount = vertices.Count();
            int vertexSize = vertices.First().GetSize();
            int bufferSize = vertexSize * vertexCount;
            VertexFormat vertexFormat = VertexFormats[vertexType];
            VertexDeclaration vertexDeclaration = new VertexDeclaration(this.device, VertexElements[vertexType]);

            // Creating Vertex Buffer:
            VertexBuffer buffer = new VertexBuffer(this.device, bufferSize, Usage.None, VertexFormat.Position, Pool.Default);

            // Filling Buffer with Data:
            DataStream stream = buffer.Lock(0, 0, LockFlags.Discard);
            stream.WriteRange(data);
            buffer.Unlock();
            return new D3D9VertexBuffer()
            {
                VertexSize = vertexSize,
                VertexCount = vertexCount,
                Buffer = buffer,
                VertexFormat = vertexFormat,
                VertexDeclaration = vertexDeclaration,
            };
        }

        /// <summary>
        /// Creates an Index Buffer.
        /// </summary>
        /// <typeparam name="IndexType">Type of Indices.</typeparam>
        /// <param name="indices">Indices to create Buffer from.</param>
        /// <returns>Index Buffer Instance.</returns>
        public IndexBufferBase CreateIndexBuffer<IndexType>(IEnumerable<IndexType> indices)
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
            return new Texture(this.device, width, height, 1, Usage.RenderTarget, Format.A8R8G8B8, Pool.Default);
        }

        /// <summary>
        /// Creates Vertex Shader.
        /// </summary>
        /// <param name="bytecode">Shader's Bytecode.</param>
        /// <returns>Vertex Shader Instance.</returns>
        public object CreateVertexShader(object bytecode)
        {
            return new VertexShader((this.device), (ShaderBytecode)bytecode);
        }

        /// <summary>
        /// Creates Pixel Shader.
        /// </summary>
        /// <param name="bytecode">Shader's Bytecode.</param>
        /// <returns>Pixel Shader Instance.</returns>
        public object CreatePixelShader(object bytecode)
        {
            return new PixelShader((this.device), (ShaderBytecode)bytecode);
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
        private Direct3D context = null;
        private Device device = null;
        private Matrix view = Matrix.Identity;
        private Matrix projection = Matrix.Identity;

        // Vertex Formats:
        private static readonly IDictionary<Type, VertexFormat> VertexFormats = new Dictionary<Type, VertexFormat>()
        {
            { typeof(VertexPositionColor), VertexFormat.Position | VertexFormat.Diffuse },
            { typeof(VertexTransformedColored), VertexFormat.PositionRhw | VertexFormat.Diffuse },
        };

        // Vertex Elements:
        private static readonly IDictionary<Type, VertexElement[]> VertexElements = new Dictionary<Type, VertexElement[]>()
        {
            { typeof(VertexPositionColor), new VertexElement[]
                {
                    new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
                    new VertexElement(0, 12, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                    VertexElement.VertexDeclarationEnd,
                }},
            { typeof(VertexTransformedColored), new VertexElement[]
                {
                    new VertexElement(0, 0, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.PositionTransformed, 0),
                    new VertexElement(0, 16, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.Color, 0),
                    VertexElement.VertexDeclarationEnd,
                }},
        };

        #endregion

    }
}
