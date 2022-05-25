using System;
using UnityEngine;

namespace Logic
{
    public class TurnControllerEvents : MonoBehaviour, ITurnControllerEvents
    {
       
        /// <summary>
        /// Turn controller event signature 
        /// </summary>
        public delegate void TurnControllerEvent(IHero hero);

        #region EVENT DELEGATES

        public event TurnControllerEvent EStartCombatTurn;
        public event TurnControllerEvent EEndCombatTurn;

        #endregion


        #region EVENT CALLS
        
        /// <summary>
        /// Start of combat event
        /// </summary>
        public void EventStartCombatTurn(IHero hero)
        {
            EStartCombatTurn?.Invoke(hero);
        }
        
        /// <summary>
        /// End of combat event
        /// </summary>
        public void EventEndCombatTurn(IHero hero)
        {
            EEndCombatTurn?.Invoke(hero);
        }
        

        #endregion

        #region UNSUBSCRIPTION

        private void UnsubscribeEventStartCombatTurn()
        {
            var clients = EStartCombatTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EStartCombatTurn -= client as TurnControllerEvent;
        }
        
        private void UnsubscribeEventEndCombatTurn()
        {
            var clients = EEndCombatTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EEndCombatTurn -= client as TurnControllerEvent;
        }

        private void OnDestroy()
        {
            UnsubscribeEventStartCombatTurn();
            UnsubscribeEventEndCombatTurn();
        }

        #endregion

       
    }
}
