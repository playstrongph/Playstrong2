using TMPro;
using UnityEngine.UI;

namespace Logic
{
    public interface IFightingSpiritVisual
    {
        Image Icon { get; }
        TextMeshProUGUI Text { get; }
    }
}