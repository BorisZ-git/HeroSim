using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// инкапсулировать данные
/// </summary>
public static class HeroData
{
    private static float _money;
    private static HeroRank _rank;
    private static string _lvl;

    public static float Money { get => _money; set => _money = value; }
    public static HeroRank Rank { get => _rank; set => _rank = value; }
    public static string Lvl { get => _lvl; set => _lvl = value; }
}
