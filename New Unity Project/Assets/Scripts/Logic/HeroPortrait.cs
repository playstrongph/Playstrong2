using System;
using UnityEngine;
using UnityEngine.UI;

public class HeroPortrait : MonoBehaviour, IHeroPortrait
{
    /// <summary>
    /// Reference to portrait canvas.
    /// Set in the inspector.
    /// </summary>
    [SerializeField] private Canvas portraitCanvas;
    public Canvas PortraitCanvas
    {
        get => portraitCanvas;
        set => portraitCanvas = value;
    }
        
    /// <summary>
    /// Reference to portrait frame image.
    /// Set in the inspector.
    /// </summary>
    [SerializeField] private Image frameImage;
    public Image FrameImage
    {
        get => frameImage;
        set => frameImage = value;
    }
        
    /// <summary>
    /// Reference to portrait image.
    /// Set in the inspector.
    /// </summary>
    [SerializeField] private Image portraitImage;
    public Image PortraitImage
    {
        get => portraitImage;
        set => portraitImage = value;
    }
        
    /// <summary>
    /// Returns this as a game object
    /// </summary>
    public GameObject ThisGameObject => this.gameObject;

    /// <summary>
    /// Shows or Hides the hero's portrait
    /// </summary>
    private ITogglePortraitDisplay _togglePortraitDisplay;
    public ITogglePortraitDisplay TogglePortraitDisplay => _togglePortraitDisplay;

    private void Awake()
    {
        _togglePortraitDisplay = GetComponent<ITogglePortraitDisplay>();
    }
}