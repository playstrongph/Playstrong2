using System.Collections;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's armor value and visual text
    /// </summary>
    public class SetArmor : MonoBehaviour, ISetArmor
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void StartAction(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
            _heroLogic.HeroAttributes.Armor = value;

            logicTree.AddCurrent(SetTextVisual(value));
        }
        
        /// <summary>
        /// Logic tree wrapper
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private IEnumerator SetTextVisual(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(TextVisual(value));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Armor text Update 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private IEnumerator TextVisual(int value)
        {
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            var hero = _heroLogic.Hero;
            
            hero.HeroVisual.SetArmorVisual.StartAction(value);
            
            visualTree.EndSequence();
            yield return null;
        }
        
        



    }
}