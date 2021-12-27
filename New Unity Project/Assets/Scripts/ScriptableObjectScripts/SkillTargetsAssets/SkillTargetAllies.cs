using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    [CreateAssetMenu(fileName = "SkillTargetAllies", menuName = "Assets/SkillTargets/SkillTargetAllies")]
    public class SkillTargetAllies : SkillTargetsAsset
    {
        public override List<IHero> HeroTargets(IHero hero)
        {
            return new List<IHero>(hero.Player.AliveHeroes.Heroes);
        }
    }
}
