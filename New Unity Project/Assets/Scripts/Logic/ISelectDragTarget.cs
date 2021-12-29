namespace Logic
{
    public interface ISelectDragTarget
    {
        /// <summary>
        /// Displays the line and cross hair when the mouse is dragged a certain distance
        /// from the skill
        /// </summary>
        void ShowLineAndTarget();
        
        /// <summary>
        /// Enables actions when skill readiness is in 'ready' status
        /// </summary>
        void EnableSelectDragTargetActions();
        
        /// <summary>
        /// Enables actions when skill readiness is in 'ready' status
        /// </summary>
        void DisableSelectDragTargetActions();
    }
}