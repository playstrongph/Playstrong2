using System;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Displays the hero portrait and skills of the hero selected by the player
    /// Used in game to get information on the hero skill abilities and cooldown
    /// </summary>
    public class DisplayHeroPortraitAndSkills : MonoBehaviour
    {
        private ITargetCollider _targetCollider;

        private void Awake()
        {
            _targetCollider = GetComponent<ITargetCollider>();
        }

        private void OnMouseDown()
        {
            var displayedPortraitAndSkills = _targetCollider.Hero.Player.AliveHeroes.DisplayedPortraitAndSkills;
            
            if (displayedPortraitAndSkills.DisplayedHeroPortrait !=null)
                displayedPortraitAndSkills.DisplayedHeroPortrait.ThisGameObject.SetActive(false);
            if (displayedPortraitAndSkills.DisplayedHeroSkills != null)
                displayedPortraitAndSkills.DisplayedHeroSkills.ThisGameObject.SetActive(false);
            
            _targetCollider.Hero.DisplayHeroPortrait.ThisGameObject.SetActive(true);
            _targetCollider.Hero.DisplayHeroPortrait.TogglePortraitDisplay.ShowPortrait();
            _targetCollider.Hero.DisplayHeroSkills.ThisGameObject.SetActive(true);

            displayedPortraitAndSkills.DisplayedHeroPortrait = _targetCollider.Hero.DisplayHeroPortrait;
            displayedPortraitAndSkills.DisplayedHeroSkills = _targetCollider.Hero.DisplayHeroSkills;
        }
    }
}
