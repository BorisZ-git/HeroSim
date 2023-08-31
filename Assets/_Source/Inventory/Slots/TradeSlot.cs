using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class TradeSlot : InventorySlot
{
    // Разбить логику операций на разные классы для читабельности

    [Header("Item Stats")]
    [SerializeField] private TMP_Text _textFinalCost;
    [SerializeField] private TMP_Text _textValue;
    [SerializeField] private TMP_Text _textStrength;
    [SerializeField] private TMP_Text _textAgility;
    [SerializeField] private TMP_Text _textRank;
    [SerializeField] private TMP_Text _textCost;

    [Header("Links")]
    [SerializeField] private Button _btnSell;
    [SerializeField] private Button _btnBuy;
    [Header("InventoryLinks")]
    [SerializeField] private GeneralInventory _heroInventory;
    [SerializeField] private GeneralInventory _merchantInventory;

    private float _cost;
    private float _dealPercent;

    public float Cost { get => _cost; }
    public DraggableItem Item { get => _item; }

    #region Separate
    #region This
    protected override bool CheckSlot(DraggableItem item)
    {
        switch (item.belongs)
        {
            case Belongs.Hero:
                _dealPercent = -20f;
                SetPrice(true, false, item.GetComponent<ItemGeneral>());
                break;
            case Belongs.Merchant:
                _dealPercent = 20f;
                SetPrice(false, true, item.GetComponent<ItemGeneral>());
                break;
            default:
                break;
        }
        return true;
    }
    protected override void CheckItemParent()
    {
        if (_item != null && _item.transform.parent != transform)
        {
            ResetItemStateView();
            _item.EndDrag -= CheckItemParent;
            _item = null;
        }
    }
    #endregion
    #region View
    private void SetPrice(bool sell, bool buy, ItemGeneral item)
    {
        _cost = item.Cost + (item.Cost / 100 * _dealPercent);
        _btnSell.interactable = sell;
        _btnBuy.interactable = buy;
        _textCost.text = $"Cost: {item.Cost}";
        _textFinalCost.text = _cost.ToString();
        switch (item.ItemType)
        {
            case ItemType.Equipment:
                SetEquipmentDeal(item as EquipmentItem);
                break;
            case ItemType.Potion:
                break;
            case ItemType.Other:
                break;
            default:
                break;
        }
    }
    private void SetEquipmentDeal(EquipmentItem item)
    {
        string value = "";
        switch (item.EquipmentType)
        {
            case EquipmentType.Armor:
                value = $"Armor: {item.Value}";
                break;
            case EquipmentType.Weapon:
                value = $"Damage: {item.Value}";
                break;
            default:
                break;
        }
        SetTextItemStats(value, item.Strength.ToString(), item.Agility.ToString(), item.Rank.ToString());
    }
    private void SetTextItemStats(string value, string strength, string agility, string rank)
    {
        _textValue.text = value;
        _textStrength.text = "Strength: " + strength;
        _textAgility.text = "Agility: " + agility;
        _textRank.text = "Rank: " + rank;
    }
    private void ResetItemStateView()
    {
        _btnSell.interactable = false;
        _btnBuy.interactable = false;
        _textCost.text = "Cost: ";
        _textFinalCost.text = " ";
        SetTextItemStats("Value: ", " ", " ", " ");
    }
    #endregion
    #region Controller
    public void FinishDeal()
    {
        ResetItemStateView();
        ChangeBelonger();
    }

    private void ChangeBelonger()
    {
        switch (_item.belongs)
        {
            case Belongs.Hero:
                _item.belongs = Belongs.Merchant;
                _heroInventory?.ResizeFreeSlots();
                _merchantInventory?.AddItemToFreeSlot(_item.GetComponent<ItemGeneral>());
                break;
            case Belongs.Merchant:
                _item.belongs = Belongs.Hero;
                _merchantInventory?.ResizeFreeSlots();
                _heroInventory?.AddItemToFreeSlot(_item.GetComponent<ItemGeneral>());
                break;
        }
    }
    #endregion
    #endregion

}
