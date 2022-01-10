using Logic;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public interface IAttackHero
    {
        /// <summary>
        /// Used by Inability Asset
        /// </summary>
        /// <param name="hero"></param>
        void AttackHero(IHero hero);
    }
}