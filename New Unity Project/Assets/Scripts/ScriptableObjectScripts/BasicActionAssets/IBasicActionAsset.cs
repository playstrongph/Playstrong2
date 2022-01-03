using System.Collections;
using Logic;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public interface IBasicActionAsset
    {
        /// <summary>
        /// Checks if the targeted and targeting hero are both alive before
        /// executing the basic action.  Can be overriden to bypass these checks
        /// as required - e.g. resurrect, base stats change
        /// </summary>
        /// <param name="hero"></param>
        IEnumerator StartAction(IHero hero);

        /// <summary>
        /// Executes the basic action logic
        /// Exclusively used by hero life status
        /// </summary>
        /// <param name="hero"></param>
        IEnumerator ExecuteAction(IHero hero);
    }
}