using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{
    public class LoadSkillPreviewVisual : MonoBehaviour, ILoadSkillPreviewVisual
    {
        private ISkillPreview _skillPreview;

        private void Awake()
        {
            _skillPreview = GetComponent<ISkillPreview>();
        }
        
        /// <summary>
        /// Sets the skill preview details - icon, cooldown text, name, description, etc.
        /// </summary>
        /// <param name="skillAsset"></param>
        public void StartAction(ISkillAsset skillAsset)
        {
            var skillPreviewTransform = _skillPreview.Skill.CasterHero.Player.HeroAndSkillPreviews.ThisGameObject.transform;
            
            //Set skill preview details
            _skillPreview.GraphicImage.sprite = skillAsset.SkillIcon;
            _skillPreview.Cooldown.text = _skillPreview.Skill.SkillLogic.SkillAttributes.Cooldown.ToString();
            _skillPreview.PreviewName.text = skillAsset.SkillName;
            _skillPreview.Description.text = skillAsset.SkillDescription;
            
            //Set skill preview board location
            _skillPreview.ThisGameObject.transform.SetParent(skillPreviewTransform);
            _skillPreview.ThisGameObject.transform.localPosition = Vector3.zero;
        }
    }
}