using System.Collections.Generic;
using Logic;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    public interface ISkillTargetsAsset
    {
        /// <summary>
        /// Returns a list of ally heroes, enemy heroes, other ally heroes
        /// empty list (for passive skills)
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        List<IHero> HeroTargets(IHero hero);
        
        /// <summary>
        /// Displays hero glow for allies - yellow, enemies - red
        /// </summary>
        void ShowHeroGlow(IHero hero);
        
        /// <summary>
        /// Hides hero glow for allies - yellow, enemies - red
        /// </summary>
        /// <param name="hero"></param>
        void HideHeroGlow(IHero hero);
    }
}