using System;
using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{
    public class LoadSkillVisual : MonoBehaviour, ILoadSkillVisual
    {
        private ISkillVisual _skillVisual;

        private void Awake()
        {
            _skillVisual = GetComponent<ISkillVisual>();
        }
        
        /// <summary>
        /// Sets the skill's icon and cooldown text
        /// </summary>
        /// <param name="skillAsset"></param>
        public void StartAction(ISkillAsset skillAsset)
        {
            _skillVisual.SkillGraphic.sprite = skillAsset.SkillIcon;
            _skillVisual.CooldownText.text = _skillVisual.Skill.SkillLogic.SkillAttributes.Cooldown.ToString();

        }
    }
}
