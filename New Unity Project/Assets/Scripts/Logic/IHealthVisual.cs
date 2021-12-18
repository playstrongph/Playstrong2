using TMPro;
using UnityEngine.UI;

namespace Logic
{
    public interface IHealthVisual
    {
        Image Icon { get; }
        TextMeshProUGUI Text { get; }
    }
}