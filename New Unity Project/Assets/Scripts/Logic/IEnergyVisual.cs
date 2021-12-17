using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    /// Sets the energy percentage text color
    /// used by abilities like slow and haste
    /// </summary>
    /// <param name="energyValue"></param>
    void SetEnergyTextAndBarFill(int energyValue);
        
    /// <summary>
    /// Sets the energy bar color
    /// used by abilities like slow and haste
    /// </summary>
    /// <param name="energyBarColor"></param>
    void SetBarFillColor(Color energyBarColor);
}