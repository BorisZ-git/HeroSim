using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Image))] [RequireComponent(typeof(ItemGeneral))]
public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public event Action EndDrag;

    [HideInInspector] public Transform ParentAfterDrag;
    public Belongs belongs;
    private Image _image;
    public ItemGeneral Item { get; private set; }
    private void Awake()
    {
        _image = GetComponent<Image>();
        Item = GetComponent<ItemGeneral>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        _image.raycastTarget = true;
        if (EndDrag != null) EndDrag();
    }
}
