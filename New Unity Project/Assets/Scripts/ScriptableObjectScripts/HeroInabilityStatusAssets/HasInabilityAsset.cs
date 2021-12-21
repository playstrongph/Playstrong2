using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    [CreateAssetMenu(fileName = "HasInability", menuName = "Assets/HeroInabilityStatus/HasInability")]
    public class HasInabilityAsset : HeroInabilityStatusAsset
    {
        public override IEnumerator StartAction(ITurnController turnController)
        {
            //With Inability - turnController.StartHeroNextTurn
            //No Inability - turnController.StartHeroTurn
            
            yield return null;
        }
    }
}
