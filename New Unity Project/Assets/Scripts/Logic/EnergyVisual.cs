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
    }
}