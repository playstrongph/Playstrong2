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
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void StatusEffectStartAction(IHero casterHero,IHero targetHero) 
        {
            base.StartAction(casterHero,targetHero);
        }
        
        /// <summary>
        /// Undoes the status effect start action
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        public void UndoStatusEffectStartAction(IHero casterHero,IHero targetHero) 
        {
            base.UndoStartAction(casterHero,targetHero);
        }
        
        
        
       
        
        
    }
}
