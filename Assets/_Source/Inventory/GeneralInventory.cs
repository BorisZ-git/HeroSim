using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneralInventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private InventorySlot _slotPrefab;
    protected List<ItemGeneral> _items;
    protected List<InventorySlot> _slots;
    protected List<InventorySlot> _freeSlots;

    // rewrite with own Classes: ArmorList and WeaponList
    //protected ArmorList _equpmentHead = new ArmorList(ArmorType.Head);

    private InventoryEquipmentSort _sortEquipment;
    protected List<InventorySlot> _sortedList;

    private void Awake()
    {
        _sortEquipment = new InventoryEquipmentSort();
        _items = new List<ItemGeneral>();
        _slots = new List<InventorySlot>();
        _freeSlots = new List<InventorySlot>();
        InitLists();
    }
    public void AddItemToFreeSlot(ItemGeneral item)
    {
        if(_freeSlots.Count == 0)
        {
            CreateFreeSlot();
            _slots.Add(_freeSlots[0]);
        }
        item.transform.SetParent(_freeSlots[0].transform);
        _freeSlots.RemoveAt(0);
        // Sort Item
    }
    private void CreateFreeSlot()
    {
        _freeSlots.Add(Instantiate(_slotPrefab, _inventory.transform));
    }
    public void ResizeFreeSlots()
    {
        _freeSlots.Clear();
        foreach (var item in _slots)
        {
            if (item.transform.childCount == 0)
            {
                _freeSlots.Add(item);
            }
        }
    }
    private void InitLists()
    {
        _items.Clear();
        _slots.Clear();
        _freeSlots.Clear();
        _slots = _inventory.GetComponentsInChildren<InventorySlot>().ToList();
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

    #region InWork
    public void ShowAll()
    {
        SlotsOnOff(false);
        SlotsOnOff(true);
    }
    public void SortListByType(BtnSortSlots sortType)
    {
        _sortedList = _sortEquipment.SortList(_items, sortType);
        SlotsOnOff(false);
        foreach (var item in _sortedList)
        {
            item.gameObject.SetActive(true);
        }
    }
    private void SlotsOnOff(bool setter)
    {
        foreach (var item in _slots)
        {
            item.gameObject.SetActive(setter);
        }
    }
    #endregion
}
