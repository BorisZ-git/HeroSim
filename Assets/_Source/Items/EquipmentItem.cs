using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : ItemGeneral
{
    [Header("General equipment values")]    
    [SerializeField] [Tooltip("Main item attribute like armor or damage")] private float _value;
    [SerializeField] private int _agility;
    [SerializeField] private int _strength;
    [SerializeField] private ItemRank _itemRank;
    [SerializeField] private EquipmentType _eType;

    protected override ItemType SetItemType()
    {
        return ItemType.Equipment;
    }

    /// <summary>
    /// Main item attribute like armor or damage
    /// </summary>
    public float Value { get => _value; }
    public int Agility { get => _agility; }
    public int Strength { get => _strength; }
    public ItemRank Rank { get => _itemRank; }
    public EquipmentType EquipmentType { get => _eType; }

}
