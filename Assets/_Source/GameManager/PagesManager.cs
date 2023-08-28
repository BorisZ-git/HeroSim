using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PagesManager : MonoBehaviour
{
    private GameObject _currentPanel;

    public void SetPanel(GameObject panelToActive)
    {
        if (_currentPanel)
        {
            _currentPanel.SetActive(false);
        }
        _currentPanel = panelToActive;
        _currentPanel.SetActive(true);
    }
}
