using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSortSlots : MonoBehaviour
{
    [SerializeField] private EquipmentType _type;
    private WeaponType _weaponType;
    private ArmorType _armorType;    
    private bool _isSet;

    public EquipmentType Type { get => _type; }
    public WeaponType WeaponType { get => _weaponType; }
    public ArmorType ArmorType { get => _armorType; }

    /// <summary>
    /// for additional script; if true it will not be update on Init;
    /// </summary>
    public bool IsSet { get => _isSet; set => _isSet = value; }

    public void SetWeaponType(string type)
    {
        _weaponType = (WeaponType)System.Enum.Parse(typeof(WeaponType), type);
    }
    public void SetArmorType(string type)
    {
        _armorType = (ArmorType)System.Enum.Parse(typeof(ArmorType),type);
    }
}
