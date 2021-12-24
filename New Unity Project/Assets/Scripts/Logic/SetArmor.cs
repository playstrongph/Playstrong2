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
            var setArmorVisual = _heroLogic.Hero.HeroVisual.SetArmorVisual;
            
            _heroLogic.HeroAttributes.Armor = value;
            
            setArmorVisual.StartAction();
        }

       

    }
}