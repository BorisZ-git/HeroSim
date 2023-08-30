using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : EquipmentItem
{
    [SerializeField] private WeaponType _weaponType;
    public WeaponType WeaponType { get => _weaponType; }
}
