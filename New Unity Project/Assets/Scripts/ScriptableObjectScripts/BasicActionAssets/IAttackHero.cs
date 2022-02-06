using System.Collections;
using Logic;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public interface IAttackHero
    {
        /// <summary>
        /// Used by Inability Asset
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void AttackHero(IHero casterHero,IHero targetHero);
    }
}