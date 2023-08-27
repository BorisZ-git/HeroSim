using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class JobsManager : MonoBehaviour
{
    private JobElement _currentJob;
    private float _expirience;
    private float _expProgress;
    private float _salary;
    private int _lvl;

    void Update()
    {
        if (_currentJob)
        {
            UpdateProgress();
            if (_currentJob.gameObject.activeInHierarchy)
            {
                _currentJob.UpdateUIView(_salary, _expirience, _expProgress, _lvl);
            }
        }
    }
    public void DoingJob(JobElement job)
    {
        if (_currentJob)
        {
            _currentJob.SetState(_salary, _expirience, _expProgress, _lvl);
            _currentJob.SetJob();
        }
        job.SetJob();
        _currentJob = job;
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
        _salary += _salary / 100 * 10;
        _expProgress += _expProgress / 100 * _lvl;
    }
    private void TakeJobState()
    {
        _expirience = _currentJob.Expirience;
        _salary = _currentJob.Salary;
        _expProgress = _currentJob.ExpProgress;
        _lvl = _currentJob.Lvl;
    }
}
