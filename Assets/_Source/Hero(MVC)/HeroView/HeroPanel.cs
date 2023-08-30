using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HeroPanel : MonoBehaviour
{

    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private TMP_Text _textLvl;
    [SerializeField] private TMP_Text _textRank;
    private void Awake()
    {
        HeroController.UpdateHeroPanel += UpdateUIView;
        UpdateUIView();
    }

    // прикрутить наблюдателя
    public void UpdateUIView()
    {
        _textMoney.text = HeroData.Money.ToString();
        //return;
        //_textLvl.text = HeroData.Lvl.ToString();
        //_textRank.text = HeroData.Rank.ToString();
    }
}

