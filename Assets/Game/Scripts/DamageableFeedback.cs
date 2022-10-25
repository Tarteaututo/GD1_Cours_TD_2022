using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableFeedback : MonoBehaviour
{
    [SerializeField]
    private Damageable _damageable = null;

    private void OnEnable()
    {
        // On s'enlève TOUJOURS d'un event avant de s'y ajouter
        _damageable.DamageTaken -= OnDamageTaken;
        _damageable.DamageTaken += OnDamageTaken;

        _damageable.DamageTakenUnityEvent.RemoveListener(OnDamageTakenWithoutArgs);
        _damageable.DamageTakenUnityEvent.AddListener(OnDamageTakenWithoutArgs);

        _damageable.DamageTakenUnityEventWithArgs.RemoveListener(OnDamageTaken);
        _damageable.DamageTakenUnityEventWithArgs.AddListener(OnDamageTaken);
    }

    private void OnDisable()
    {
        // On s'enlève de l'evenement à ondisable sinon il est possible de lancer l'event et de tomber sur null reference
        _damageable.DamageTaken -= OnDamageTaken;
        _damageable.DamageTakenUnityEvent.RemoveListener(OnDamageTakenWithoutArgs);
        _damageable.DamageTakenUnityEventWithArgs.RemoveListener(OnDamageTaken);
    }

    private void OnDamageTakenWithoutArgs()
    {
        Debug.Log("Damage Taken without args");
    }

    private void OnDamageTaken(int damageTaken, int remainingHealth)
    {
        Debug.Log("Damage Taken");
    }

}
