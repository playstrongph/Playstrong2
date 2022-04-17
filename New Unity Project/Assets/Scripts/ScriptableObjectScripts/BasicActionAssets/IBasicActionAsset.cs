﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using ScriptableObjectScripts.StatusEffectAssets;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public interface IBasicActionAsset
    {
       
        /// <summary>
        /// Basic action reference to its respective status effect
        /// </summary>
        IStatusEffect StatusEffectReference { get; set; }

        /// <summary>
        /// Checks if all conditions are met (basic conditions plus caster and target life status)
        /// before proceeding to execute action 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        IEnumerator StartAction(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction);

        /// <summary>
        /// Executes the basic action logic
        /// Exclusively used by hero life status
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        IEnumerator ExecuteAction(IHero casterHero, IHero targetHero);
        
        /// <summary>
        ///  Undoes the effect of execute action, mostly
        /// used in status effects
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        IEnumerator UndoExecuteAction(IHero casterHero,IHero targetHero);
        
        /// <summary>
        /// All the events before execute action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        IEnumerator CallPreBasicActionEvents(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// All the events after execute action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        IEnumerator CallPostBasicActionEvents(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Main animation
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        IEnumerator MainAnimation(IHero casterHero, IHero targetHero);


        /// <summary>
        /// Main Execution Action Heroes list
        /// </summary>
        List<IHero> ExecuteActionTargetHeroes { get; }
        
        /// <summary>
        /// Main Execution Action Casters List
        /// </summary>
        List<IHero> ExecuteActionCasterHeroes { get;}




        #region OLD LOGIC


        #endregion
    }
}