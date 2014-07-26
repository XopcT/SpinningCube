﻿using System;

namespace GraphicsEngine
{
    /// <summary>
    /// Defines an Interface to render a Scene.
    /// </summary>
    public interface IRenderer : IDisposable
    {
        /// <summary>
        /// Resets the Renderer.
        /// </summary>
        /// <param name="width">Width of the Viewport.</param>
        /// <param name="height">Height of the Viewport.</param>
        void Reset(int width, int height);

        /// <summary>
        /// Renders a Scene.
        /// </summary>
        /// <param name="scene">Scene to render.</param>
        /// <param name="elapsedTime">Time elapsed since previous Frame.</param>
        void Render(Scene scene, TimeSpan elapsedTime);
    }
}