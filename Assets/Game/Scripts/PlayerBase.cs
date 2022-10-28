using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    private Damageable _damageable = null;

    private void OnEnable()
    {
        _damageable.DamageTaken -= OnDamageTaken;
        _damageable.DamageTaken += OnDamageTaken;
    }

    private void OnDisable()
    {
        _damageable.DamageTaken -= OnDamageTaken;
    }

    private void OnDamageTaken(int damageTaken, int remainingHealth)
    {
        if (remainingHealth <= 0)
        {
            Debug.Log("Lose condition !");
            Debug.Break();
        }
    }
}
