using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : AWeapon
{
    protected override void Fire()
    {
        CreateProjectile();
    }
}
