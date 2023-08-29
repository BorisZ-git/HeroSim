using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeroController
{
    public static void ChangeMoney(float value)
    {
        HeroData.Money += value;
        HeroPanel.HeroViewHeader.UpdateUIView();
    }
}
