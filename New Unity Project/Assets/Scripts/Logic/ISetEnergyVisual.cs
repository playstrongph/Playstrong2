using UnityEngine;

namespace Logic
{
    public interface ISetEnergyVisual
    {
        /// <summary>
        /// Updates the displayed energy text and bar fill
        /// EXCLUSIVELY used for turn controller update hero timers 
        /// </summary>
        /// <param name="energyValue"></param>
        void UpdateEnergyTextAndBarFill(int energyValue);

        /// <summary>
        ///  Updates the displayed energy text and bar fill
        /// </summary>
        /// <param name="energyValue"></param>
        /// <param name="hero"></param>
        void SetEnergyTextAndBarFill(int energyValue, IHero hero);

        /// <summary>
        /// Sets the energy percentage text color
        /// </summary>
        /// <param name="textColor"></param>
        /// <param name="hero"></param>
        void SetEnergyTextColor(Color textColor, IHero hero);

        /// <summary>
        /// Sets the energy bar color used by abilities like slow and haste
        /// </summary>
        /// <param name="energyBarColor"></param>
        /// <param name="hero"></param>
        void SetBarFillColor(Color energyBarColor, IHero hero);
    }
}