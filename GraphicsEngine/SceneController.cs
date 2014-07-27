
namespace GraphicsEngine
{
    /// <summary>
    /// Controls the Scene Behavior.
    /// </summary>
    public class SceneController
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="scene">Scene to control.</param>
        public SceneController(Scene scene)
        {
            this.scene = scene;
        }

        /// <summary>
        /// Handles resizing Scene's Viewport.
        /// </summary>
        public void OnViewportResize()
        {
            this.scene.Camera.AspectRatio = this.scene.ViewportWidth / this.scene.ViewportHeight;
            this.scene.Camera.Fov = SharpDX.MathUtil.Pi / 2.0f;
            this.scene.Camera.NearPlane = 0.5f;
            this.scene.Camera.FarPlane = 20.0f;
        }

        #region Properties

        #endregion

        #region Fields
        private readonly Scene scene = null;

        #endregion
    }
}
