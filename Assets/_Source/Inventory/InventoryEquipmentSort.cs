using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Additional class for help sort items
/// </summary>
public class InventoryEquipmentSort
{
    #region InWork
    public List<InventorySlot> SortList(List<ItemGeneral> items, BtnSortSlots sortType)
    {
        List<InventorySlot> temp = new List<InventorySlot>();
        foreach (var item in items)
        {
            if ((item as EquipmentItem).EquipmentType == sortType.Type)
            {
                switch (sortType.Type)
                {
                    case EquipmentType.Armor:
                        if (((item as EquipmentItem) as ArmorItem).ArmorType == sortType.ArmorType)
                            temp.Add(item.GetComponentInParent<InventorySlot>());
                        break;
                    case EquipmentType.Weapon:
                        if (((item as EquipmentItem) as WeaponItem).WeaponType == sortType.WeaponType)
                            temp.Add(item.GetComponentInParent<InventorySlot>());
                        break;
                    default:
                        break;
                }
            }
        }
        return temp;
    }
    #endregion

}
