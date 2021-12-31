using System;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillEnableStatus : MonoBehaviour
    {

        /// <summary>
        /// Skill enabled asset reference - to be used by skill type
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillEnableStatusAsset))]
        private ScriptableObject skillEnabledAsset;

        private ISkillEnableStatusAsset SkillEnabledAsset
        {
            get => skillEnabledAsset as ISkillEnableStatusAsset;
            set => skillEnabledAsset = value as ScriptableObject;
        }
        
        /// <summary>
        /// Skill disabled asset reference - to be used by skill type
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillEnableStatusAsset))]
        private ScriptableObject skillDisabledAsset;

        private ISkillEnableStatusAsset SkillDisabledAsset
        {
            get => skillDisabledAsset as ISkillEnableStatusAsset;
            set => skillDisabledAsset = value as ScriptableObject;
        }

        private ISkillLogic _skillLogic;
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }
        
        /// <summary>
        /// Method used by 'Silence' and similar effects
        /// </summary>
        public void DisableActiveSkill()
        {   
            //Decrease the skill's usable skill factor
            _skillLogic.OtherSkillAttributes.UsableSkillFactor -= 1;
            
            //Check if there are no other effects preventing to disable the active skill
            //e.g. skill immune to silence effects
            if(_skillLogic.OtherSkillAttributes.UsableSkillFactor < 1)
                _skillLogic.SkillAttributes.SkillType.DisableActiveSkill(_skillLogic.Skill,SkillDisabledAsset);
        }
        
        /// <summary>
        ///Method used by 'Silence' and similar effects
        /// </summary>
        public void EnableActiveSkill()
        {
            //Decrease the skill's usable skill factor
            _skillLogic.OtherSkillAttributes.UsableSkillFactor += 1;
            
            //Check if there are no other effects preventing to enable the active skill
            //e.g.unique silence effects
            if(_skillLogic.OtherSkillAttributes.UsableSkillFactor >= 1)
                _skillLogic.SkillAttributes.SkillType.EnableActiveSkill(_skillLogic.Skill,SkillEnabledAsset);
            
        }

        public void DisablePassiveSkill()
        {
            
        }

        public void EnablePassiveSkill()
        {
            
        }




    }
}
