using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeOperation : MonoBehaviour
{
    [SerializeField] private TradeSlot _slot;
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
}
