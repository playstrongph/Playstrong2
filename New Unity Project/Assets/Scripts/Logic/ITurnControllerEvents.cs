namespace Logic
{
    public interface ITurnControllerEvents
    {
        event TurnControllerEvents.TurnControllerEvent EStartCombatTurn;
        event TurnControllerEvents.TurnControllerEvent EEndCombatTurn;

        /// <summary>
        /// Start of combat event
        /// </summary>
        void EventStartCombatTurn(IHero hero);

        /// <summary>
        /// End of combat event
        /// </summary>
        void EventEndCombatTurn(IHero hero);
    }
}