using System;
using System.Windows;
using System.Windows.Interop;

namespace DirectX.Wpf
{
    /// <summary>
    /// Image Source rendered by Direct3D.
    /// </summary>
    public class Direct3DImageSource : D3DImage, IDisposable
    {
        /// <summary>
        /// Invalidates current Frame.
        /// </summary>
        public void Invalidate()
        {
            if (this.backBuffer != null)
            {
                base.Lock();
                base.AddDirtyRect(new Int32Rect(0, 0, base.PixelWidth, base.PixelHeight));
                base.Unlock();
            }
        }

        /// <summary>
        /// Sets the Direct3D Output. Must be overriden in Derived Classes.
        /// </summary>
        /// <param name="backBuffer">Back Buffer the Direct3D renders to.</param>
        public virtual void SetBackBuffer(object backBuffer)
        {
            this.backBuffer = backBuffer;
        }

        /// <summary>
        /// Cleans up Resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.backBuffer = null;
        }

        #region Properties

        #endregion

        #region Fields

        private object backBuffer = null;

        #endregion
    }
}
