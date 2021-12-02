using TMPro;
using UnityEngine.UI;

namespace Logic
{
    public interface IEnergyVisual
    {
        Image Icon { get; }
        TextMeshProUGUI Text { get; }
    }
}