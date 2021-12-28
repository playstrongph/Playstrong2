using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Logic
{
    public class SelectDragTarget : MonoBehaviour, ISelectDragTarget
    {
        private ISkillTargetCollider SkillTargetCollider { get; set; }
        
        //private delegate void DisplayAction(Vector3 x, Vector3 y);
        //private List<DisplayAction> _displayActions = new List<DisplayAction>();
        
        /// <summary>
        /// List of valid hero targets taken during
        /// on mouse down event
        /// </summary>
        private List<IHero> _validTargets;
        
        /// <summary>
        /// The intended target hero for the skill being used
        /// </summary>
        private IHero _skillTargetHero;

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
            //Displays the hero glows of the valid targets
            EnableTargetVisuals();
            
            //Sets the _validTargets list elements
            SetValidTargets();
        }
        
        private void OnMouseUp()
        {
            //Hides the hero glows of the valid targets
            DisableTargetVisuals();
            
            //Applies skill effect on target hero
            UseSkillOnTargetHero();
        }

        /// <summary>
        /// Applies skill effect on target hero
        /// if there is a valid target
        /// </summary>
        private void UseSkillOnTargetHero()
        {   
            //Set _skillTargetHero to either null or a valid target
            GetRaycastHits();
            
            if(_skillTargetHero != null)
                UseSkill();
        }


        /// <summary>
        /// If the target is valid, sets the target hero and intended skill action
        /// (both skill and target hero are 'null' by default)
        /// </summary>
        private void GetRaycastHits()
        {
            Debug.Assert(Camera.main != null, "Camera.main != null");
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ReSharper disable once Unity.PreferNonAllocApi
            var hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                if (hit.transform.GetComponent<IHeroTargetCollider>() != null)
                {
                    var targetHero = hit.transform.GetComponent<IHeroTargetCollider>();
            
                    _skillTargetHero = _validTargets.Contains(targetHero.Hero) ? targetHero.Hero : null;
                }
            }

        }
        
        /// <summary>
        /// Returns a list of valid targets
        /// </summary>
        private void SetValidTargets()
        {
            _validTargets = SkillTargetCollider.GetSkillTargets.GetValidTargets();
        }
        
        /// <summary>
        /// Applies skill effect to the target hero and ends the hero turn
        /// </summary>
        private void UseSkill()
        {
            var casterHero = SkillTargetCollider.Skill.CasterHero;
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //TODO: SetUsingActiveOrBasicSkillStatus IEnumerator
            //TODO: ResetSkillCooldown IEnumerator
            //TODO: UseSkillEffect IEnumerator
            //TODO: UpdateSkillReadiness IEnumerator
            
           
            //End Hero Turn
            logicTree.AddCurrent(casterHero.Player.BattleSceneManager.TurnController.HeroEndTurn.StartAction());

            //TODO: SetUsedLastTurnSkillStatus IEnumerator
        }



        #region DRAGTARGETVISUALS

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
        /// Enables the targeting component visuals - cross hair, triangle, and line renderer.
        /// Also enables draggable. 
        /// </summary>
        private void EnableTargetVisuals()
        {
            //Resets local position to zero
            transform.localPosition = Vector3.zero;
            
            SkillTargetCollider.CrossHair.SetActive(true);
            SkillTargetCollider.Triangle.SetActive(true);
            SkillTargetCollider.TargetLine.gameObject.SetActive(true);
            
            SkillTargetCollider.Draggable.EnableDraggable();
            
            ShowLineAndTarget();
        }
        
        /// <summary>
        /// Disables the targeting component visuals - cross hair, triangle, and line renderer
        /// Also disables draggable.
        /// </summary>
        private void DisableTargetVisuals()
        {
            transform.localPosition = Vector3.zero;
            
            SkillTargetCollider.CrossHair.SetActive(false);
            SkillTargetCollider.Triangle.SetActive(false);
            SkillTargetCollider.TargetLine.gameObject.SetActive(false);
            
            SkillTargetCollider.Draggable.DisableDraggable();
        }
        
        #endregion
    }
}