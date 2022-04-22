using System.Collections;
using ScriptableObjectScripts.SkillReadinessStatusAssets;

namespace Logic
{
    public interface IUpdateSkillReadiness
    {
        /// <summary>
        /// Set skill readiness to 'Ready' or 'Not Ready' depending on skill type
        /// </summary>
        void StartAction();
        
        /*/// <summary>
        /// Coroutine version for sequential logic
        /// Set skill readiness to 'Ready' or 'Not Ready' depending on skill type
        /// </summary>
        IEnumerator StartActionCoroutine();*/
        
        /// <summary>
        /// Sets skill readiness start action back to default 
        /// </summary>
        void EnableSkillReadiness();

        /// <summary>
        /// Sets the skill readiness start action to no action
        /// </summary>
        void DisableSkillReadiness();

        /// <summary>
        /// Set skill ready status and actions
        /// </summary>
        void SetSkillReady();
        
        /// <summary>
        /// Set skill not ready status and actions
        /// </summary>
        void SetSkillNotReady();
        
        /// <summary>
        /// Reference to skill ready status asset
        /// </summary>
        ISkillReadinessStatusAsset SkillReadyAsset { get; }
        
        /// <summary>
        /// Reference to skill not ready status asset
        /// </summary>
        ISkillReadinessStatusAsset SkillNotReadyAsset { get; }
    }
}