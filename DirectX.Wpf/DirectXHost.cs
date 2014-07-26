using GraphicsEngine;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace DirectX.Wpf
{
    public class DirectXHost : FrameworkElement, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public DirectXHost()
        {
            IGraphicsDevice device = new GraphicsEngine.Direct3D9.GraphicsDevice(GetDesktopWindow());
            IRenderer renderer = new GraphicsEngine.Direct3D9.ForwardRenderer(device);

            this.Renderer = renderer;
            this.Renderer.Reset(1, 1);
            // TODO Make it possible to set another Type of ImageSource.
            this.Frame = new Direct3D9ImageSource();
            this.Frame.IsFrontBufferAvailableChanged += this.OnFrameIsFrontBufferAvailableChange;
        }

        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Renders a Frame.
        /// </summary>
        public void Render()
        {
            if (this.IsInDesignMode || this.Renderer == null)
                return;
            this.Renderer.Render(null, TimeSpan.Zero);
            this.Frame.Invalidate();
        }

        /// <summary>
        /// Handles Rendering the Element.
        /// </summary>
        /// <param name="drawingContext">Drawing Context.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawImage(this.Frame, new Rect(this.RenderSize));
        }

        /// <summary>
        /// Handles Rendering the Element.
        /// </summary>
        private void OnRender(object sender, EventArgs e)
        {
            if (this.isRendering)
                this.Render();
        }

        /// <summary>
        /// Updates the Rendering State of the Element.
        /// </summary>
        private void UpdateIsRendering()
        {
            // Checking if Rendering is available:
            bool newValue = !this.IsInDesignMode
                //&& this.IsVisible
                && this.VisualParent != null
                && this.Renderer != null
                && this.Frame.IsFrontBufferAvailable;
            // Checking if Rendering State changed:
            //if (this.isRendering == newValue)
            //    return;
            // Updating Rendering State:
            this.isRendering = newValue;
            if (this.isRendering)
                CompositionTarget.Rendering += this.OnRender;
            else
                CompositionTarget.Rendering -= this.OnRender;
        }

        /// <summary>
        /// Handles changing the Visual Parent.
        /// </summary>
        /// <param name="oldParent">Old Value of Visual Parent.</param>
        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            this.UpdateIsRendering();
        }

        /// <summary>
        /// Handles changing the Renderer.
        /// </summary>
        private void OnRenererChange()
        {
            this.UpdateIsRendering();
        }

        /// <summary>
        /// Handles changing the Frame's IsFrontBufferAvailable.
        /// </summary>
        private void OnFrameIsFrontBufferAvailableChange(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.UpdateIsRendering();
        }

        /// <summary>
        /// Arranges the Element.
        /// </summary>
        /// <param name="finalSize">Element's Size.</param>
        /// <returns>Computed Element Size.</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            base.ArrangeOverride(finalSize);
            // Resetting the Renderer:
            if (this.Renderer != null)
            {
                this.Renderer.Reset((int)base.DesiredSize.Width, (int)base.DesiredSize.Height);
                this.Frame.SetBackBuffer(this.Renderer.GetBackBuffer());
            }
            return finalSize;
        }

        /// <summary>
        /// Mesures the Size of the Element.
        /// </summary>
        /// <param name="availableSize">Available Size for the Element.</param>
        /// <returns>Computed Element Size.</returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            int width = (int)Math.Ceiling(availableSize.Width);
            int height = (int)Math.Ceiling(availableSize.Height);
            return new Size(width, height);
        }

        #region Events

        /// <summary>
        /// Occurs when a Property Changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged Event.
        /// </summary>
        private void OnPropertyChanged(object sender, [CallerMemberName()]string propertyName = "")
        {
            var temp = this.PropertyChanged;
            if (temp != null)
                temp(sender, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets/retrieves a Renderer for the Scene.
        /// </summary>
        public IRenderer Renderer { get; set; }

        /// <summary>
        /// Sets/retrieves a Frame Source.
        /// </summary>
        public Direct3DImageSource Frame { get; set; }

        /// <summary>
        /// Retrieves whether the Element is in Design Mode.
        /// </summary>
        public bool IsInDesignMode
        {
            get { return DesignerProperties.GetIsInDesignMode(this); }
        }

        /// <summary>
        /// Retrieves the Number of Visual Children.
        /// </summary>
        protected override int VisualChildrenCount
        {
            get { return 0; }
        }

        #endregion

        #region Fields
        private bool isRendering = false;

        #endregion
    }
}
