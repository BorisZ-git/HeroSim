using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] protected Belongs _belong;
    protected DraggableItem _item;
    private DraggableItem _dragItem;
    public void OnDrop(PointerEventData eventData)
    {
        _dragItem = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (transform.childCount == 0 && CheckSlotBelongs(_dragItem))
        {
            _item = _dragItem;
            if (_item != null && _item.transform.parent != this.transform)
            {
                _item.EndDrag += FinishDrag;
            }
            _item.ParentAfterDrag = this.transform;
        }
    }
    protected virtual bool CheckSlotBelongs(DraggableItem item)
    {
        if (item == null) return false;
        switch (_belong)
        {
            case Belongs.Trade:
                return true;
            default:
                return _belong == item.belongs;
        }
    }
    /// <summary>
    /// End drag logic with call resize free slots in inventory
    /// </summary>
    protected virtual void FinishDrag()
    {
        switch (_belong)
        {
            case Belongs.Trade:
                _item.EndDrag += CheckItemParent;
                break;
            default:
                GetComponentInParent<GeneralInventory>().ResizeFreeSlots();
                break;
        }
        _item.EndDrag -= FinishDrag;
    }
    /// <summary>
    /// Checking for neccesery of resize free slots in inventory. If item.parent != slot.parent on drop
    /// </summary>
    protected virtual void CheckItemParent() { print("Not ovveride in Inventory children classes method ResetItemStateView"); }
}
