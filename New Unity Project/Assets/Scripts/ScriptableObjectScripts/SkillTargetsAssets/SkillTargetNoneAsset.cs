using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{   
    /// <summary>
    /// Used by passive skills, returns an empty heroes list
    /// </summary>
    [CreateAssetMenu(fileName = "SkillTargetNone", menuName = "Assets/SkillTargets/SkillTargetNone")]
    public class SkillTargetNoneAsset : SkillTargetsAsset
    {
        public override List<IHero> HeroTargets(IHero hero)
        {
            return new List<IHero>();
        }
    }
}
