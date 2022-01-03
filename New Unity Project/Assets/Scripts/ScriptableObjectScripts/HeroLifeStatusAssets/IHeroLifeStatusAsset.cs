﻿using Logic;
using ScriptableObjectScripts.BasicActionAssets;

namespace ScriptableObjectScripts.HeroLifeStatusAssets
{
    public interface IHeroLifeStatusAsset
    {
        /// <summary>
        /// Target HeroAlive - call hero Caster Action
        /// Target HeroDead - Do nothing
        /// After confirming target is alive, check if caster is alive
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        void TargetAction(IBasicActionAsset basicAction, IHero hero);

        /// <summary>
        /// HeroAlive - basic action Execute action
        /// HeroDead - Do nothing
        /// After confirming, caster is alive, execute action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        void CasterAction(IBasicActionAsset basicAction, IHero hero);
    }
}