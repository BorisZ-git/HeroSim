using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class TradeSlot : InventorySlot
{
    // Переносить элемент в надлежащии инвентари
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
    private float _cost;
    private float _dealPercent;

    public float Cost { get => _cost; }
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        _item.EndDrag += CheckItemParent;
    }
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
    private void CheckItemParent()
    {
        if(_item?.transform.parent != transform)
        {
            ResetItemStateView();
            _item.EndDrag -= CheckItemParent;
            _item = null;
        }
    }
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
    public void FinishDeal()
    {
        ResetItemStateView();
        Destroy(_item.gameObject);
        return;
        ChangeBelonger();
    }
    private void ResetItemStateView()
    {
        _btnSell.interactable = false;
        _btnBuy.interactable = false;
        _textCost.text = "Cost: ";
        _textFinalCost.text = " ";
        SetTextItemStats("Value: ", " ", " ", " ");
    }
    private void ChangeBelonger()
    {
        switch (_item.belongs)
        {
            case Belongs.Hero:
                _item.belongs = Belongs.Merchant;
                break;
            case Belongs.Merchant:
                _item.belongs = Belongs.Hero;
                break;
        }
        // Должны добавлять объект в список элементов определенных инвентарей
        // Для этого нужно создать логику списков содержащихся в инвентаре объектов
        _item.transform.SetParent(transform);
        _item.ParentAfterDrag = gameObject.transform;
    }
}
