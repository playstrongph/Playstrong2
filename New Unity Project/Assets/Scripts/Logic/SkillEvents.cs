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
        
        
        //TEST
        /// <summary>
        /// Skill Initialization event
        /// </summary>
        public event SkillEvent EInitializeSkill;
        
        private ISkillLogic skillLogic;

        private void Awake()
        {
            skillLogic = GetComponent<ISkillLogic>();
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
        
        //TEST
        /// <summary>
        /// Used by non-event based effects on skills
        /// Example - Immune to stun and sleep
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventInitializeSkill(IHero casterHero,IHero targetHero)
        {
            EInitializeSkill?.Invoke(casterHero,targetHero);
            
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
            UnsubscribeEventInitializeSkill();
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
        
        /// <summary>
        /// Unsubscribe all skill initialization events
        /// </summary>
        private void UnsubscribeEventInitializeSkill()
        {
            var clients = EInitializeSkill?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EInitializeSkill -= client as SkillEvent;
                
        }
    }
}
