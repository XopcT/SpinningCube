using System;
using System.Collections.Generic;
using SharpDX;

namespace GraphicsEngine
{
    /// <summary>
    /// Defines a Node on the Scene.
    /// A Node has a Transform and Items. Items represent Models, Lights, Cameras etc.
    /// </summary>
    public class SceneNode
    {
        /// <summary>
        /// Retrieves Node's Item of specified Type.
        /// </summary>
        /// <typeparam name="ItemType">Type of the Item to retireve.</typeparam>
        /// <returns>Item of required Type.</returns>
        public ItemType GetItem<ItemType>()
            where ItemType : class
        {
            object item = null;
            this.items.TryGetValue(typeof(ItemType), out item);
            return item as ItemType;
        }

        /// <summary>
        /// Sets Node's Item of specified Type.
        /// </summary>
        /// <typeparam name="ItemType">Type of an Item to set.</typeparam>
        /// <param name="item">Item to set.</param>
        public void SetItem<ItemType>(ItemType item)
            where ItemType : class
        {
            this.items[typeof(ItemType)] = item;
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the local Transform Matrix for the Node.
        /// </summary>
        public Matrix Transform { get; set; }

        /// <summary>
        /// Sets/retrieves the World Transform Matrix for the Node.
        /// </summary>
        public Matrix WorldTransform { get; set; }

        /// <summary>
        /// Sets/retrieves the Collection of Children Nodes.
        /// </summary>
        public SceneNodeCollection Children
        {
            get { return this.children; }
            set { this.children = null; }
        }

        #endregion

        #region Fields
        private SceneNodeCollection children = new SceneNodeCollection();
        private IDictionary<Type, object> items = new Dictionary<Type, object>();

        #endregion
    }
}
