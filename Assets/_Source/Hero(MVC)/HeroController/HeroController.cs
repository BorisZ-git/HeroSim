using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class HeroController
{
    public static event Action UpdateHeroPanel;

    public static void ChangeMoney(float value)
    {
        HeroData.Money += value;
        UpdateHeroPanel();
    }
}
