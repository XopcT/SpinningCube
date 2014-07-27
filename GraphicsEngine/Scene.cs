
namespace GraphicsEngine
{
    /// <summary>
    /// Scene Graph.
    /// </summary>
    public class Scene
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public Scene()
        {
            this.controller = new SceneController(this);
        }

        /// <summary>
        /// Handles the Mouse Move.
        /// </summary>
        /// <param name="absoluteX">Absolute Mouse X.</param>
        /// <param name="absoluteY">Absolute Mouse Y.</param>
        /// <param name="dX">Distance the Mouse moved in X-Axis.</param>
        /// <param name="dY">Distance the Mouse moved in Y-Axis.</param>
        /// <param name="leftButton">Indicates whether left Mouse Button is pressed.</param>
        /// <param name="rightButton">Indicates whether right Mouse Button is pressed.</param>
        public void OnMouseMove(float absoluteX, float absoluteY, float dX, float dY, bool leftButton, bool rightButton)
        {
            this.controller.OnMouseMove(absoluteX, absoluteY, dX, dY, leftButton, rightButton);
        }

        /// <summary>
        /// Handles changing Viewport Size.
        /// </summary>
        private void OnViewportSizeChange()
        {
            this.controller.OnViewportResize();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves Scene's Camera.
        /// </summary>
        public Camera Camera { get; set; }

        /// <summary>
        /// Sets/retrieves Scene's Model.
        /// </summary>
        public Model Model { get; set; }

        /// <summary>
        /// Sets/retrieves the Width of a Viewport.
        /// </summary>
        public float ViewportWidth
        {
            get { return this.viewportWidth; }
            set
            {
                this.viewportWidth = value;
                this.OnViewportSizeChange();
            }
        }

        /// <summary>
        /// Sets/retireves the Height of a Viewport.
        /// </summary>
        public float ViewportHeight
        {
            get { return this.viewportHeight; }
            set
            {
                this.viewportHeight = value;
                this.OnViewportSizeChange();
            }
        }

        #endregion

        #region Fields
        private SceneController controller = null;
        private float viewportWidth = 0.0f;
        private float viewportHeight = 0.0f;

        #endregion
    }
}
