using ScriptableObjectScripts.SkillLastUsedStatusAssets;
using ScriptableObjectScripts.SkillReadinessStatusAssets;

namespace Logic
{
    public interface IUpdateSkillLastUsedStatus
    {
        /// <summary>
        /// Set status to skill used last turn
        /// </summary>
        void SetUsedSkillLastTurn();
        
        /// <summary>
        /// Set status to skill not used last turn
        /// </summary>
        void SetNotUsedSkillLastTurn();

    }
}