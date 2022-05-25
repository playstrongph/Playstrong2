using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{
    [CreateAssetMenu(fileName = "TurnControllerEndTurnEvent", menuName = "Assets/BasicEvents/TurnControllerEndTurnEvent")]

    public class TurnControllerEndTurnEventAsset : BasicEventAsset
    {
        /// <summary>
        /// Subscribes the standard action to the single IHero argument event
        /// Note that for single IHero argument events, this hero and target hero are the same
        /// </summary>
        /// <param name="thisHero"></param>
        /// /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public override void SubscribeStandardAction(IHero thisHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            var turnController = targetHero.Player.BattleSceneManager.TurnController;
            
            //This is a single IHero arg event 
            //targetHero.HeroLogic.HeroEvents.EAfterHeroEndTurn += standardAction.StartAction;

            //This is a single IHero arg event - but hero in this case is just a dummy, not really needed by turn controller end turn
            turnController.TurnControllerEvents.EEndCombatTurn += standardAction.StartAction;
        }
        
        
        /// <summary>
        /// Unsubscribes the standard action to the single IHero argument event
        /// Note that for single IHero argument events, this hero and target hero are the same
        /// </summary>
        /// <param name="thisHero"></param>
        /// /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public override void UnsubscribeStandardAction(IHero thisHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            var turnController = targetHero.Player.BattleSceneManager.TurnController;
            
            //This is a single IHero arg event
            //targetHero.HeroLogic.HeroEvents.EAfterHeroEndTurn -= standardAction.StartAction;
            
            //This is a single IHero arg event - but hero in this case is just a dummy, not really needed by turn controller end turn
            turnController.TurnControllerEvents.EEndCombatTurn -= standardAction.StartAction;
        }
        
       
    }
}
