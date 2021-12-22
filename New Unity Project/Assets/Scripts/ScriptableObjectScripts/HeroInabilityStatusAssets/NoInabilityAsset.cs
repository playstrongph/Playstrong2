using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    [CreateAssetMenu(fileName = "NoInability", menuName = "Assets/HeroInabilityStatus/NoInability")]
    public class NoInabilityAsset : HeroInabilityStatusAsset
    {
        public override IEnumerator StartAction(ITurnController turnController)
        {
            Debug.Log("No Inability: " +turnController.CurrentActiveHero.HeroName);

            yield return null;
        }
    }
}
