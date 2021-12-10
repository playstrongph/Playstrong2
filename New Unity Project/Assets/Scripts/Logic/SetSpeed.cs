using System.Collections;
using UnityEngine;

namespace Logic
{   
    /// <summary>
    /// Sets the hero's speed value and visual text
    /// </summary>
    public class SetSpeed : MonoBehaviour, ISetSpeed
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public IEnumerator StartAction(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            
            //set attribute value
            _heroLogic.HeroAttributes.Speed = value;

            logicTree.EndSequence();
            yield return null;
        }

        


    }
}
