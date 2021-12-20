using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface IEnergyVisual
    {
        /// <summary>
        /// Energy fill image
        /// </summary>
        Image Icon { get; }
        
        /// <summary>
        ///  Energy text in percentage int
        /// </summary>
        TextMeshProUGUI Text { get; }

        /// <summary>
        /// Updates the displayed energy text and bar fill
        /// EXCLUSIVELY used for turn controller update hero timers 
        /// </summary>
        /// <param name="energyValue"></param>
        void UpdateEnergyTextAndBarFill(int energyValue);
        
        /// <summary>
        /// Updates the displayed energy text and bar fill
        /// Used in queued visual commands
        /// </summary>
        /// <param name="energyValue"></param>
        void SetEnergyTextAndBarFill(int energyValue);
        
        /// <summary>
        /// Sets the energy bar color
        /// used by abilities like slow and haste
        /// </summary>
        /// <param name="energyBarColor"></param>
        void SetBarFillColor(Color energyBarColor);
        
        /// <summary>
        /// Sets the energy percentage text color
        /// used by abilities like slow and haste
        /// </summary>
        /// <param name="textColor"></param>
        void SetEnergyTextColor(Color textColor);
    }
}