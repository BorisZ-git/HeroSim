using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public abstract class ItemGeneral : MonoBehaviour
{
    [Header("General item values")]
    [SerializeField] protected float _cost;
    protected ItemType _itemType;
    protected virtual void Awake()
    {
        _itemType = SetItemType();
    }

    protected abstract ItemType SetItemType();

    public float Cost { get => _cost; }
    public ItemType ItemType { get => _itemType; }
}
