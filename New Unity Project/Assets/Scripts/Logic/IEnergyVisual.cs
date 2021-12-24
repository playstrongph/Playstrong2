using System.Collections;
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
    }
}