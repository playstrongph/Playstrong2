﻿using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroLifeStatusAssets
{
    public abstract class HeroLifeStatusAsset : ScriptableObject, IHeroLifeStatusAsset
    {
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's main execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void TargetMainExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// main execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void CasterMainExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }

        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void TargetPreExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void CasterPreExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void TargetPostExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void CasterPostExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        


    }
}
