using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _waypoints = null;

    public Transform GetWaypoint(int index)
    {
        return _waypoints[index];
    }

    public int GetWaypointCount()
    {
        return _waypoints.Count;
    }

    private void OnDrawGizmos()
    {
        //Transform firstWaypoint = _waypoints[0];
        //Transform secondWaypoint = _waypoints[1];
        //Gizmos.DrawLine(firstWaypoint.position, secondWaypoint.position);

        // strictement équivalent
        //int i = 0;
        //i = i + 1;
        //i += 1;
        //i++;

        Gizmos.color = Color.blue;

        // Looper tous les waypoints
        // Entre chaque waypoint, tracer une ligne
        for (int i = 0; i < _waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(_waypoints[i].position, _waypoints[i + 1].position);
        }




    }

}
