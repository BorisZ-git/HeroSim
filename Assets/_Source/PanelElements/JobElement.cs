using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]
public class JobElement : GeneralElement
{
    protected override void Awake()
    {
        UpdateUIView(Value.ToString(), Expirience, ExpProgress, Lvl);
    }
    public override void UpdateUIView(string value, float expirience, float expProgress, int lvl)
    {
        base.UpdateUIView($"+{value} / day", expirience, expProgress, lvl);
    }
}
