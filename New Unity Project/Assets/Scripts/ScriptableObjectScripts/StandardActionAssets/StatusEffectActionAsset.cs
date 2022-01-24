using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StandardActionAssets
{
    [CreateAssetMenu(fileName = "StatusEffectAction", menuName = "Assets/StandardActions/StatusEffectAction")]
    public class StatusEffectActionAsset : StandardActionAsset, IStatusEffectActionAsset
    {
        /// <summary>
        /// The status effect's caster 
        /// </summary>
        public IHero StatusEffectCasterHero { get; set; }
        
        /// <summary>
        /// Executes the base class method StartActionCoroutine
        /// </summary>
        /// <param name="hero"></param>
        public void StatusEffectStartAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(StartActionCoroutine(hero));

        }
    }
}
