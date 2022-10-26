using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// protected : permet de laisser l'acc�s aux classes d�riv�es, mais pas aux classes ext�rieur

public abstract class AWeapon : MonoBehaviour
{
    [SerializeField]
    protected Projectile _projectilePrefab = null;

    [SerializeField]
    protected Transform _muzzle = null;

    [SerializeField]
    protected Timer _timer = null;

    private void OnEnable()
    {
        _timer.Start();
    }

    private void OnDisable()
    {
        _timer.Stop();
    }

    private void Update()
    {
        bool result = _timer.Update();

        if (result == true)
        {
            Fire();
        }
    }

    // CreateProjectile should return the created instance
    // in order to modified it in derived classes
    protected virtual Projectile CreateProjectile()
    {
        Projectile instance = Instantiate<Projectile>(_projectilePrefab);
        instance.transform.position = _muzzle.position;
        instance.transform.rotation = _muzzle.rotation;
        return instance;
    }

    protected abstract void Fire();
}
