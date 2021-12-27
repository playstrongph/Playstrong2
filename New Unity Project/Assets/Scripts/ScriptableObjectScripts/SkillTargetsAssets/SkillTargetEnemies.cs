using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    [CreateAssetMenu(fileName = "SkillTargetEnemies", menuName = "Assets/SkillTargets/SkillTargetEnemies")]
    public class SkillTargetEnemies : SkillTargetsAsset
    {
        public override List<IHero> HeroTargets(IHero hero)
        {
            return new List<IHero>(hero.Player.OtherPlayer.AliveHeroes.Heroes);
        }
    }
}
