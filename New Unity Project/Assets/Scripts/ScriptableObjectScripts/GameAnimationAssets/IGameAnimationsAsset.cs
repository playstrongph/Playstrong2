using Logic;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    public interface IGameAnimationsAsset
    {   
        void PlayAnimation(IHero hero);
        
        /// <summary>
        /// Animation duration.  Not necessarily equal to the total animation duration,
        /// can be less for timing for purposes
        /// </summary>
        float AnimationDuration { get; set; }

    }
}