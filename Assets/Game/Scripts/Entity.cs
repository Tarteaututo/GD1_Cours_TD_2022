using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Entity : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;

    [SerializeField]
    private float _nextDestinationThreshold = 1.2f;

    [SerializeField]
    private Path _path = null;

    private int _currentWaypointIndex = 0;

    private void Awake()
    {
        Transform firstWaypoint = _path.GetWaypoint(0);

        // for
        // Debug.Log
        // GetWaypoint

        for (int i = 0; i < _path.GetWaypointCount(); i++)
        {
            Vector3 position = _path.GetWaypoint(i).position;
            Debug.Log(position);
        }
    }

    private void Update()
    {
        Vector3 destination = _path.GetWaypoint(_currentWaypointIndex).position;
        Vector3 direction = destination - transform.position;
        direction = direction.normalized;

        //transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
        transform.position = transform.position + direction * _speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);

        if (Vector3.Distance(transform.position, destination) < _nextDestinationThreshold)
        {
            _currentWaypointIndex = _currentWaypointIndex + 1;
            if (_currentWaypointIndex >= _path.GetWaypointCount())
            {
                _currentWaypointIndex = 0;
            }
        }

    }

}
