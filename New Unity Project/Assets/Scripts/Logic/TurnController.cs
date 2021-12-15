using JondiBranchLogic;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Method that controls all the heroes' turns
    /// </summary>
    public class TurnController : MonoBehaviour
    {
        /// <summary>
        /// 100% percent timer full in speed units
        /// </summary>
        [SerializeField] private int timerFull = 500;
        public int TimerFull => timerFull;
        
        /// <summary>
        /// Energy increase per time "tick" (delta time)
        /// </summary>
        [SerializeField] private int speedConstant = 10;
        public int SpeedConstant => speedConstant;

        /// <summary>
        /// Stops all hero timers when true
        /// </summary>
        [SerializeField] private bool freezeTimers = false;
        public bool FreezeTimers
        {
            get => freezeTimers;
            set => freezeTimers = value;
        }
        
        /// <summary>
        /// Turn controller reference to the global trees
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ICoroutineTreesAsset))]
        public Object coroutineTrees;

        private ICoroutineTreesAsset CoroutineTrees
        {
            get => coroutineTrees as ICoroutineTreesAsset;
            set => coroutineTrees = value as Object;
        }


        //SET IN RUNTIME
        
        


        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

    }
}
