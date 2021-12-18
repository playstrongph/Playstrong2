using TMPro;
using UnityEngine.UI;

namespace Logic
{
    public interface IAttackVisual
    {
        Image Icon { get; }
        TextMeshProUGUI Text { get; }
    }
}