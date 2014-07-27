
namespace GraphicsEngine
{
    /// <summary>
    /// Camera to render a Scene.
    /// </summary>
    public class Camera
    {
        #region Properties

        /// <summary>
        /// Sets/retrieves the X-Coordinate of the Camera.
        /// </summary>
        public float PositionX { get; set; }

        /// <summary>
        /// Sets/retrieves the Y-Coordinate of the Camera.
        /// </summary>
        public float PositionY { get; set; }

        /// <summary>
        /// Sets/retrieves the Z-Coordinate of the Camera.
        /// </summary>
        public float PositionZ { get; set; }

        /// <summary>
        /// Sets/retrieves the X-Coordinate the Camera looks at.
        /// </summary>
        public float TargetX { get; set; }

        /// <summary>
        /// Sets/retrieves the X-Coordinate the Camera looks at.
        /// </summary>
        public float TargetY { get; set; }

        /// <summary>
        /// Sets/retrieves the X-Coordinate the Camera looks at.
        /// </summary>
        public float TargetZ { get; set; }

        /// <summary>
        /// Sets/retrieves the Camera Rotation over the X-Axis.
        /// </summary>
        public float RotationX { get; set; }

        /// <summary>
        /// Sets/retrieves the Camera Rotation over the Y-Axis.
        /// </summary>
        public float RotationY { get; set; }

        /// <summary>
        /// Sets/retrieves the Camera Rotation over the Z-Axis.
        /// </summary>
        public float RotationZ { get; set; }

        /// <summary>
        /// Sets/retrieves the Camera's Field of View.
        /// </summary>
        public float Fov { get; set; }

        /// <summary>
        /// Sets/retrieves the Camera's Aspect Ratio.
        /// </summary>
        public float AspectRatio { get; set; }

        /// <summary>
        /// Sets/retrieves the Camera's Near Plane.
        /// </summary>
        public float NearPlane { get; set; }

        /// <summary>
        /// Sets/retrieves the Camera's Far Plane.
        /// </summary>
        public float FarPlane { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
