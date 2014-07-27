using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using GraphicsEngine;

namespace DirectX.Wpf
{
    /// <summary>
    /// Element that hosts a DirectX Scene.
    /// </summary>
    public class DirectXHost : FrameworkElement
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public DirectXHost()
        {
            // TODO Make it possible to set another Type of ImageSource.
            this.Frame = new Direct3D9ImageSource();
            this.Frame.IsFrontBufferAvailableChanged += this.OnFrameIsFrontBufferAvailableChange;
        }

        /// <summary>
        /// Renders a Frame.
        /// </summary>
        public void Render()
        {
            if (this.IsInDesignMode || this.Renderer == null || this.Scene == null)
                return;
            this.Frame.Invalidate();
            this.Renderer.Render(this.scene, timer.Elapsed);
            timer.Restart();
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
                && this.IsVisible
                && this.VisualParent != null
                && this.Renderer != null
                && this.Frame.IsFrontBufferAvailable;
            // Checking if Rendering State changed:
            if (this.isRendering == newValue)
                return;
            // Updating Rendering State:
            this.isRendering = newValue;
            if (this.isRendering)
            {
                // Rendering started:
                CompositionTarget.Rendering += this.OnRender;
                this.timer.Start();
            }
            else
            {
                // Rendering stopped:
                CompositionTarget.Rendering -= this.OnRender;
                this.timer.Stop();
            }
        }

        private void UpdateSize()
        {
            if (this.Renderer != null)
            {
                this.Renderer.Reset((int)base.DesiredSize.Width, (int)base.DesiredSize.Height);
                this.Frame.SetBackBuffer(this.Renderer.GetBackBuffer());
            }
            if (this.Scene != null)
            {
                this.Scene.ViewportWidth = (float)base.DesiredSize.Width;
                this.Scene.ViewportHeight = (float)base.DesiredSize.Height;
            }
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
            this.UpdateSize();
        }

        /// <summary>
        /// Handles changing the Scene.
        /// </summary>
        private void OnSceneChange()
        {
            this.UpdateSize();
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
            this.UpdateSize();
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

        #region Properties

        /// <summary>
        /// Sets/retrieves a Frame Source.
        /// </summary>
        public Direct3DImageSource Frame { get; set; }

        /// <summary>
        /// Sets/retrieves a Renderer for the Scene.
        /// </summary>
        public IRenderer Renderer
        {
            get { return this.renderer; }
            set
            {
                this.renderer = value;
                this.OnRenererChange();
            }
        }

        /// <summary>
        /// Sets/retrieves a Scene to render.
        /// </summary>
        public Scene Scene
        {
            get { return this.scene; }
            set
            {
                this.scene = value;
                this.OnSceneChange();
            }
        }

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
        private IRenderer renderer = null;
        private Scene scene = null;
        private Stopwatch timer = new Stopwatch();

        #endregion
    }
}
