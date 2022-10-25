using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[SelectionBase]
public class Damageable : MonoBehaviour
{
    // Exemple event standard (pure C#)
    public delegate void DamageableEvent(int damageTaken, int remainingHealth);
    public event DamageableEvent DamageTaken;

    // Exemple event Unity (affichable dans l'inspector)
    public UnityEvent DamageTakenUnityEvent;
    // int damageTaken, int remainingHealth
    public UnityEvent<int, int> DamageTakenUnityEventWithArgs;

    [SerializeField]
    private int _health = 1;

    [SerializeField]
    private int _maxHealth = 1;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health = _health - damage;

        if (DamageTaken != null)
        {
            DamageTaken.Invoke(damage, _health);
        }
        //DamageTaken?.Invoke(damage, _health); // null coalescent
        DamageTakenUnityEvent.Invoke();
        DamageTakenUnityEventWithArgs.Invoke(damage, _health);

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
