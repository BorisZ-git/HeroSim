
public class TradeSlot : InventorySlot
{
    private TradeOperation _tradeController;
    private float _cost;
    private float _dealPercent;

    public float Cost { get => _cost; }
    public DraggableItem DrageItem { get => _item; }
    private void Start()
    {
        if (_tradeController == null)
        {
            _tradeController = GetComponentInParent<TradeOperation>();
        }
    }
    public void SetController(TradeOperation tradeController)
    {
        _tradeController = tradeController;
    }
    protected override bool CheckSlotBelongs(DraggableItem dragItem)
    {
        if (dragItem == null) return false;
        _dealPercent = 20f;
        switch (dragItem.belongs)
        {
            case Belongs.Hero:
                _cost = dragItem.Item.Cost + (dragItem.Item.Cost / 100 * -_dealPercent);
                _tradeController.UpdateItemStats(true, false, dragItem.Item, _cost);
                break;
            case Belongs.Merchant:
                _cost = dragItem.Item.Cost + (dragItem.Item.Cost / 100 * _dealPercent);
                _tradeController.UpdateItemStats(false, true, dragItem.Item, _cost);
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
            _tradeController.EmptySlot();
            _item.EndDrag -= CheckItemParent;
            _item = null;
        }
    }
}
