using System.Collections;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's fighting spirit value and visual text
    /// </summary>
    public class SetFightingSpirit : MonoBehaviour, ISetFightingSpirit
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Set fighting spirit value 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void StartAction(int value)
        {
            _heroLogic.HeroAttributes.FightingSpirit = value;
            
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
            
            hero.HeroVisual.SetFightingSpiritVisual.StartAction(value);
            
            visualTree.EndSequence();
            yield return null;
        }

        
    }
}