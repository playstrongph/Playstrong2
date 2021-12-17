using System;
using JetBrains.Annotations;
using ScriptableObjectScripts;
using UnityEngine;
using Object = UnityEngine.Object;

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

    /// <summary>
    /// Contains the skill properties such as cooldown, skill type, etc.
    /// </summary>
    public ISkillAttributes SkillAttributes { get; private set; }
        
    /// <summary>
    /// Loads the skill attributes from the skill asset
    /// </summary>
    public ILoadSkillAttributes LoadSkillAttributes { get; private set; }

    private void Awake()
    {
        SkillAttributes = GetComponent<ISkillAttributes>();
        LoadSkillAttributes = GetComponent<ILoadSkillAttributes>();
    }
}