namespace Logic
{
    public interface ITurnControllerEvents
    {
        event TurnControllerEvents.TurnControllerEvent EStartCombatTurn;
        event TurnControllerEvents.TurnControllerEvent EEndCombatTurn;

        /// <summary>
        /// Start of combat event
        /// </summary>
        void EventStartCombatTurn();

        /// <summary>
        /// End of combat event
        /// </summary>
        void EventEndCombatTurn();
    }
}