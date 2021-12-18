using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Logic
{
    [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Draggable : MonoBehaviour, IDraggable
    {
        /// <summary>
        /// distance from the center of this Game Object to the point where we clicked to start dragging 
        /// </summary>
        private Vector3 _pointerDisplacement;
        
        /// <summary>
        /// distance from camera to mouse on Z axis 
        /// </summary>
        private float _zDisplacement;

        private ISkillTargetCollider SkillTargetCollider { get; set; }

        private void Awake()
        {
            SkillTargetCollider = GetComponent<ISkillTargetCollider>();
        }

        private void OnEnable()
        {
            _zDisplacement = -Camera.main.transform.position.z + transform.position.z;
            _pointerDisplacement = -transform.position + MouseInWorldCoords();
        }
        
        
        private void Update()
        {
            var mousePos = MouseInWorldCoords();    
            
            transform.position = new Vector3(mousePos.x - _pointerDisplacement.x, mousePos.y - _pointerDisplacement.y, transform.position.z);
            
            SkillTargetCollider.SelectDragTarget.ShowLineAndTarget();
        
        }
        

        private Vector3 MouseInWorldCoords()
        {
            var screenMousePos = Input.mousePosition;
            //Debug.Log(screenMousePos);
            screenMousePos.z = _zDisplacement;
            return Camera.main.ScreenToWorldPoint(screenMousePos);
        }
        
        /// <summary>
        /// Enables draggable script
        /// specifically, the update method
        /// </summary>
        public void EnableDraggable()
        {
            this.enabled = true;
        }
        
        /// <summary>
        /// Disables the draggable script
        /// prevents the Update method from running continuously
        /// </summary>
        public void DisableDraggable()
        {
            this.enabled = false;
        }

    }
}