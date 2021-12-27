using AssetsScriptableObjects;
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

            skillAttributes.SkillTargets = skillAsset.SkillTargetsAsset;


        }
    }
}