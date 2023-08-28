using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] protected Belongs _belong;
    protected DraggableItem _item;
    public virtual void OnDrop(PointerEventData eventData)
    {
        _item = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (transform.childCount == 0 && CheckSlot(_item))
        {
            _item.ParentAfterDrag = this.transform;
        }
    }
    protected virtual bool CheckSlot(DraggableItem item)
    {
        switch (_belong)
        {
            case Belongs.Trade:
                return true;
            default:
                return _belong == item.belongs;
        }
    }
}
