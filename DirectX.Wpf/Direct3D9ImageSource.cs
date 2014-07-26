using System.Windows;
using System.Windows.Interop;
using SharpDX.Direct3D9;

namespace DirectX.Wpf
{
    /// <summary>
    /// Image Source rendered by Direct3D 9.
    /// </summary>
    public class Direct3D9ImageSource : Direct3DImageSource
    {
        /// <summary>
        /// Sets the Direct3D Output.
        /// </summary>
        /// <param name="backBuffer">Back Buffer the Direct3D renders to.</param>
        public override void SetBackBuffer(object backBuffer)
        {
            Texture texture = backBuffer as Texture;
            if (texture != null)
            {
                using (Surface surface = texture.GetSurfaceLevel(0))
                {
                    base.Lock();
                    base.SetBackBuffer(D3DResourceType.IDirect3DSurface9, surface.NativePointer);
                    base.AddDirtyRect(new Int32Rect(0, 0, base.PixelWidth, base.PixelHeight));
                    base.Unlock();
                }
            }
            base.SetBackBuffer(backBuffer);
        }
    }
}
