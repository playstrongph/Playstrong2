using AssetsScriptableObjects;
using UnityEngine;

public class UpdateHeroPreview : MonoBehaviour, IUpdateHeroPreview
{
    private IHeroPreview _heroPreview;

    private void Awake()
    {
        _heroPreview = GetComponent<IHeroPreview>();
    }
        
    /// <summary>
    /// Updates the values of the hero preview's basic attributes
    /// </summary>
    public void StartAction()
    {
        var heroAttributes = _heroPreview.Hero.HeroLogic.HeroAttributes;
            
        var baseAttackText = heroAttributes.BaseAttack.ToString();
        var baseHealthText = heroAttributes.BaseHealth.ToString();
        var baseSpeedText = heroAttributes.BaseSpeed.ToString();
        var baseChanceText = heroAttributes.BaseChance.ToString();

        //BASIC ATTRIBUTES
        _heroPreview.HeroPreviewAttack.PreviewText.text = baseAttackText;
        _heroPreview.HeroPreviewHealth.PreviewText.text = baseHealthText;
        _heroPreview.HeroPreviewSpeed.PreviewText.text = baseSpeedText;
        _heroPreview.HeroPreviewChance.PreviewText.text = baseChanceText;
    }
}