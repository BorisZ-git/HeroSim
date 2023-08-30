using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorList 
{
    public List<ItemGeneral> Items;
    public ArmorType ArmorType;
    public ArmorList(ArmorType type)
    {
        Items = new List<ItemGeneral>();
        ArmorType = type;
    }
}
