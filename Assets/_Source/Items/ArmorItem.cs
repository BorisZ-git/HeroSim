using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : EquipmentItem
{
    [SerializeField] private ArmorType _armorType;
    public ArmorType ArmorType { get => _armorType; }
}
