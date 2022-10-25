using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Damageable : MonoBehaviour
{
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
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
