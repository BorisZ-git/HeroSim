using UnityEngine;

[RequireComponent(typeof(TradeItemStats))]
public class TradeOperation : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private TradeSlot _slot;
    [SerializeField] private TradeItemStats _tradeView;

    [Header("InventoryLinks")]
    [SerializeField] private GeneralInventory _heroInventory;
    [SerializeField] private GeneralInventory _merchantInventory;

    private void Awake()
    {
        if(_slot == null)
        {
            _slot = GetComponentInChildren<TradeSlot>();
        }
        if(_tradeView == null)
        {
            _tradeView = GetComponent<TradeItemStats>();
        }
        _slot.SetController(this);
    }
    public void TradeDeal(bool isBuy)
    {
        if (isBuy && TryBuy())
        {
            HeroController.ChangeMoney(-_slot.Cost);
            FinishDeal();
        }
        else if(!isBuy)
        {
            HeroController.ChangeMoney(+_slot.Cost);
            FinishDeal();
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
    public void FinishDeal()
    {
        _tradeView.ResetItemStateView();
        ChangeBelonger();
    }
    private void ChangeBelonger()
    {
        switch (_slot.DrageItem.belongs)
        {
            case Belongs.Hero:
                _slot.DrageItem.belongs = Belongs.Merchant;
                _heroInventory?.ResizeFreeSlots();
                _merchantInventory?.AddItemToFreeSlot(_slot.DrageItem.Item);
                break;
            case Belongs.Merchant:
                _slot.DrageItem.belongs = Belongs.Hero;
                _merchantInventory?.ResizeFreeSlots();
                _heroInventory?.AddItemToFreeSlot(_slot.DrageItem.Item);
                break;
        }
    }
    public void UpdateItemStats(bool sell, bool buy, ItemGeneral item, float finalCost)
    {
        _tradeView.SetPrice(sell, buy, item, finalCost);
    }
    public void EmptySlot()
    {
        _tradeView.ResetItemStateView();
    }
}
