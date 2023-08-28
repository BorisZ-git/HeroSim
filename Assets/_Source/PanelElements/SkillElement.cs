using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class SkillElement : GeneralElement
{
    [SerializeField] private Skills _skills;
    private string _strValue;
    protected override void Awake()
    {
        UpdateUIView(Value.ToString(), Expirience, ExpProgress, Lvl);
    }
    public override void UpdateUIView(string value, float expirience, float expProgress, int lvl)
    {
        _strValue = $"+{value} {_skills}";
        base.UpdateUIView(_strValue, expirience, expProgress, lvl);
    }
}
