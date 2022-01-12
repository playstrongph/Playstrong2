using Logic;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    public interface IGameAnimationsAsset
    {
        void PlayAnimation(IHero hero, int value);
    }
}