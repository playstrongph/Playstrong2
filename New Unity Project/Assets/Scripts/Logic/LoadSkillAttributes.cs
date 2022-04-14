﻿using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{
    public class LoadSkillAttributes : MonoBehaviour, ILoadSkillAttributes
    {
        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }

        public void StartAction(ISkillAsset skillAsset)
        {
            var skillAttributes = _skillLogic.SkillAttributes;

            skillAttributes.BaseCooldown = skillAsset.BaseCooldown;
            skillAttributes.Cooldown = skillAsset.BaseCooldown;
            
            //TEST
            skillAttributes.FightingSpiritCost = skillAsset.FightingSpiritCost;
            
            //SET DEFAULT SKILL PROPERTIES AND STATUSES
            _skillLogic.UpdateSkillLastUsedStatus.SetNotUsedSkillLastTurn();
            
            //SET SKILL ASSET REFERENCED SKILL PROPERTIES AND STATUSES
            skillAttributes.SkillType = skillAsset.SkillTypeAsset;
            skillAttributes.SkillTargets = skillAsset.SkillTargetsAsset;
            skillAttributes.SkillCooldownType = skillAsset.SkillCooldownTypeAsset;
            skillAttributes.SkillReadiness = skillAsset.SkillTypeAsset.StartingSkillReadiness;
            skillAttributes.SkillEnableStatus = skillAsset.SkillTypeAsset.StartingSkillEnableStatus;

        }


    }
}