using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] // juste read only, pas obligé
    private List<Damageable> damageables;

    private void OnTriggerEnter(Collider other)
    {
        Damageable otherDamageable = other.GetComponentInParent<Damageable>();

        // Si on a trouvé un damageable
        if (otherDamageable != null)
        {
            if (damageables.Contains(otherDamageable) == false)
            {
                damageables.Add(otherDamageable);
                Debug.Log("Enter damageable " + otherDamageable.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Damageable otherDamageable = other.GetComponentInParent<Damageable>();

        // Si on a trouvé un damageable
        if (otherDamageable != null)
        {
            damageables.Remove(otherDamageable);
            Debug.Log("Exit damageable " + otherDamageable.name);
        }
    }
}
