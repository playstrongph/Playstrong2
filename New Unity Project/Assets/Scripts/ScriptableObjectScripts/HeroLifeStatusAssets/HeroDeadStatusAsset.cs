using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroLifeStatusAssets
{
    [CreateAssetMenu(fileName = "HeroDead", menuName = "Assets/HeroAliveStatus/HeroDead")]
    public class HeroDeadStatusAsset : HeroLifeStatusAsset
    {
        /// <summary>
        /// Target hero life check
        /// </summary>
        /// <param name="standardAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void TargetStandardAction(IStandardActionAsset standardAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// Caster hero life check
        /// </summary>
        /// <param name="standardAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterStandardAction(IStandardActionAsset standardAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// Add a living hero to a list.  E.g. used in basic actions main action heroes
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="hero"></param>
        public override void AddToHeroTargetsList(List<IHero> heroes, IHero hero)
        {
           
        }

    }
}
