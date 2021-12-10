using System.Collections;
using UnityEngine;

namespace Logic
{   
    /// <summary>
    /// Sets the hero's chance value and visual text
    /// </summary>
    public class SetChance : MonoBehaviour, ISetChance
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
            _heroLogic.HeroAttributes.Chance = value;

            logicTree.EndSequence();
            yield return null;
        }

        


    }
}
