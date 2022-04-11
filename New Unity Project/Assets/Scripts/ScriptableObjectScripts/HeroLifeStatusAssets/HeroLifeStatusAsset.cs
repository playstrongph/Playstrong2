using System.Collections;
using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroLifeStatusAssets
{
    public abstract class HeroLifeStatusAsset : ScriptableObject, IHeroLifeStatusAsset
    {
        /// <summary>
        /// Target hero life check
        /// </summary>
        /// <param name="standardAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void TargetStandardAction(IStandardActionAsset standardAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// Caster hero life check
        /// </summary>
        /// <param name="standardAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void CasterStandardAction(IStandardActionAsset standardAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// Add a living hero to a list.  E.g. used in basic actions main action heroes
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="hero"></param>
        public virtual void AddToHeroList(List<IHero> heroes, IHero hero)
        {
           
        }

        #region OLD LOGIC

        /*/// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's main execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void TargetMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// main execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void CasterMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
         /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void TargetPreExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void CasterPreExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void TargetPostExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void CasterPostExecutionAction(IBasicActionAsset basicAction,  IHero casterHero,IHero targetHero)
        {
            
        }
        
       /// <summary>
       ///  After confirming target is alive, check if caster is alive
       /// before implementing the basic action's main animation action
       /// </summary>
       /// <param name="basicAction"></param>
       /// <param name="casterHero"></param>
       /// <param name="targetHero"></param>
        public virtual void TargetMainAnimation(IBasicActionAsset basicAction,  IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        ///  After confirming the caster is alive, implement the basic action's
        ///  main animation action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void CasterMainAnimation(IBasicActionAsset basicAction,  IHero casterHero,IHero targetHero)
        {
            
        }*/

        #endregion
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        

       
        
       


    }
}
