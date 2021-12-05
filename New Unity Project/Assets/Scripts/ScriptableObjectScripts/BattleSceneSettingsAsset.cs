using Logic;
using UnityEngine;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "BattleSceneSettings", menuName = "Assets/BattleSceneGeneral/BattleSceneSettings")]
    public class BattleSceneSettingsAsset : ScriptableObject, IBattleSceneSettingsAsset
    {
        /// <summary>
        /// Reference to battle scene manager 
        /// </summary>
        [Header("SET IN RUNTIME")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IBattleSceneManager))]
        private Object battleSceneManager;

        public IBattleSceneManager BattleSceneManager
        {
            get => battleSceneManager as IBattleSceneManager;
            set => battleSceneManager = value as Object;

        }



    }
}
