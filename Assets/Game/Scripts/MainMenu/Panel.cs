using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField]
    private bool _isShownAtStart = false;

    private void Awake()
    {
        if (_isShownAtStart == false)
        {
            gameObject.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
