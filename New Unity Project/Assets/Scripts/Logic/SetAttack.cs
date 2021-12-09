using System.Collections;
using UnityEngine;

namespace Logic
{   
    /// <summary>
    /// Sets the hero's attack value and visual text
    /// </summary>
    public class SetAttack : MonoBehaviour
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        private IEnumerator StartAction(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            
            //set attribute value
            _heroLogic.HeroAttributes.Attack = value;
            
            
            
            logicTree.EndSequence();
            yield return null;
        }

        private void SetVisual(int value)
        {
            
        }


    }
}
