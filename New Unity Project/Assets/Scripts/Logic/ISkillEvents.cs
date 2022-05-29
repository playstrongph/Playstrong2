namespace Logic
{
    public interface ISkillEvents
    {
        /// <summary>
        /// Drag skill event delegate
        /// </summary>
        event SkillEvents.SkillEvent EDragSkillTarget;
        
        event SkillEvents.SkillEvent EInitializeSkill;

        /// <summary>
        /// Call all drag skill event subscribers
        /// </summary>
        /// <param name="casterHero"></param>
        /// /// <param name="targetHero"></param>
        void EventDragSkillTarget(IHero casterHero,IHero targetHero);
        
        /// <summary>
        /// casterHero and targetHero are the same
        /// (to avoid creating another skill event delegate type)
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventInitializeSkill(IHero casterHero, IHero targetHero);
    }
}