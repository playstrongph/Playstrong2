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

        public IEnumerator StartAction(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            
            
            //set attribute value
            _heroLogic.HeroAttributes.Armor = value;
            
            visualTree.AddCurrent(SetVisualValue(value));

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator SetVisualValue(int value)
        {
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            var baseValue = _heroLogic.HeroAttributes.BaseArmor;
            
            _heroLogic.Hero.HeroVisual.ArmorVisual.Text.text = value.ToString();
            _heroLogic.Hero.HeroVisual.ArmorVisual.Text.color = GetTextColor(value, baseValue); 
            
            if(value <=0)
                HideTextAndIcon();
            else
                ShowTextAndIcon();
            
            visualTree.EndSequence();
            yield return null;
        }
        
        private Color GetTextColor(int baseValue, int value)
        {
            if(value>baseValue)
                return Color.green;
            else if (value == baseValue)
                return Color.white;
            else if(value < baseValue)
                return Color.red;
            else
                return Color.white;
        }
        
        private void HideTextAndIcon()
        {
            _heroLogic.Hero.HeroVisual.ArmorVisual.Text.gameObject.SetActive(false);
            _heroLogic.Hero.HeroVisual.ArmorVisual.Icon.gameObject.SetActive(false);
        }
        
        private void ShowTextAndIcon()
        {
            _heroLogic.Hero.HeroVisual.ArmorVisual.Text.gameObject.SetActive(true);
            _heroLogic.Hero.HeroVisual.ArmorVisual.Icon.gameObject.SetActive(true);
        }


    }
}
