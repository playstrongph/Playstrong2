using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JondiBranchLogic
{
    public class CoroutineQueue : ICoroutineQueue
    {

        /// <summary>
        /// Coroutine queue variable for the
        /// CoroutineQueue constructor
        /// </summary>
        private readonly Queue<IEnumerator> _queue;

        /// <summary>
        /// MonoBehavior reference as a coroutine runner
        /// </summary>
        private MonoBehaviour _mono;

        /// <summary>
        /// Initial state for coroutine queue's
        /// </summary>
        private bool _playingQueue = false;

        
        /// <summary>
        /// CoroutineQueue constructor
        /// </summary>
        public CoroutineQueue()
        {
            _queue = new Queue<IEnumerator>();
            //_empty = true;
            
        }
        
        /// <summary>
        /// Initialize local variable coroutine runner _mono
        /// </summary>
        /// <param name="mono"></param>
        public void CoroutineRunner(MonoBehaviour mono)
        {
            _mono = mono;
        }
        
        /// <summary>
        /// Add coroutine to Coroutine Queue
        /// </summary>
        /// <param name="coroutine"></param>
        public void AddToCoroutineQueue(IEnumerator coroutine)
        {
            _queue.Enqueue(coroutine);
        
            if (!_playingQueue)
                PlayFirstCommandFromQueue();

        }

        /// <summary>
        /// Marker for the end of a coroutine method and triggers
        /// the dequeue of the next coroutine in the queue
        /// </summary>
        /// <returns></returns>
        public bool CoroutineCompleted()
        {
            if(_queue.Count > 0)
            {
                PlayFirstCommandFromQueue();
            }else
            {
                _playingQueue = false;
            }

            return true;
        }
        
        //HELPER METHODS
        
        /// <summary>
        /// Executes the first coroutine in the queue
        /// </summary>
        private void PlayFirstCommandFromQueue()
        {
            _playingQueue = true;             
            _mono.StartCoroutine(_queue.Dequeue());     
       
        }
        
        
        
        
    }
}
