using Logic;

namespace ScriptableObjectScripts
{
    public interface IBattleSceneSettingsAsset
    {
            
        /// <summary>
        /// Interface access to to player prefab.
        /// Set in the inspector.
        /// </summary>
        IPlayer PlayerPrefab { get; }
        
        /// <summary>
        /// Interface access to to hero prefab.
        /// Set in the inspector.
        /// </summary>
        IHero HeroPrefab { get; }
        
        /// <summary>
        /// Interface access to to skill prefab.
        /// Set in the inspector.
        /// </summary>
        ISkill SkillPrefab { get; }
        
        /// <summary>
        /// Interface access to to skill prefab.
        /// Set in the inspector.
        /// </summary>
        IHeroSkills HeroSkills { get; }
        
        /// <summary>
        /// Interface access to to hero portrait prefab.
        /// Set in the inspector.
        /// </summary>
        IPortrait HeroPortrait { get; }


        




        //SET IN RUNTIME
        
        /// <summary>
        /// Interface access to battle scene manager
        /// </summary>
        IBattleSceneManager BattleSceneManager { get; set; }

    }
    
    
    
}