using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        /// reset to null when target selected is not valid
        /// </summary>
        private IHero _validSkillTargetHero;
        
        /// <summary>
        /// Enables targeting visual components (line, triangle, cross hair, and draggable)
        /// and sets the list of valid targets
        /// </summary>
        private Action _setHeroTargets;
        
        /// <summary>
        /// Hides the targeting components and applies the skill effect
        /// to a valid target hero
        /// </summary>
        private Action _useHeroSkill;
       

        private void Awake()
        {
            SkillTargetCollider = GetComponent<ISkillTargetCollider>();
            
            //Default setting for _setHeroTargets is No Action
            _setHeroTargets = NoAction;
            
            //Default setting for _useHeroSkill is No Action
            _useHeroSkill = NoAction;

        }

        private void Start()
        {
            SkillTargetCollider.Draggable.DisableDraggable();
        }
        
        /// <summary>
        /// Enables actions when skill readiness is in 'ready' status
        /// </summary>
        public void EnableSelectDragTargetActions()
        {
            _setHeroTargets = SetHeroTargets;
            _useHeroSkill = UseHeroSkill;
        }
        
        /// <summary>
        /// Enables actions when skill readiness is in 'ready' status
        /// </summary>
        public void DisableSelectDragTargetActions()
        {
            _setHeroTargets = NoAction;
            _useHeroSkill = NoAction;
        }

        private void OnMouseDown()
        {
            _setHeroTargets();
        }
        
        private void OnMouseUp()
        {
            _useHeroSkill();
        }

        private void SetHeroTargets()
        {
            //Enables the triangle, cross hair, line, and draggable 
            EnableTargetVisuals();
            
            //Sets the _validTargets list elements
            SetValidTargets();
        }
        
        /// <summary>
        /// Hides the targeting components and applies the skill effect
        /// to a valid target hero
        /// </summary>
        private void UseHeroSkill()
        {
            //Disables the triangle, cross hair, line, and draggable
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
            SetValidTargetHero();
            
            //if there is a valid target
            if(_validSkillTargetHero != null)
                UseSkill();
            
        }


        /// <summary>
        /// If the target is valid, sets the target hero and intended skill action
        /// (both skill and target hero are 'null' by default)
        /// </summary>
        private void SetValidTargetHero()
        {
            // ReSharper disable once PossibleNullReferenceException
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Store at most 5 ray cast hits
            var mResults = new RaycastHit[5];
            
            //ray traverses all layers
            var layerMask = ~0;
            
            //Same to RayCastAll but with no additional garbage
            int hitsCount = Physics.RaycastNonAlloc(ray, mResults, Mathf.Infinity,layerMask);
            
            //Update the latest targeted hero to null
            _validSkillTargetHero = null;
            SkillTargetCollider.Skill.CasterHero.HeroLogic.LastHeroTargets.SetTargetedHero(_validSkillTargetHero);

            for (int i = 0; i < hitsCount; i++)
            {
                if (mResults[i].transform.GetComponent<IHeroTargetCollider>() != null)
                {
                    var targetHeroCollider = mResults[i].transform.GetComponent<IHeroTargetCollider>();

                    //check if hero is included in the valid targets
                    _validSkillTargetHero = _validTargets.Contains(targetHeroCollider.Hero) ? targetHeroCollider.Hero : null;
                }

            }
        }
        
        /// <summary>
        /// Returns a list of valid targets based on skill targets
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
            var skill = SkillTargetCollider.Skill;
            
            //TODO: SetUsingActiveOrBasicSkillStatus 

            //TODO: SetUsedLastTurnSkillStatus - Reworked, check if still needed
            
            //TODO: UseSkillEffect IEnumerator
            logicTree.AddCurrent(UseSkillEffect());
            
            //ResetSkillCooldown
            logicTree.AddCurrent(ResetSkillCooldown());

            //UpdateSkillReadiness coroutine (needs to wait for use skill effect to finish)
            logicTree.AddCurrent(skill.SkillLogic.UpdateSkillReadiness.StartActionCoroutine());

            //End hero turn coroutine
            logicTree.AddCurrent(casterHero.Player.BattleSceneManager.TurnController.HeroEndTurn.StartAction());
        }

        private IEnumerator UseSkillEffect()
        {
            var casterHero = SkillTargetCollider.Skill.CasterHero;
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var skill = SkillTargetCollider.Skill;
                
            //set caster hero's targeted hero 
            casterHero.HeroLogic.LastHeroTargets.SetTargetedHero(_validSkillTargetHero);
            
            //TEST - transfer to basic action set targeted hero's targeting hero
            //_validSkillTargetHero.HeroLogic.LastHeroTargets.SetTargetingHero(casterHero);
            
            //Call all EventSkillDragTarget subscribers' start action
            skill.SkillLogic.SkillEvents.EventDragSkillTarget(casterHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Reset skill cooldown after skill use
        /// </summary>
        /// <returns></returns>
        private IEnumerator ResetSkillCooldown()
        {
            var skill = SkillTargetCollider.Skill;
            var logicTree = skill.CasterHero.CoroutineTrees.MainLogicTree;

            skill.SkillLogic.UpdateSkillCooldown.UseSkillResetCooldown();
            
            logicTree.EndSequence();
            yield return null;
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
        
        /// <summary>
        /// Dummy action method assigned when skill readiness status is 'Not Ready'
        /// </summary>
        private void NoAction()
        {
        }


    }
}