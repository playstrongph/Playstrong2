namespace Logic
{
    public interface ISkillEvents
    {
        /// <summary>
        /// Drag skill event delegate
        /// </summary>
        event SkillEvents.SkillEvent EDragSkillTarget;

        /// <summary>
        /// Call all drag skill event subscribers
        /// </summary>
        /// <param name="casterHero"></param>
        /// /// <param name="targetHero"></param>
        void EventDragSkillTarget(IHero casterHero,IHero targetHero);
    }
}