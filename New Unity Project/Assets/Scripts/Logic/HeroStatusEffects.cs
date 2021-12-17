using UnityEngine;
using UnityEngine.UI;

public class HeroStatusEffects : MonoBehaviour, IHeroStatusEffects
{
    /// <summary>
    /// Reference to Hero where other
    /// components can be accessed
    /// </summary>
    [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
    private Object hero;
    public IHero Hero
    {
        get => hero as IHero;
        set => hero = value as Object;
    }

    /// <summary>
    /// Reference to status effects canvas
    /// </summary>
    [SerializeField] private Canvas statusEffectsCanvas;
    public Canvas StatusEffectsCanvas
    {
        get => statusEffectsCanvas;
        set => statusEffectsCanvas = value;
    }

}