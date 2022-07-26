﻿using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    public interface IActionHeroesAsset
    {   
        /// <summary>
        /// Returns list of action or basic condition targets
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardActionAsset"></param>
        /// <returns></returns>
        List<IHero> GetActionHeroes(IHero casterHero, IHero targetHero,IStandardActionAsset standardActionAsset);
        
        /// <summary>
        /// Returns a list of heroes subscribing to the basic event
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        List<IHero> GetEventSubscribers(IHero hero);

        
        /// <summary>
        /// Used by Set Hero Targets Basic Actions to ensure a consistent random heroes for the basic actions
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        List<IHero> SetActionHeroes(IHero casterHero, IHero targetHero);


    }
}