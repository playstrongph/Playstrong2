using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StandardActionAssets
{
    [CreateAssetMenu(fileName = "StatusEffectAction", menuName = "Assets/StandardActions/StatusEffectAction")]
    public class StatusEffectActionAsset : StandardActionAsset, IStatusEffectActionAsset
    {

        /// <summary>
        /// Executes the base class method StartActionCoroutine
        /// Note that hero here is the status effect's target hero
        /// </summary>
        /// <param name="hero"></param>
        public void StatusEffectStartAction(IHero hero) 
        {
            base.StartAction(hero);
        }
        
        /// <summary>
        /// Undoes the status effect start action
        /// </summary>
        /// <param name="hero"></param>
        public void UndoStatusEffectStartAction(IHero hero)
        {
            base.UndoStartAction(hero);
        }
        
        
        
       
        
        
    }
}
