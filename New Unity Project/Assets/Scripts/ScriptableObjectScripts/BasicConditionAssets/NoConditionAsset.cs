using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "NoCondition", menuName = "Assets/BasicConditions/NoCondition")]
    public class NoConditionAsset : BasicConditionAsset
    {   
        protected override int CheckConditionValue(IHero hero)
        {
            return 1;
        }
    }
}
