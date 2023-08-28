using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class GeneralElement : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _expProgress;
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private TMP_Text _lvlText;
    [SerializeField] private Slider _slider;
    private bool _doingJob;
    private float _expirience;
    private int _lvl;

    public float Value { get => _value; }
    public float ExpProgress { get => _expProgress; }
    public float Expirience { get => _expirience; }
    public int Lvl { get => _lvl; }

    protected virtual void Awake()
    {
        UpdateUIView(Value.ToString(), Expirience, ExpProgress, Lvl);
    }
    public virtual void UpdateUIView(string value, float expirience, float expProgress, int lvl)
    {
        _slider.value = expirience;
        _valueText.text = value;
        _lvlText.text = $"Lvl.{lvl}";
        _slider.maxValue = expProgress;
    }
    /// <summary>
    /// Change state of element
    /// </summary>
    public void SetJob()
    {
        _doingJob = !_doingJob;
        if (_doingJob)
        {
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
        }
    }
    public void SetState(float value, float expirience, float expProgress, int lvl)
    {
        _value = value;
        _expirience = expirience;
        _expProgress = expProgress;
        _lvl = lvl;
    }
}
