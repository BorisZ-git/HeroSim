using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

abstract public class GeneralInventory : MonoBehaviour
{
    [SerializeField] private InventorySlot _slotPrefab;
    protected List<ItemGeneral> _items;
    protected List<InventorySlot> _slots;
    protected List<InventorySlot> _freeSlots;

    // rewrite with own Classes: ArmorList and WeaponList
    //protected ArmorList _equpmentHead = new ArmorList(ArmorType.Head);
    protected List<ItemGeneral> _equipmentHead;
    protected List<ItemGeneral> _equipmentShoulder;
    protected List<ItemGeneral> _equipmentBack;
    protected List<ItemGeneral> _equipmentChest;
    protected List<ItemGeneral> _equipmentHands;
    protected List<ItemGeneral> _equipmentLegs;

    protected List<ItemGeneral> _equipmentOneHandSword;
    protected List<ItemGeneral> _equipmentTwoHandSword;
    protected List<ItemGeneral> _equipmentDagger;
    protected List<ItemGeneral> _equipmentStaff;
    private InventoryEquipmentSort _sortEquipment;

    private void Awake()
    {
        _sortEquipment = new InventoryEquipmentSort();
        ResizeLists();
    }
    public void AddItemToFreeSlot(ItemGeneral item)
    {
        if(_freeSlots.Count == 0)
        {
            CreateFreeSlot();
        }
        item.transform.SetParent(_freeSlots[0].transform);
        _slots.Add(_freeSlots[0]);
        _freeSlots.RemoveAt(0);
    }
    private void CreateFreeSlot()
    {
        _freeSlots.Add(Instantiate(_slotPrefab, transform));
    }
    private void ResizeLists()
    {
        _items.Clear();
        _slots.Clear();
        _freeSlots.Clear();
        _slots = GetComponentsInChildren<InventorySlot>().ToList();
        foreach (var item in _slots)
        {
            if (item.transform.childCount > 0)
            {
                _items.Add(item.GetComponentInChildren<ItemGeneral>());
                //Sort items
                //SortItemType(item.GetComponentInChildren<ItemGeneral>());
            }
            else
            {
                _freeSlots.Add(item);
            }
        }
    }
    private void SortItemType(ItemGeneral item)
    {
        switch (item.ItemType)
        {
            case ItemType.Equipment:
                _sortEquipment.SortItem(item);
                break;
            case ItemType.Potion:
                break;
            case ItemType.Other:
                break;
            default:
                break;
        }
    }

    // Слишком громосткая реализация, в принципе я знаю о том какие у меня есть вкладки и что они должны отображать.
    // Поэтому я могу создать отдельный скрипт для вкладки типа баттон и задавать на этом скрипте в сериализуемые поля
    // Те условия по которым необходимо произвести сортировку
    //public void TestShowCatalog(BtnPageFilter btnPageFilter)
    //{
    //    foreach (var item in _slots)
    //    {
    //        if(item.GetComponentInChildren<ItemGeneral>().ItemType == btnPageFilter.ItemType)
    //        {
    //            что-то делать
    //        }
    //    }
    //}

    // Либо можно попробовать реализовать через лямбду(Linq) 
    //private List<InventorySlot> TestLinqSort()
    //{
    //    List<InventorySlot> temp = new List<InventorySlot>();
    //    temp = _slots where e => e.NeedType;
    //    return temp;
    //}

    public void ShowTypeCatalog(ItemType type)
    {
        switch (type)
        {
            case ItemType.Equipment:
                break;
            case ItemType.Potion:
                break;
            case ItemType.Other:
                break;
            default:
                break;
        }
    }
    private void ShowEquipmentCatalog(EquipmentType type)
    {
        switch (type)
        {
            case EquipmentType.Armor:
                break;
            case EquipmentType.Weapon:
                break;
            default:
                break;
        }
    }
    private void ShowArmorCatalog(ArmorType type)
    {
        switch (type)
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
}
