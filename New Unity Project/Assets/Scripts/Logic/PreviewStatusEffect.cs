using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreviewStatusEffect : MonoBehaviour, IPreviewStatusEffect
{
    /// <summary>
    /// StatusEffect preview graphic
    /// </summary>
    [SerializeField] private Image graphic;

    public Image Icon
    {
        get => graphic;
        set => graphic = value;
    }
        
    /// <summary>
    /// StatusEffect name text  
    /// </summary>
    [SerializeField] private TextMeshProUGUI nameText;

    public TextMeshProUGUI NameText
    {
        get => nameText;
        set => nameText = value;
    }
        
    /// <summary>
    /// StatusEffect description text  
    /// </summary>
    [SerializeField] private TextMeshProUGUI descriptionText;

    public TextMeshProUGUI DescriptionText
    {
        get => descriptionText;
        set => descriptionText = value;
    }
}