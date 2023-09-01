using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeItemStats : MonoBehaviour
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

    public void SetPrice(bool sell, bool buy, ItemGeneral item, float finalCost)
    {
        _btnSell.interactable = sell;
        _btnBuy.interactable = buy;
        _textCost.text = $"Cost: {item.Cost}";
        _textFinalCost.text = finalCost.ToString();
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
    public void ResetItemStateView()
    {
        _btnSell.interactable = false;
        _btnBuy.interactable = false;
        _textCost.text = "Cost: ";
        _textFinalCost.text = " ";
        SetTextItemStats("Value: ", " ", " ", " ");
    }
}
