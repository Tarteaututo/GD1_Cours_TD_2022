using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrientToTarget : MonoBehaviour
{
    public enum Mode
    {
        Horizontal,
        Vertical,
        Free
    }

    [SerializeField]
    private Mode _mode = Mode.Horizontal;

    [SerializeField] // serializefield parce que c'est utile pour debugguer
    private Transform _target = null;

    // Getter / Setter
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = _target.position - transform.position;

            if (_mode == Mode.Horizontal)
            {
                direction.y = 0;
                transform.localRotation = Quaternion.LookRotation(direction, Vector3.up);
            }
            else if (_mode == Mode.Vertical)
            {
                direction.x = 0;
                transform.localRotation = Quaternion.LookRotation(direction, Vector3.right);
            }
            else if (_mode == Mode.Free)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

        }
    }
}
