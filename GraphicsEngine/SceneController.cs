
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
            if (leftButton)
            {
                this.scene.Model.RotationY += -dX * sensitivity;
                this.scene.Model.RotationX += -dY * sensitivity;
            }
            if (rightButton)
            {
                this.scene.Model.PositionX += dX * sensitivity;
                this.scene.Model.PositionY += -dY * sensitivity;
            }
        }

        /// <summary>
        /// Handles resizing Scene's Viewport.
        /// </summary>
        public void OnViewportResize()
        {
            // Updating Camera's Aspect Ratio:
            this.scene.Camera.AspectRatio = this.scene.ViewportWidth / this.scene.ViewportHeight;
        }

        #region Properties

        #endregion

        #region Fields
        private readonly Scene scene = null;
        private readonly float sensitivity = 1.0f / 20;

        #endregion
    }
}
