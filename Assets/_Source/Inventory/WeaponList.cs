using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList
{
    public List<ItemGeneral> Items;
    public WeaponType WeaponType;
    public WeaponList(WeaponType type)
    {
        Items = new List<ItemGeneral>();
        WeaponType = type;
    }
}
