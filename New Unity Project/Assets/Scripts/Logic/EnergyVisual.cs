using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class EnergyVisual : MonoBehaviour, IEnergyVisual
    {   
        
        /// <summary>
        /// Energy fill image
        /// </summary>
        [SerializeField] private Image icon;
        public Image Icon { get => icon; set => icon = value; }
        
        /// <summary>
        /// Energy text in percentage int
        /// </summary>
        [SerializeField] private TextMeshProUGUI text;
        public TextMeshProUGUI Text { get => text; set => text = value; }
        
        /// <summary>
        /// Updates the displayed energy text and bar fill
        /// EXCLUSIVELY used for turn controller update hero timers 
        /// </summary>
        /// <param name="energyValue"></param>
        public void UpdateEnergyTextAndBarFill(int energyValue)
        {
            //Clamps the displayed text to 100%
            var energyDisplayText = Mathf.Min(100, energyValue);
            
            text.text = energyDisplayText.ToString() +"%";
            
            Icon.fillAmount = energyDisplayText/100f;
        }
        
        /// <summary>
        /// Updates the displayed energy text and bar fill
        /// Used in queued visual commands
        /// </summary>
        /// <param name="energyValue"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        public IEnumerator SetEnergyTextAndBarFill(int energyValue, IHero hero)
        {
            //Clamps the displayed text to 100%
            var energyDisplayText = Mathf.Min(100, energyValue);
            var visualTree = hero.CoroutineTrees.MainVisualTree;
            
            text.text = energyDisplayText.ToString() +"%";
            
            Icon.fillAmount = energyDisplayText/100f;
            
            visualTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Sets the energy percentage text color
        /// used by abilities like slow and haste
        /// </summary>
        /// <param name="textColor"></param>
        /// <param name="hero"></param>
        public IEnumerator SetEnergyTextColor(Color textColor, IHero hero)
        {
            var visualTree = hero.CoroutineTrees.MainVisualTree;
            
            text.color = textColor;
            
            visualTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Sets the energy bar color
        /// used by abilities like slow and haste
        /// </summary>
        /// <param name="energyBarColor"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        public IEnumerator SetBarFillColor(Color energyBarColor, IHero hero)
        {
            var visualTree = hero.CoroutineTrees.MainVisualTree;
            
            Icon.color = energyBarColor;
            
            visualTree.EndSequence();
            yield return null;
        }
    }
}