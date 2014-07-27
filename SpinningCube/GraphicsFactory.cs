using System;
using System.Runtime.InteropServices;
using GraphicsEngine;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace SpinningCube
{
    /// <summary>
    /// Creates Graphics Engine Objects.
    /// </summary>
    public class GraphicsFactory : IGraphicsFactory
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public GraphicsFactory()
        {
            this.unityContainer = new UnityContainer().LoadConfiguration("application");
            this.unityContainer.RegisterInstance<IntPtr>(GetDesktopWindow());
        }

        /// <summary>
        /// Creates a Renderer.
        /// </summary>
        /// <returns>Renderer Instance.</returns>
        public IRenderer CreateRenderer()
        {
            return this.unityContainer.Resolve<IRenderer>();
        }

        /// <summary>
        /// Retrieves a Window Handle.
        /// </summary>
        /// <returns>Window Handle.</returns>
        [DllImport("user32.dll", SetLastError = false)]
        private static extern IntPtr GetDesktopWindow();

        #region Properties
        private IUnityContainer unityContainer = null;

        #endregion
    }
}
