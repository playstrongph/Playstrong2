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
            UpdateThisPlayerDisplay();
            UpdateOtherPlayerDisplay();
            
            _targetCollider.Hero.DisplayHeroPortrait.ThisGameObject.SetActive(true);
            _targetCollider.Hero.DisplayHeroPortrait.TogglePortraitDisplay.ShowPortrait();
            _targetCollider.Hero.DisplayHeroSkills.ThisGameObject.SetActive(true);
        }

        private void UpdateThisPlayerDisplay()
        {
            var displayPortraitAndSkills = _targetCollider.Hero.Player.AliveHeroes.DisplayedPortraitAndSkills;

            displayPortraitAndSkills.DisplayedHeroPortrait?.ThisGameObject.SetActive(false);
            displayPortraitAndSkills.DisplayedHeroSkills?.ThisGameObject.SetActive(false);

            displayPortraitAndSkills.DisplayedHeroPortrait = _targetCollider.Hero.DisplayHeroPortrait;
            displayPortraitAndSkills.DisplayedHeroSkills = _targetCollider.Hero.DisplayHeroSkills;
        }
        
        private void UpdateOtherPlayerDisplay()
        {
            var displayPortraitAndSkills = _targetCollider.Hero.Player.OtherPlayer.AliveHeroes.DisplayedPortraitAndSkills;

            displayPortraitAndSkills.DisplayedHeroPortrait?.ThisGameObject.SetActive(false);
            displayPortraitAndSkills.DisplayedHeroSkills?.ThisGameObject.SetActive(false);

            displayPortraitAndSkills.DisplayedHeroPortrait = _targetCollider.Hero.DisplayHeroPortrait;
            displayPortraitAndSkills.DisplayedHeroSkills = _targetCollider.Hero.DisplayHeroSkills;

        }
    }
}