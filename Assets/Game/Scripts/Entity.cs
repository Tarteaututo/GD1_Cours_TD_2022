using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Entity : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;

    [SerializeField]
    private Path _path = null;

    private void Awake()
    {
        Transform firstWaypoint = _path.GetWaypoint(0);

        // for
        // Debug.Log
        // GetWaypoint
    }

    private void Update()
    {
        transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
    }



}
