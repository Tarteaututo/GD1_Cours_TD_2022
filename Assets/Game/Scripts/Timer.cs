using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Encapsulation
[System.Serializable]
public class Timer
{
    [SerializeField]
    private float _duration = 1;

    private float _currentTime = 0;

    private bool _isStarted = false;

    public void Start()
    {
        _isStarted = true;
        _currentTime = 0;
    }

    public void Stop()
    {
        _isStarted = false;
        _currentTime = 0;
    }

    public void Pause()
    {
        _isStarted = false;
    }

    public void Resume()
    {
        _isStarted = true;
    }

    public bool Update()
    {
        if (_isStarted == true)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _duration)
            {
                _currentTime = 0;
                Debug.Log("Timer returned true");
                return true;
            }
        }
        return false;
    }
}