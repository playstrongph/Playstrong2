﻿using System.Collections;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    public interface IHeroInabilityStatusAsset
    {
        /// <summary>
        /// Turn controller action based on inability
        /// </summary>
        /// <param name="turnController"></param>
        /// <returns></returns>
        IEnumerator TurnControllerAction(ITurnController turnController);

        /// <summary>
        /// Attack basic action asset "AttackHero" action based on inability
        /// </summary>
        /// <param name="attackHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void AttackAction(IAttackHero attackHero, IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Executes basic action if caster hero has no inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void ExecuteBasicAction(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);
        
    }
}