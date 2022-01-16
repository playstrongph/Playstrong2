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
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        IEnumerator StartAction(IHero hero, IStandardActionAsset standardAction);

        /// <summary>
        /// Executes the basic action logic
        /// Exclusively used by hero life status
        /// </summary>
        /// <param name="hero"></param>
        IEnumerator ExecuteAction(IHero hero);
        
        /// <summary>
        ///  Undoes the effect of execute action, mostly
        /// used in status effects
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        IEnumerator UndoExecuteAction(IHero hero);
        
        /// <summary>
        /// All the events before execute action
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        IEnumerator PreExecuteActionEvents(IHero hero);
        
        /// <summary>
        /// All the events after execute action
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        IEnumerator PostExecuteActionEvents(IHero hero);


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