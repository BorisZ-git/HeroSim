using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSortSlots : MonoBehaviour
{
    [SerializeField] private EquipmentType _type;
    [Header("Choose equal type")]
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private ArmorType _armorType;    

    public EquipmentType Type { get => _type; }
    public WeaponType WeaponType { get => _weaponType; }
    public ArmorType ArmorType { get => _armorType; }

}
