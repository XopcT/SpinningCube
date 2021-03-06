﻿using System;
using System.Collections.Generic;

namespace GraphicsEngine
{
    /// <summary>
    /// Defines an Interface of a Graphics Device.
    /// </summary>
    public interface IGraphicsDevice : IDisposable
    {
        /// <summary>
        /// Begins Frame Rendering.
        /// </summary>
        /// <param name="color">Color to fill the Frame.</param>
        void BeginFrame(int color);

        /// <summary>
        /// Begins Frame Rendering.
        /// </summary>
        /// <param name="color">Color to fill the Frame.</param>
        /// <param name="depth">Value to fill the Depth.</param>
        /// <param name="stencil">Value to fill the Stencil.</param>
        void BeginFrame(int color, float depth, int stencil);

        /// <summary>
        /// Ends Frame Rendering.
        /// </summary>
        void EndFrame();

        /// <summary>
        /// Draws specified Model.
        /// </summary>
        /// <param name="model">Model to draw.</param>
        /// <param name="effect">Effect to draw Model with.</param>
        void DrawModel(Model model, EffectBase effect);

        /// <summary>
        /// Sets up a Camera to draw with.
        /// </summary>
        /// <param name="camera">Camera to draw with.</param>
        void SetupCamera(Camera camera);

        /// <summary>
        /// Sets render Target to the Device.
        /// </summary>
        /// <param name="index">Index of the Render Target.</param>
        /// <param name="surface">Render Target Instance.</param>
        void SetRenderTarget(int index, object surface);

        /// <summary>
        /// Creates a Vertex Buffer.
        /// </summary>
        /// <typeparam name="VertexType">Type of Vertices.</typeparam>
        /// <param name="vertices">Vertices to create Buffer from.</param>
        /// <returns>Vertex Buffer Instance.</returns>
        VertexBufferBase CreateVertexBuffer<VertexType>(IEnumerable<VertexType> vertices)
            where VertexType : IVertex;

        /// <summary>
        /// Creates an Index Buffer.
        /// </summary>
        /// <typeparam name="IndexType">Type of Indices.</typeparam>
        /// <param name="indices">Indices to create Buffer from.</param>
        /// <returns>Index Buffer Instance.</returns>
        IndexBufferBase CreateIndexBuffer<IndexType>(IEnumerable<IndexType> indices);

        /// <summary>
        /// Creates Vertex Shader.
        /// </summary>
        /// <param name="bytecode">Shader's Bytecode.</param>
        /// <returns>Vertex Shader Instance.</returns>
        object CreateVertexShader(object bytecode);

        /// <summary>
        /// Creates Pixel Shader.
        /// </summary>
        /// <param name="bytecode">Shader's Bytecode.</param>
        /// <returns>Pixel Shader Instance.</returns>
        object CreatePixelShader(object bytecode);

        /// <summary>
        /// Creates a Texture to render to.
        /// </summary>
        /// <param name="width">Width of the Render Target.</param>
        /// <param name="height">Height of the Render Target.</param>
        /// <returns>Render Target Instance.</returns>
        object CreateRenderTargetTexture(int width, int height);
    }
}
