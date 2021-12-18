using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class HeroSkills : MonoBehaviour, IHeroSkills
    {
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
        
       
        /// <summary>
        /// Returns all skills as list of ISkills
        /// </summary>
        [Header("SET IN RUNTIME")] [SerializeField]
        private List<GameObject> allSkills = new List<GameObject>();
        public List<ISkill> AllSkills
        {
            get
            {
                var skills = new List<ISkill>();
                foreach (var skillObject in allSkills)
                {
                    skills.Add(skillObject.GetComponent<ISkill>());
                }

                return skills;
            }
        }
        
        /// <summary>
        /// Returns all skills as list of ScriptableObjects
        /// </summary>
        /// <returns></returns>
        public List<GameObject> AllSkillsObjects()
        {
            /*foreach (var skill in skills)
            {
                allSkills.Add(skill as ScriptableObject);
            }*/
            return allSkills;
        }
        
        /// <summary>
        /// Hide hero skills from display
        /// </summary>
        public void HideHeroSkills()
        {
            this.gameObject.SetActive(false);
        }
       
        /// <summary>
        /// Display hero skills
        /// </summary>
        public void ShowHeroSkills()
        {
            this.gameObject.SetActive(true);
        }
       
       



    }
}