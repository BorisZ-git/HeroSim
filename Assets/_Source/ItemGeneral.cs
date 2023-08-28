using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemGeneral : MonoBehaviour
{
    [Header("General values")]
    [SerializeField] protected float _cost;
    [SerializeField] protected ItemType _itemType;
    public float Cost { get => _cost; }
    public ItemType ItemType { get => _itemType; }
}
