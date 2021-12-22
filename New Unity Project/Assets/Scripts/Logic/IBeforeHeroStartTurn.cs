using System.Collections;

namespace Logic
{
    public interface IBeforeHeroStartTurn
    {
        /// <summary>
        /// Calls before start turn event, updates status effects, starts hero action depending
        /// on hero inability status 
        /// </summary>
        /// <returns></returns>
        IEnumerator StartAction();

        /// <summary>
        /// Starts the hero turn when hero has no inability
        /// called by "NoInability" asset in the hero's inability status attribute
        /// </summary>
        void HeroStartTurn();
    }
}