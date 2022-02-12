using System.Collections;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public interface IBasicActionAsset
    {
        
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
        IEnumerator PreExecuteActionEvents(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// All the events after execute action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        IEnumerator PostExecuteActionEvents(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Main animation
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        IEnumerator MainAnimation(IHero casterHero, IHero targetHero);
        
        
        //TEST
        float MainAnimationDuration { get;}
      


        #region OLD LOGIC

        /*/// <summary>
        /// Checks if the targeted and targeting hero are both alive before
        /// executing the basic action.  Can be overriden to bypass these checks
        /// as required - e.g. resurrect, base stats change
        /// </summary>
        /// <param name="hero"></param>
        IEnumerator StartAction(IHero hero);*/

        #endregion
    }
}