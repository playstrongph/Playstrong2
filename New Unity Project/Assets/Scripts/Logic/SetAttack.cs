using System.Collections;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's attack value and visual text
    /// </summary>
    public class SetAttack : MonoBehaviour, ISetAttack
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void StartAction(int value)
        {
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;

            //set attribute value
            _heroLogic.HeroAttributes.Attack = value;
            visualTree.AddCurrent(SetVisualValue(value));

            
        }

        private IEnumerator SetVisualValue(int value)
        {
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            var baseValue = _heroLogic.HeroAttributes.BaseAttack;
            
            _heroLogic.Hero.HeroVisual.AttackVisual.Text.text = value.ToString();
            _heroLogic.Hero.HeroVisual.AttackVisual.Text.color = GetTextColor(value, baseValue); 
            
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


    }
}