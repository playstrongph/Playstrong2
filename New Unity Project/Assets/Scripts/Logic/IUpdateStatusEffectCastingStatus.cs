using ScriptableObjectScripts.StatusEffectCastingStatusAssets;

namespace Logic
{
    public interface IUpdateStatusEffectCastingStatus
    {   
        /// <summary>
        /// Set to fresh cast status
        /// </summary>
        void SetFreshCastStatus();
        
        /// <summary>
        /// Set to old cast status
        /// </summary>
        void SetOldCastStatus();
    }
}