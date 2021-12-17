using System.Collections;
using UnityEngine;

/// <summary>
/// Sets the hero's health value and visual text
/// </summary>
public class SetHealth : MonoBehaviour, ISetHealth
{
    private IHeroLogic _heroLogic;
        
    private void Awake()
    {
        _heroLogic = GetComponent<IHeroLogic>();
    }

    public void StartAction(int value)
    {
        //var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
        //var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            
            
        //set attribute value
        _heroLogic.HeroAttributes.Health = value;
            
        //visualTree.AddCurrent(SetVisualValue(value));
        SetVisualValue(value);

        //logicTree.EndSequence();
        //yield return null;
    }

    private void SetVisualValue(int value)
    {
        //var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
        var baseValue = _heroLogic.HeroAttributes.BaseHealth;
            
        _heroLogic.Hero.HeroVisual.HealthVisual.Text.text = value.ToString();
        _heroLogic.Hero.HeroVisual.HealthVisual.Text.color = GetTextColor(value, baseValue); 
            
        //visualTree.EndSequence();
        //yield return null;
    }
        
    private Color GetTextColor(int baseValue, int value)
    {
        if(value>baseValue)
            return Color.green;
        else if (value == baseValue)
            return Color.white;
        else if(value < baseValue)
            return Color.red;
        else
            return Color.white;
            
    }


}