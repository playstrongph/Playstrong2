using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroLifeStatusAssets
{
    [CreateAssetMenu(fileName = "HeroDead", menuName = "Assets/HeroAliveStatus/HeroDead")]
    public class HeroDeadStatusAsset : HeroLifeStatusAsset
    {
        /// <summary>
        /// Target HeroDead - Do nothing
        /// After confirming target is alive, check if caster is alive
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void TargetAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary> 
        /// HeroDead - Do nothing
        /// After confirming, caster is alive, execute action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void CasterAction(IBasicActionAsset basicAction, IHero hero)
        {
               
        }

      
    }
}
