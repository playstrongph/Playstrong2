using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    public abstract class HeroInabilityStatusAsset : ScriptableObject, IHeroInabilityStatusAsset
    {
        public virtual IEnumerator StartAction(ITurnController turnController)
        {
            //With Inability - turnController.StartHeroNextTurn
            //No Inability - turnController.StartHeroTurn
            
            yield return null;
        }
    }
}
