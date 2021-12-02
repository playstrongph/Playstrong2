using TMPro;
using UnityEngine.UI;

namespace Logic
{
    public interface IArmorVisual
    {
        Image Icon { get; }
        TextMeshProUGUI Text { get; }
    }
}