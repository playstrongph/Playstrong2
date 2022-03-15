using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's health value and visual text
    /// </summary>
    public class SetHealth : MonoBehaviour, ISetHealth
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void StartAction(int value)
        {
            _heroLogic.HeroAttributes.Health = value;
            
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
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

            hero.HeroVisual.SetHealthVisual.StartAction(value);
            
            visualTree.EndSequence();
            yield return null;
        }

    }
}