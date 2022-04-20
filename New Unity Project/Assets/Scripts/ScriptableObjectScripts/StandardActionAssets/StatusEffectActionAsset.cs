﻿using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StandardActionAssets
{
    [CreateAssetMenu(fileName = "StatusEffectAction", menuName = "Assets/StandardActions/StatusEffectAction")]
    public class StatusEffectActionAsset : StandardActionAsset, IStatusEffectActionAsset
    {

        
        /// <summary>
        /// Requires a unique instance of the status effect action asset to set the reference
        /// Reference is set in LoadStatusEffectAsset.cs
        /// </summary>
        public IHero StatusEffectCasterHero { get; set; }
        
        /// <summary>
        /// Requires a unique instance of the status effect action asset to set the reference
        /// Reference is set in LoadStatusEffectAsset.cs
        /// </summary>
        public IHero StatusEffectTargetHero { get; set; }

        /// <summary>
        /// Executes the base class method StartActionCoroutine
        /// Note that hero here is the status effect's target hero
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void StatusEffectStartAction(IHero casterHero,IHero targetHero)
        {
            //base.StartAction(casterHero,targetHero);
            
            //TEST
            //base.StartAction(StatusEffectCasterHero,targetHero);
            
            StartAction(StatusEffectCasterHero,targetHero);
        }
        
        /// <summary>
        /// Skips checking life/inability status of heroes
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void StartAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(ExecuteStartAction(casterHero,targetHero));
        }

        /// <summary>
        /// Undoes the status effect start action
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        public void UndoStatusEffectStartAction(IHero casterHero,IHero targetHero) 
        {
            //base.UndoStartAction(casterHero,targetHero);
            
            //TEST
            base.UndoStartAction(StatusEffectCasterHero,targetHero);
        }
        
        
        
        /// <summary>
        /// No checking of life/inability status for status effects
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="heroes"></param>
        public override void SetTargetHeroes(IHero hero, List<IHero> heroes)
        {
            heroes.Add(hero);
        }  
        
        /// <summary>
        /// No checking of life/inability status for status effects
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="heroes"></param>
        public override void SetCasterHeroes(IHero hero, List<IHero> heroes)
        {
            heroes.Add(hero);
        }
        
        
       
        
        
    }
}
