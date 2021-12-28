﻿using System;
using ScriptableObjectScripts.SkillCooldownTypeAssets;
using ScriptableObjectScripts.SkillTargetsAssets;
using UnityEngine;

namespace AssetsScriptableObjects
{
    public interface ISkillAsset
    {
        /// <summary>
        /// Reference to name of the skill
        /// </summary>
        String SkillName { get; }
        /// <summary>
        /// Reference to the skill ability text
        /// </summary>
        String SkillDescription { get; }
        
        /// <summary>
        /// Reference to the skill graphic icon
        /// </summary>
        Sprite SkillIcon { get; }
        
        /// <summary>
        /// Reference to the skill cooldown
        /// </summary>
        int BaseCooldown { get; }
        
        /// <summary>
        /// Skill targets asset
        /// </summary>
        ISkillTargetsAsset SkillTargetsAsset { get; }
        
        /// <summary>
        /// Skill Cooldown type asset
        /// </summary>
        ISkillCooldownTypeAsset SkillCooldownTypeAsset { get; }


    }
}