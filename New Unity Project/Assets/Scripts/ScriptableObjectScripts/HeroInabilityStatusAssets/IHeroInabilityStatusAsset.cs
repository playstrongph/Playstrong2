using System.Collections;
using Logic;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    public interface IHeroInabilityStatusAsset
    {
        IEnumerator StartAction(ITurnController turnController);
    }
}