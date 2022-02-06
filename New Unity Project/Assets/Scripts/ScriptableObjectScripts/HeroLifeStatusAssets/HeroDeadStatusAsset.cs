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
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void TargetMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary> 
        /// HeroDead - Do nothing
        /// After confirming, caster is alive, execute action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
               
        }
        
        /// <summary>
        /// HeroDead - Do nothing
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void TargetPreExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// HeroDead - Do nothing
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterPreExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// HeroDead - Do nothing
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void TargetPostExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }
        
        /// <summary>
        /// HeroDead - Do nothing
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterPostExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            
        }

      
    }
}
