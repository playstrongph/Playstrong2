using Logic;

namespace ScriptableObjectScripts.HeroActiveStatusAssets
{
    public interface IHeroActiveStatusAsset
    {
        void StatusAction(IHero hero);
        
        /// <summary>
        /// Removes the hero from the active heroes list
        /// </summary>
        /// <param name="hero"></param>
        void RemoveFromActiveHeroesList(IHero hero);
    }
}