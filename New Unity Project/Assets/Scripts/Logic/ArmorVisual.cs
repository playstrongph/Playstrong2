using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class ArmorVisual : MonoBehaviour, IArmorVisual
    {
        [SerializeField] private Image icon;
        public Image Icon { get => icon; set => icon = value; }

        [SerializeField] private TextMeshProUGUI text;
        public TextMeshProUGUI Text { get => text; set => text = value; }
    }
}