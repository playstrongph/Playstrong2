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
            //var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            
            
            //set attribute value
            _heroLogic.HeroAttributes.FightingSpirit = value;
            
            //visualTree.AddCurrent(SetVisualValue(value));
            SetVisualValue(value);

            //logicTree.EndSequence();
            //yield return null;
        }

        private void SetVisualValue(int value)
        {
            //var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;

            _heroLogic.Hero.HeroVisual.FightingSpiritVisual.Text.text = value.ToString();
            
            if(value <=0)
                HideTextAndIcon();
            else
                ShowTextAndIcon();
            

            //visualTree.EndSequence();
            //yield return null;
        }
        
        private void HideTextAndIcon()
        {
            _heroLogic.Hero.HeroVisual.FightingSpiritVisual.Text.gameObject.SetActive(false);
            _heroLogic.Hero.HeroVisual.FightingSpiritVisual.Icon.gameObject.SetActive(false);
        }
        
        private void ShowTextAndIcon()
        {
            _heroLogic.Hero.HeroVisual.FightingSpiritVisual.Text.gameObject.SetActive(true);
            _heroLogic.Hero.HeroVisual.FightingSpiritVisual.Icon.gameObject.SetActive(true);
        }

    }
}
