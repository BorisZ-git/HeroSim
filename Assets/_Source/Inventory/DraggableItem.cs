using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform ParentAfterDrag;
    public Belongs belongs;
    private Image _image;
    private void Awake()
    {
        _image = GetComponent<Image>();
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
    }
}
