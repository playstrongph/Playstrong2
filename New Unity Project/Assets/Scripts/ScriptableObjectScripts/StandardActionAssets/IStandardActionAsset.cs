using System.Collections;
using Logic;

namespace ScriptableObjectScripts.StandardActionAssets
{
    public interface IStandardActionAsset
    {
        /// <summary>
        /// Base method for actions execution
        /// </summary>
        /// <param name="hero"></param>
        void StartAction(IHero hero);
    }
}