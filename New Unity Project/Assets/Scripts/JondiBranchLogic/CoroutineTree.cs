using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace JondiBranchLogic
{
   
    /// <summary>
    /// COROUTINE TREE CLASS
    /// A tree of coroutines with depth-first order of execution.
    /// I.e. node -> children -> siblings.
    /// </summary>
    public class CoroutineTree : ICoroutineTree
    {
        /// <summary>
        /// Artificial root node.
        /// Does not contain an actual coroutine.
        /// Main parent or origin point for the family of coroutines
        /// </summary>
        public ICoroutineNode Root { get; set; }
        
        /// <summary>
        /// Use to start coroutines
        /// and Wait function
        /// </summary>
        private MonoBehaviour _mono; 
        
        /// <summary>
        /// Node which is currently being executed.
        /// Points to Root when the tree is empty.
        /// </summary>
        public ICoroutineNode CurrentNode { get; set; }
        
        /// <summary>
        /// Coroutine queue script local reference
        /// </summary>
        private ICoroutineQueue _coroutineQueue;
        
        /// <summary>
        /// Signals the end of the current coroutine sequence.
        /// </summary>
        public void EndSequence()
        {
            _coroutineQueue.CoroutineCompleted();
        }
        
        /// <summary>
        /// New Coroutine tree constructor
        /// </summary>
        public CoroutineTree()
        {
            Root = new CoroutineNode(null);
            CurrentNode = Root;
        }
        
        /// <summary>
        /// Initialize local monobehaviour reference
        /// </summary>
        /// <param name="mono"></param>
        public void CoroutineRunner(MonoBehaviour mono)
        {
            this._mono = mono;
        }
        
        /// <summary>
        /// Start processing of the tree.
        /// Called during the Ctor initialization "new CoroutineTree"
        /// </summary>
        public void Start()
        {
            _coroutineQueue = new CoroutineQueue();
            _coroutineQueue.CoroutineRunner(_mono);
            _mono.StartCoroutine(UpdateTree());
        }
        
        /// <summary>
        /// Add a coroutine as child of the current node.
        /// Current node is the node being processed
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        public void AddCurrent(IEnumerator value)
        {
            CurrentNode.AddChild(value);
        }
        
        //TEST
        /// <summary>
        /// Directly add a visual tree to a logic tree sequence
        /// Gets rid of logic tree wrappers for visual trees.
        /// </summary>
        /// <param name="visualTree"></param>
        /// <param name="value"></param>
        public void AddCurrentVisual(ICoroutineTree visualTree, IEnumerator value)
        {
            visualTree.AddCurrent(value);
        }

        /// <summary>
        /// Add a coroutine as a child of the root node.
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        public void AddRoot(IEnumerator value)
        {
            Root.AddChild(value);
        }
        
        /// <summary>
        /// Add a coroutine as a sibling of the current node
        /// This is processed after all children of the current node are done
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        public void AddSibling(IEnumerator value)
        {
            Root.AddChild(value);
        }
        
       /// <summary>
       /// Inserts delay in seconds before the next coroutine execution
       /// </summary>
       /// <param name="seconds"></param>
       /// <param name="tree"></param>
        public void AddCurrentWait(float seconds, ICoroutineTree tree)
        {        
            CurrentNode.AddChild(Wait(seconds,tree));
        }
        
       /// <summary>
       ///  Inserts delay in seconds before the next root coroutine execution
       /// </summary>
       /// <param name="seconds"></param>
       /// <param name="tree"></param>
        public void AddRootWait(float seconds, ICoroutineTree tree)
        {
            Root.AddChild(Wait(seconds, tree));
        }
        
        /// <summary>
        /// Returns true if the tree is empty, false otherwise.
        /// </summary>
        public bool Empty => Root == CurrentNode && Root.ChildrenCount <= 0;
        
        /// <summary>
        /// Coroutine that start the nodes sequentially under the root
        /// Has a recursive function to process nodes under the current node before proceeding with the other nodes
        /// Priority:  Node -> Children of the Node -> Siblings of the node
        /// </summary>
        private IEnumerator ProcessChildrenOfNode(ICoroutineNode node)
        {
            var i = 0;
            while(i < node.ChildrenCount)
            {
                // Node -> children -> siblings.
                CurrentNode = node[i];
                
                _coroutineQueue.AddToCoroutineQueue(node[i].Value);

                yield return null;

                if (i >= node.ChildrenCount) yield break;

                if(node[i].ChildrenCount > 0)
                {
                    // Recursion on children.
                    yield return _mono.StartCoroutine(ProcessChildrenOfNode(node[i]));
                }
                i++;
            }
            
            // Be defensive about clearing, do it only when everything was executed.
            if (node == Root)
            {
                CurrentNode = Root;
                Root.ClearChildren();
            }
        }
        
        /// <summary>
        /// Starts processing coroutines in the tree
        /// note that once started, this goes on continuously
        /// </summary>
        [SuppressMessage("ReSharper", "IteratorNeverReturns")]
        private IEnumerator UpdateTree()
        {
            while (true)
            {
                if(CurrentNode == Root && Root.ChildrenCount > 0)
                    yield return _mono.StartCoroutine(ProcessChildrenOfNode(Root));
                else
                    yield return null;
            }
        }
        
        /// <summary>
        /// Removes all pending coroutines.
        /// </summary>
        public void CleanUp()
        {
            CurrentNode = Root;
            Root.ClearChildren();
        }
        
        /// <summary>
        /// Delay sequence for coroutine calls
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="tree"></param>
        /// <returns></returns>
        private IEnumerator Wait(float seconds, ICoroutineTree tree)
        {
            yield return new WaitForSeconds(seconds);
            yield return _mono.StartCoroutine(InsertDelay(tree));
            yield return null;

        }
        
        /// <summary>
        /// Inserts delay in seconds
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        private IEnumerator InsertDelay(ICoroutineTree tree)
        {
            tree.EndSequence();
            yield return null;
        }
        
    }
}
