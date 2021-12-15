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
        /// Sets ths visual energy value and proportional energy bar fill
        /// </summary>
        /// <param name="energyValue"></param>
        public void SetEnergyTextAndBarFill(int energyValue)
        {
            //Clamps the displayed text to 100%
            var energyDisplayText = Mathf.Min(100, energyValue);
            
            text.text = energyDisplayText.ToString() +"%";
            
            Icon.fillAmount = energyDisplayText/100f;
        }
        
        /// <summary>
        /// Sets the energy percentage text color
        /// used by abilities like slow and haste
        /// </summary>
        /// <param name="textColor"></param>
        public void SetEnergyTextColor(Color textColor)
        {
            text.color = textColor;
        }
        
        /// <summary>
        /// Sets the energy bar color
        /// used by abilities like slow and haste
        /// </summary>
        /// <param name="energyBarColor"></param>
        public void SetBarFillColor(Color energyBarColor)
        {
            Icon.color = energyBarColor;
        }
    }
}
