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

    public void SetPath(Path path)
    {
        _path = path;
    }

    private void OnEnable()
    {
        LevelReference.Instance.entityManager.Register(this);
    }

    private void OnDisable()
    {
        LevelReference.Instance.entityManager.Unregister(this);
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
