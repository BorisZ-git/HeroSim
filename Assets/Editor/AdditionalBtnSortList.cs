using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BtnSortSlots))]
public class AdditionalBtnSortList : Editor
{
    private int _index;
    private int _currentIndex = 9999;
    private string _strEquipment;
    private string[] _strTypes;
    private EquipmentType _type;
    private bool _flag;
    private BtnSortSlots temp;
    public override void OnInspectorGUI()
    {
        if (!_flag) Init();
        if(temp.Type != _type)
        {
            _index = 0;
            _type = temp.Type;
            _currentIndex = 9999;
        }
        if (_index != _currentIndex)
        {
            SetType();
            _currentIndex = _index;
        }

        DrawDefaultInspector();
        GUILayout.Label(_strEquipment);
        _index = EditorGUILayout.Popup(_index, _strTypes);
    }
    private void SetType()
    {
        switch (temp.Type)
        {
            case EquipmentType.Armor:
                ArmorType test = (ArmorType)_index;
                _strEquipment = "ArmorType: ";
                setString<ArmorType>();
                temp.SetArmorType(_strTypes[_index]);
                break;
            case EquipmentType.Weapon:
                _strEquipment = "WeaponType: ";
                setString<WeaponType>();
                temp.SetWeaponType(_strTypes[_index]);
                break;
        }
    }
    private void setString<T>( )
    {
        _strTypes = System.Enum.GetNames(typeof(T));
    }
    private void Init()
    {
        temp = (BtnSortSlots)target;
        _type = temp.Type;
        _flag = true;
    }
}
