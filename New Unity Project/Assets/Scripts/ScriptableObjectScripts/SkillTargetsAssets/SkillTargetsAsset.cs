using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    public abstract class SkillTargetsAsset : ScriptableObject, ISkillTargetsAsset
    {
        /// <summary>
        /// Returns a list of ally heroes, enemy heroes, other ally heroes
        /// empty list (for passive skills)
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public virtual List<IHero> HeroTargets(IHero hero)
        {
            //Ally heroes
            //All Other ally heroes
            //enemy heroes
            //None (empty list)

            return new List<IHero>();
        }
        
        /// <summary>
        /// Displays hero glow for allies - yellow, enemies - red
        /// </summary>
        public virtual void ShowHeroGlow(IHero hero)
        {
            //Ally Glow
            //Enemy Glow
            //No Glow
        }
        
        /// <summary>
        /// Hides the hero glow for allies - yellow, enemies - red
        /// </summary>
        public virtual void HideHeroGlow(IHero hero)
        {
            //Ally Glow
            //Enemy Glow
            //No Glow
        }




    }
}
