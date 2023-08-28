using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class ElementsProgressManager : MonoBehaviour
{
    private GeneralElement _currentElement;
    private float _expirience;
    private float _expProgress;
    private float _value;
    private int _lvl;

    void Update()
    {
        if (_currentElement)
        {
            UpdateProgress();
            if (_currentElement.gameObject.activeInHierarchy)
            {
                _currentElement.UpdateUIView(_value.ToString(), _expirience, _expProgress, _lvl);
            }
        }
    }
    public void DoingJob(GeneralElement element)
    {
        if (_currentElement)
        {
            _currentElement.SetState(_value, _expirience, _expProgress, _lvl);
            _currentElement.SetJob();
        }
        element.SetJob();
        _currentElement = element;
        TakeJobState();
    }
    private void UpdateProgress()
    {
        _expirience += 10 * Time.deltaTime;
        if (_expirience >= _expProgress)
        {
            GetNewLevel();
        }
    }
    private void GetNewLevel()
    {
        _lvl++;
        _expirience = 0;
        _value += _value / 100 * 10;
        _expProgress += _expProgress / 100 * _lvl;
    }
    private void TakeJobState()
    {
        _expirience = _currentElement.Expirience;
        _value = _currentElement.Value;
        _expProgress = _currentElement.ExpProgress;
        _lvl = _currentElement.Lvl;
    }
}
