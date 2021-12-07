using System.Collections;

namespace JondiBranchLogic
{
    public interface ICoroutineNode
    {
        /// <summary>
        /// Actual coroutine.
        /// </summary>
        IEnumerator Value { get; }
        
        /// <summary>
        /// Parent node.
        /// Is null for root of a tree.
        /// </summary>
        CoroutineNode Parent { get; }
        
        /// <summary>
        /// Accessor for a children node.
        /// Does not check for index validity.
        /// </summary>
        /// <param name="i">Index of wanted child.</param>
        /// <returns></returns>
        CoroutineNode this[int i] { get; }

        /// <summary>
        /// Number of children this node has.
        /// </summary>
        int ChildrenCount { get; }

        /// <summary>
        /// Add a coroutine as a child of the node.
        /// </summary>
        /// <param name="coroutine">Coroutine to add.</param>
        /// <returns></returns>
        CoroutineNode AddChild(IEnumerator coroutine);

        /// <summary>
        /// Remove all children of this node.
        /// </summary>
        void ClearChildren();

        
    }
}