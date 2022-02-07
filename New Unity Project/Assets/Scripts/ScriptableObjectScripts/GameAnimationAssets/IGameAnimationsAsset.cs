using Logic;
using TMPro;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    public interface IGameAnimationsAsset
    {   
        /// <summary>
        /// Play animation hero argument
        /// </summary>
        /// <param name="hero"></param>
        void PlayAnimation(IHero hero);
        
        /// <summary>
        /// Play animation - caster to hero target argument
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void PlayAnimation(IHero casterHero,IHero targetHero);

        void PlayAnimation(TextMeshProUGUI text);
        
        /// <summary>
        /// Animation duration.  Not necessarily equal to the total animation duration,
        /// can be less for timing for purposes
        /// </summary>
        float AnimationDuration { get; }

    }
}