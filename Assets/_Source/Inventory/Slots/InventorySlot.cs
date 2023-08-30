using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] protected Belongs _belong;
    protected DraggableItem _item;
    private DraggableItem _dragItem;
    public virtual void OnDrop(PointerEventData eventData)
    {
        _dragItem = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (transform.childCount == 0 && CheckSlot(_dragItem))
        {
            _item = _dragItem;
            _item.ParentAfterDrag = this.transform;
        }
    }
    protected virtual bool CheckSlot(DraggableItem item)
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
}
