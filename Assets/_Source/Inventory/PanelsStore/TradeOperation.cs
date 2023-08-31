using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeOperation : MonoBehaviour
{
    [Header("Item Stats")]
    [SerializeField] private TMP_Text _textFinalCost;
    [SerializeField] private TMP_Text _textValue;
    [SerializeField] private TMP_Text _textStrength;
    [SerializeField] private TMP_Text _textAgility;
    [SerializeField] private TMP_Text _textRank;
    [SerializeField] private TMP_Text _textCost;

    [Header("Links")]
    [SerializeField] private TradeSlot _slot;
    [SerializeField] private Button _btnSell;
    [SerializeField] private Button _btnBuy;
    [Header("InventoryLinks")]
    [SerializeField] private GeneralInventory _heroInventory;
    [SerializeField] private GeneralInventory _merchantInventory;
    private void Awake()
    {
        if(_slot == null)
        {
            _slot = GetComponentInChildren<TradeSlot>();
        }
    }
    public void TradeDeal(bool isBuy)
    {
        if (isBuy && TryBuy())
        {
            HeroController.ChangeMoney(-_slot.Cost);
            _slot.FinishDeal();
        }
        else if(!isBuy)
        {
            HeroController.ChangeMoney(+_slot.Cost);
            _slot.FinishDeal();
        }
    }
    private bool TryBuy()
    {
        if(_slot.Cost > HeroData.Money)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #region InWork

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
        ChangeItemBelonger();
    }
    private void ResetItemStateView()
    {
        _btnSell.interactable = false;
        _btnBuy.interactable = false;
        _textCost.text = "Cost: ";
        _textFinalCost.text = " ";
        SetTextItemStats("Value: ", " ", " ", " ");
    }
    private void ChangeItemBelonger()
    {
        switch (_slot.Item.belongs)
        {
            //case Belongs.Hero:
            //    _item.belongs = Belongs.Merchant;
            //    _heroInventory?.ResizeFreeSlots();
            //    _merchantInventory?.AddItemToFreeSlot(_item.GetComponent<ItemGeneral>());
            //    break;
            //case Belongs.Merchant:
            //    _item.belongs = Belongs.Hero;
            //    _merchantInventory?.ResizeFreeSlots();
            //    _heroInventory?.AddItemToFreeSlot(_item.GetComponent<ItemGeneral>());
            //    break;
        }
    }

    #endregion
}
