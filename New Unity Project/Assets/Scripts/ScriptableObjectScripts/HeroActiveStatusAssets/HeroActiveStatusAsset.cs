using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroActiveStatusAssets
{
    /// <summary>
    /// Base class for ActiveHero and InactiveHero
    /// Generic Asset
    /// </summary>
    public abstract class HeroActiveStatusAsset : ScriptableObject, IHeroActiveStatusAsset
    {
        public virtual void StatusAction(IHero hero)
        {
            
        }
        
        
        /// <summary>
        /// Removes the hero from the active heroes list, regardless
        /// if hero is active or inactive 
        /// </summary>
        /// <param name="hero"></param>
        public void RemoveFromActiveHeroesList(IHero hero)
        {
            var turnController = hero.Player.BattleSceneManager.TurnController;
            turnController.SetActiveHeroes.RemoveHero(hero);
        }



    }
}
