using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFeedback : MonoBehaviour
{
    [SerializeField]
    private Damageable _damageable = null;

    [SerializeField]
    private ParticleSystem _particleDamageTaken;

    [SerializeField]
    private ParticleSystem _particleDeath;

    private void OnEnable()
    {
        _damageable.DamageTakenUnityEventWithArgs.RemoveListener(OnDamageTaken);
        _damageable.DamageTakenUnityEventWithArgs.AddListener(OnDamageTaken);
    }

    private void OnDisable()
    {
        _damageable.DamageTakenUnityEventWithArgs.RemoveListener(OnDamageTaken);
    }

    private void OnDamageTaken(int damageTaken, int remainingHealth)
    {
        if (remainingHealth > 0)
        {
            ParticleSystem instance = Instantiate(_particleDamageTaken);
            instance.transform.position = transform.position;
        }
        else
        {
            ParticleSystem instance = Instantiate(_particleDeath);
            instance.transform.position = transform.position;
        }

        Debug.Log("Damage Taken");
    }
}
