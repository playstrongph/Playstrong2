using System.Collections;

namespace Logic
{
    public interface IUpdateSkillReadiness
    {
        /// <summary>
        /// Set skill readiness to 'Ready' or 'Not Ready' depending on skill type
        /// </summary>
        void StartAction();
        
        /// <summary>
        /// Coroutine version for sequential logic
        /// Set skill readiness to 'Ready' or 'Not Ready' depending on skill type
        /// </summary>
        IEnumerator StartActionCoroutine();


    }
}