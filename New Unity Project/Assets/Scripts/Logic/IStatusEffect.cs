using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IStatusEffect
{
    /// <summary>
    /// Interface access to status effect icon
    /// </summary>
    Image Icon { get; set; }
        
    /// <summary>
    /// Interface access to status effect visual counters text
    /// </summary>
    TextMeshProUGUI CountersText { get; set; }

    //SET IN RUN TIME
        
    /// <summary>
    /// Interface access to status effect name
    /// </summary>
    string StatusEffectName { get; set; }
        
    /// <summary>
    /// Interface access to status effect counters duration
    /// </summary>
    int CountersValue { get; set; }
        
    /// <summary>
    /// Interface access to status effect preview reference 
    /// </summary>
    IPreviewStatusEffect PreviewStatusEffect { get; set; }


}