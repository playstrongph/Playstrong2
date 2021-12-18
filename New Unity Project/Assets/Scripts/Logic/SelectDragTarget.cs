using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class SelectDragTarget : MonoBehaviour, ISelectDragTarget
    {
        private ISkillTargetCollider SkillTargetCollider { get; set; }
        
        private delegate void DisplayAction(Vector3 x, Vector3 y);
        
        private List<DisplayAction> _displayActions = new List<DisplayAction>();

        private void Awake()
        {
            SkillTargetCollider = GetComponent<ISkillTargetCollider>();
        }

        private void Start()
        {
            SkillTargetCollider.Draggable.DisableDraggable();
        }

        private void OnMouseDown()
        {
            transform.localPosition = Vector3.zero;
            
            EnableTargetVisuals();
            SkillTargetCollider.Draggable.EnableDraggable();
            ShowLineAndTarget();
        }
        
        private void OnMouseUp()
        {
            transform.localPosition = Vector3.zero;
            
            DisableTargetVisuals();
            SkillTargetCollider.Draggable.DisableDraggable();
            
        }
        
        
        /// <summary>
        /// Displays the line and cross hair when the mouse is dragged a certain distance
        /// from the skill
        /// </summary>
        public void ShowLineAndTarget()
        {
            var notNormalized = transform.position - transform.parent.position;
            var direction = notNormalized.normalized;
            var distanceFromHero = (direction*50f).magnitude;
        
            
            //Hide Triangle and Line while target is close to HeroObject
            SkillTargetCollider.Triangle.SetActive(false);
            SkillTargetCollider.TargetLine.enabled = false;
            
            var difference = notNormalized.magnitude - distanceFromHero;
            var intDifference = Mathf.RoundToInt(difference);
            var index = Mathf.Clamp(intDifference, 0, 1);

            if (intDifference > 0)
                DisplayLineAndTriangle(notNormalized,direction);
        }

        private void DisplayLineAndTriangle(Vector3 notNormalized, Vector3 direction)
        {
            SkillTargetCollider.TargetLine.enabled = true;
            SkillTargetCollider.Triangle.SetActive(true);
            
            SkillTargetCollider.TargetLine.SetPositions(new Vector3[]{transform.parent.position, transform.position - direction*20f});
            SkillTargetCollider.Triangle.transform.position = transform.position - 15f * direction;
            
            float rotZ = Mathf.Atan2(notNormalized.y, notNormalized.x) * Mathf.Rad2Deg;
            SkillTargetCollider.Triangle.transform.rotation = Quaternion.Euler(0f,0f,rotZ-90);
            
            //Disable Hero Preview
            SkillTargetCollider.DisplaySkillPreview.HidePreview();

        }


        /// <summary>
        /// Enables the targeting component visuals - cross hair, triangle, and line renderer
        /// </summary>
        private void EnableTargetVisuals()
        {
            SkillTargetCollider.CrossHair.SetActive(true);
            SkillTargetCollider.Triangle.SetActive(true);
            SkillTargetCollider.TargetLine.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Disables the targeting component visuals - cross hair, triangle, and line renderer
        /// </summary>
        private void DisableTargetVisuals()
        {
            SkillTargetCollider.CrossHair.SetActive(false);
            SkillTargetCollider.Triangle.SetActive(false);
            SkillTargetCollider.TargetLine.gameObject.SetActive(false);
        }
    }
}