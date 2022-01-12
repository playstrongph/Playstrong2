using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    public abstract class GameAnimationsAsset : ScriptableObject, IGameAnimationsAsset
    {
        public virtual void PlayAnimation(IHero hero, int value)
        {
            
        }
    }
}
