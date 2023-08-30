using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEquipmentSort
{
    private ItemGeneral _item;
    public void SortItem(ItemGeneral item)
    {
        _item = item;
        switch ((item as EquipmentItem).EquipmentType)
        {
            case EquipmentType.Armor:
                SortArmor(item as ArmorItem);
                break;
            case EquipmentType.Weapon:
                SortWeapon(item as WeaponItem);
                break;
            default:
                break;
        }
    }
    private void SortArmor(ArmorItem item)
    {        
        switch (item.ArmorType)
        {
            case ArmorType.Head:
                break;
            case ArmorType.Shoulders:
                break;
            case ArmorType.Back:
                break;
            case ArmorType.Chest:
                break;
            case ArmorType.Hands:
                break;
            case ArmorType.Legs:
                break;
            default:
                break;
        }
    }
    private void SortWeapon(WeaponItem item)
    {
        switch (item.WeaponType)
        {
            case WeaponType.OneHandSword:
                break;
            case WeaponType.TwoHandSword:
                break;
            case WeaponType.Dagger:
                break;
            case WeaponType.Staff:
                break;
            default:
                break;
        }
    }
}
