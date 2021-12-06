﻿using System;
using JetBrains.Annotations;
using ScriptableObjectScripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// SkillLogic reference 
    /// </summary>
    public class SkillLogic : MonoBehaviour, ISkillLogic
    {
        /// <summary>
        /// Reference to skill 
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkill))]
        private Object skill;
        
        public ISkill Skill
        {
            get => skill as ISkill;
            set => skill = value as Object;
        }
        



    }
}