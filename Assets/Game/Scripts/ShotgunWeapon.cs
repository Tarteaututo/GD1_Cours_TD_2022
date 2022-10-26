using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : AWeapon
{
    [SerializeField]
    private int _numberOfProjectilePerShot = 3;

    [SerializeField]
    private float _spread = 20;

    protected override void Fire()
    {
        // Quaternion A;
        // Quaternion B;
        // A * B = On ajoute la rotation de B à celle de A
        // B * A = On ajoute la rotation de A à celle de B <= NON COMMUTATIF

        for (int i = 0; i < _numberOfProjectilePerShot; i++)
        {
            Projectile instance = CreateProjectile();
            float appliedSpread = _spread * 0.5f; // equivalent to _spread / 2;
            instance.transform.rotation = 
                instance.transform.rotation *
                Quaternion.Euler
                (
                    Random.Range(-appliedSpread, appliedSpread), 
                    Random.Range(-appliedSpread, appliedSpread), 
                    Random.Range(-appliedSpread, appliedSpread)
                );
        }

    }
}
