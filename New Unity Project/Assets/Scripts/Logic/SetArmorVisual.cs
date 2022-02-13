using System.Collections;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's armor visual text
    /// </summary>
    public class SetArmorVisual : MonoBehaviour, ISetArmorVisual
    {
        private IHeroVisual _heroVisual;
        
        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
        }
        
        /// <summary>
        /// Sets the armor visual value
        /// </summary>
        public void StartAction(int value)
        {
            SetVisualValue(value);
        }

        private void SetVisualValue(int value)
        {
            var heroLogic = _heroVisual.Hero.HeroLogic;
            var armorValue = heroLogic.HeroAttributes.Armor;
            
            //Clamp minimum display value to zero
            //var armorVisualValue = Mathf.Max(0, armorValue);
            
            //TEST
            var armorVisualValue = Mathf.Max(0, value);
            
            _heroVisual.ArmorVisual.Text.text = armorVisualValue.ToString();

            if(armorValue <=0)
                HideTextAndIcon();
            else
                ShowTextAndIcon();
        }

        private void HideTextAndIcon()
        {
            _heroVisual.ArmorVisual.Text.gameObject.SetActive(false);
            _heroVisual.ArmorVisual.Icon.gameObject.SetActive(false);
        }
        
        private void ShowTextAndIcon()
        {
            _heroVisual.ArmorVisual.Text.gameObject.SetActive(true);
            _heroVisual.ArmorVisual.Icon.gameObject.SetActive(true);
        }


    }
}