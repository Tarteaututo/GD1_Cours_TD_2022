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

    public void Start()
    {
    }

    public void Stop()
    {
    }

    public void Pause()
    {
    }

    public void Resume()
    {

    }

    public bool Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _duration)
        {
            _currentTime = 0;
            Debug.Log("Timer returned true");
            return true;
        }

        return false;
    }
}