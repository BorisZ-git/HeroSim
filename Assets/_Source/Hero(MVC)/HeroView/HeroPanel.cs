using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HeroPanel : MonoBehaviour
{
    // ������ ������ � view � ����������
    public static HeroPanel HeroViewHeader;
    private void Awake()
    {
        if(HeroViewHeader != null)
        {
            Destroy(this);
        }
        else
        {
            HeroViewHeader = this;
        }
        UpdateUIView();
    }
    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private TMP_Text _textLvl;
    [SerializeField] private TMP_Text _textRank;


    // ���������� �����������
    public void UpdateUIView()
    {
        _textMoney.text = HeroData.Money.ToString();
        //return;
        //_textLvl.text = HeroData.Lvl.ToString();
        //_textRank.text = HeroData.Rank.ToString();
    }
}

