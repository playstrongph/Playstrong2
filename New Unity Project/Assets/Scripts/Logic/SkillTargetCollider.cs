using System;
using JetBrains.Annotations;
using ScriptableObjectScripts;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// SkillPreview reference 
    /// </summary>
    public class SkillTargetCollider : MonoBehaviour, ISkillTargetCollider
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
        /// Reference to skill target collider canvas
        /// </summary>
        [SerializeField] private Canvas colliderCanvas;
        public Canvas ColliderCanvas
        {
            get => colliderCanvas;
            set => colliderCanvas = value;
        }
        
        /// <summary>
        /// Reference to skill target cross hair
        /// </summary>
        [SerializeField] private Image crossHair;
        public Image CrossHair
        {
            get => crossHair;
            set => crossHair = value;
        }
        
        /// <summary>
        /// Reference to skill target triangle
        /// </summary>
        [SerializeField] private Image triangle;
        public Image Triangle
        {
            get => triangle;
            set => triangle = value;
        }

        /// <summary>
        /// Reference to skill target line renderer
        /// </summary>
        [SerializeField] private LineRenderer targetLine;
        public LineRenderer TargetLine
        {
            get => targetLine;
            set => targetLine = value;
        }




    }
}
