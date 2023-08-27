using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Переставить баттоны на JobsManager DoingJob, а этот класс удалить
/// </summary>
[DisallowMultipleComponent]
public class JobsPanel : MonoBehaviour
{
    [SerializeField] private JobsManager _mngJob;
    //private JobElement _job;

    public void DoingJob(JobElement job)
    {
        _mngJob?.DoingJob(job);
        //if (_job)
        //{
        //    _job.SetJob();
        //}
        //job.SetJob();
        //_job = job;
    }
}
