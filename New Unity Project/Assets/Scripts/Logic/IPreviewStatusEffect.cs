using TMPro;
using UnityEngine.UI;

namespace Logic
{
    public interface IPreviewStatusEffect
    {
        Image Icon { get; set; }
        TextMeshProUGUI NameText { get; set; }
        TextMeshProUGUI DescriptionText { get; set; }
    }
}