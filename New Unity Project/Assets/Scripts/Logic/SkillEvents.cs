using UnityEngine;

namespace Logic
{
    public class SkillEvents : MonoBehaviour, ISkillEvents
    {
        /// <summary>
        /// Skill event signature - single hero
        /// </summary>
        public delegate void SkillEvent(IHero casterHero);
        
        /// <summary>
        /// Drag skill event delegate
        /// </summary>
        public event SkillEvent EDragSkillTarget;
        
        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }
        
        /// <summary>
        /// Call all drag skill event subscribers
        /// </summary>
        /// <param name="casterHero"></param>
        public void EventDragSkillTarget(IHero casterHero)
        {
            EDragSkillTarget?.Invoke(casterHero);
        }
        
        private void OnDestroy()
        {
            UnsubscribeAllClients();           
        }
        
        /// <summary>
        /// Unsubscribe all clients of all events 
        /// </summary>
        private void UnsubscribeAllClients()
        {
            UnsubscribeEventDragSkillTarget();
        }
        
        
        /// <summary>
        /// Unsubscribe all drag skill target event clients
        /// </summary>
        private void UnsubscribeEventDragSkillTarget()
        {
            var clients = EDragSkillTarget?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EDragSkillTarget -= client as SkillEvent;
                }
        }
    }
}
