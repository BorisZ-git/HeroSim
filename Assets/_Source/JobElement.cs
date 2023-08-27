using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DisallowMultipleComponent]
public class JobElement : MonoBehaviour
{
    [SerializeField] private float _salary;
    [SerializeField] private float _expProgress;
    [SerializeField] private TMP_Text _salaryText;
    [SerializeField] private TMP_Text _lvlText;
    [SerializeField] private Slider _slider;
    private bool _doingJob;
    private float _expirience;
    private int _lvl;

    public float Salary { get => _salary; }
    public float ExpProgress { get => _expProgress; }
    public float Expirience { get => _expirience; }
    public int Lvl { get => _lvl; }

    private void Awake()
    {
        UpdateUIView(Salary, Expirience, ExpProgress, Lvl);
    }
    public void UpdateUIView(float salary,float expirience, float expProgress, int lvl)
    {
        _slider.value = expirience;
        _salaryText.text = $"{salary} / day";
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
    public void SetState(float salary, float expirience, float expProgress, int lvl)
    {
        _salary = salary;
        _expirience = expirience;
        _expProgress = expProgress;
        _lvl = lvl;
    }
}
