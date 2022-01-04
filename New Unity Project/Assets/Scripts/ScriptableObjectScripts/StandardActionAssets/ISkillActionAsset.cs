﻿using Logic;

namespace ScriptableObjectScripts.StandardActionAssets
{
    public interface ISkillActionAsset
    {
        /// <summary>
        /// Initialized during LoadAttributes create unique standard actions
        /// </summary>
        /// <param name="skill"></param>
        void InitializeSkillReference(ISkill skill);

        /// <summary>
        /// Executes the base class method StartActionCoroutine
        /// When skill readiness status is 'SkillReady'
        /// </summary>
        /// <param name="hero"></param>
        void SkillStartAction(IHero hero);
    }
}