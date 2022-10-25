using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Damager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Damageable otherDamageable = other.GetComponentInParent<Damageable>();

        // Si on a trouv� un damageable
        if (otherDamageable != null)
        {
            otherDamageable.TakeDamage(1);
        }
    }
}
