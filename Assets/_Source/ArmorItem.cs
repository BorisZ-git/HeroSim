using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : ItemGeneral
{
    // переписать поля как общие
    [Header("Private values")]
    [SerializeField] private float _armor;
    [SerializeField] private int _agility;
    [SerializeField] private int _strength;
    [SerializeField] private ItemRank _itemRank;
    public float Armor { get => _armor; }
    public int Agility { get => _agility; }
    public int Strength { get => _strength; }
    public ItemRank Rank { get => _itemRank; }
}