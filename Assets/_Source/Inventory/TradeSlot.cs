using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TradeSlot : InventorySlot
{
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

    private void SetPrice(bool sell, bool buy, ItemGeneral item)
    {
        _cost = item.Cost + (item.Cost / 100 * _dealPercent);
        _btnSell.interactable = sell;
        _btnBuy.interactable = buy;
        _textCost.text = $"Cost: {item.Cost}";
        _textFinalCost.text = _cost.ToString();
        switch (item.ItemType)
        {
            case ItemType.Armor:
                SetTextItemStats($"Armor: {(item as ArmorItem).Armor}", $"Strength: {(item as ArmorItem).Strength}",
    $"Agility: {(item as ArmorItem).Agility}", $"Rank: {(item as ArmorItem).Rank}");
                break;
            case ItemType.Weapon:
                SetTextItemStats($"Damage: {(item as WeaponItem).Damage}", $"Strength: {(item as WeaponItem).Strength}",
                    $"Agility: {(item as WeaponItem).Agility}", $"Rank: {(item as WeaponItem).Rank}");
                break;
            default:
                break;
        }
        // переписать поля как общие
    }
    private void SetTextItemStats(string value, string strength, string agility, string rank)
    {
        _textValue.text = value;
        _textStrength.text = strength;
        _textAgility.text = agility;
        _textRank.text = rank;
    }
}
