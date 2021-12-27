using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    [CreateAssetMenu(fileName = "SkillTargetOtherAllies", menuName = "Assets/SkillTargets/SkillTargetOtherAllies")]
    public class SkillTargetOtherAllies : SkillTargetsAsset
    {
        public override List<IHero> HeroTargets(IHero hero)
        {
            var otherAllies = new List<IHero>(hero.Player.AliveHeroes.Heroes);
            
            //remove the skill caster's hero from the allies list
            otherAllies.Remove(hero);
            
            return otherAllies;
        }
    }
}
