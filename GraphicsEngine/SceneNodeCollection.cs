using System.Collections.Generic;

namespace GraphicsEngine
{
    /// <summary>
    /// Contains Scene Nodes.
    /// </summary>
    public class SceneNodeCollection : ICollection<SceneNode>
    {
        /// <summary>
        /// Adds Scene Node to the Collection.
        /// </summary>
        /// <param name="item">Node to add.</param>
        public void Add(SceneNode item)
        {
            this.nodes.Add(item);
        }

        /// <summary>
        /// Removes all Scene Nodes.
        /// </summary>
        public void Clear()
        {
            this.nodes.Clear();
        }

        /// <summary>
        /// Retrieves whether collection contains specified Node.
        /// </summary>
        /// <param name="item">Node to check.</param>
        /// <returns>True if Collection contains specified Node, False otherwise.</returns>
        public bool Contains(SceneNode item)
        {
            return this.nodes.Contains(item);
        }

        public void CopyTo(SceneNode[] array, int arrayIndex)
        {
            this.nodes.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes specified Node from the Collection.
        /// </summary>
        /// <param name="item">Node to remove.</param>
        /// <returns>True if Node was removed, False otherwise.</returns>
        public bool Remove(SceneNode item)
        {
            return this.nodes.Remove(item);
        }

        public IEnumerator<SceneNode> GetEnumerator()
        {
            return this.nodes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.nodes.GetEnumerator();
        }

        #region Properties

        /// <summary>
        /// Retrieves the Number of Nodes in Collection.
        /// </summary>
        public int Count
        {
            get { return this.nodes.Count; }
        }

        /// <summary>
        /// Retrieves whether Collection is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.nodes.IsReadOnly; }
        }

        #endregion

        #region Fields
        private IList<SceneNode> nodes = new List<SceneNode>();

        #endregion
    }
}
