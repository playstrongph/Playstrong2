using System.Collections;
using UnityEngine;

namespace JondiBranchLogic
{
    public interface ICoroutineTree
    {
        /// <summary>
        /// Artificial root node.
        /// Does not contain an actual coroutine.
        /// Main parent or origin point for the family of coroutines
        /// </summary>
        ICoroutineNode Root { get; set; }

        /// <summary>
        /// Node which is currently being executed.
        /// Points to Root when the tree is empty.
        /// </summary>
        ICoroutineNode CurrentNode { get; set; }

        /// <summary>
        /// Returns true if the tree is empty, false otherwise.
        /// </summary>
        bool Empty { get; }

        /// <summary>
        /// Signals the end of the current coroutine sequence.
        /// </summary>
        void EndSequence();

        /// <summary>
        /// Initialize local monobehaviour reference
        /// </summary>
        /// <param name="mono"></param>
        void CoroutineRunner(MonoBehaviour mono);

        /// <summary>
        /// Start processing of the tree.
        /// Called during the Ctor initialization "new CoroutineTree"
        /// </summary>
        void Start();

        /// <summary>
        /// Add a coroutine as child of the current node.
        /// Current node is the node being processed
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        void AddCurrent(IEnumerator value);

        /// <summary>
        /// Add a coroutine as a child of the root node.
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        void AddRoot(IEnumerator value);

        /// <summary>
        /// Add a coroutine as a sibling of the current node
        /// This is processed after all children of the current node are done
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        void AddSibling(IEnumerator value);

        /// <summary>
        /// Removes all pending coroutines.
        /// </summary>
        void CleanUp();
    }
}