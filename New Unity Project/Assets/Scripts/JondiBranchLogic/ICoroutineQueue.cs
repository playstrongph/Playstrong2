using System.Collections;
using UnityEngine;

namespace JondiBranchLogic
{
    public interface ICoroutineQueue
    {
        /// <summary>
        /// Initialize local variable coroutine runner _mono
        /// </summary>
        /// <param name="mono"></param>
        void CoroutineRunner(MonoBehaviour mono);

        /// <summary>
        /// Add coroutine to Coroutine Queue
        /// </summary>
        /// <param name="coroutine"></param>
        void AddToCoroutineQueue(IEnumerator coroutine);

        /// <summary>
        /// Marker for the end of a coroutine method and triggers
        /// the dequeue of the next coroutine in the queue
        /// </summary>
        /// <returns></returns>
        bool CoroutineCompleted();
    }
}