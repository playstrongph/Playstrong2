using UnityEngine;

namespace Logic
{
    public class SkillEvents : MonoBehaviour, ISkillEvents
    {
        /// <summary>
        /// Skill event signature
        /// </summary>
        public delegate void SkillEvent(IHero casterHero,IHero targetHero);
        
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
        ///  <param name="targetHero"></param>
        public void EventDragSkillTarget(IHero casterHero,IHero targetHero)
        {
            EDragSkillTarget?.Invoke(casterHero,targetHero);
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
                    EDragSkillTarget -= client as SkillEvent;
                
        }
    }
}
