
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

        private void OnViewportSizeChange()
        {
            this.controller.OnViewportResize();
        }

        #region Properties

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

        /// <summary>
        /// Sets/retrieves Scene's Camera.
        /// </summary>
        public Camera Camera { get; set; }

        /// <summary>
        /// Sets/retrieves Scene's Model.
        /// </summary>
        public Model Model { get; set; }

        #endregion

        #region Fields
        private SceneController controller = null;
        private float viewportWidth = 0.0f;
        private float viewportHeight = 0.0f;

        #endregion
    }
}
