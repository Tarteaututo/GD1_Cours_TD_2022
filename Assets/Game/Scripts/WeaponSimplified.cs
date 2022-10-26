using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSimplified : MonoBehaviour
{
    [SerializeField]
    private Projectile _projectilePrefab = null;

    [SerializeField]
    private Transform _muzzle = null;

    [SerializeField]
    private float _fireRate = 1;

    private float _lastTime = 0;

    private void Update()
    {
        //if (_lastTime + _fireRate < Time.time)
        //{
        //    _lastTime = Time.time;
        //    CreateProjectile();
        //}

        _lastTime += Time.deltaTime;
        //_lastTime = _lastTime + Time.deltaTime; // equivalent a au dessus
        if (_lastTime > _fireRate)
        {
            _lastTime = 0;
            CreateProjectile();
        }
    }

    private void CreateProjectile()
    {
        Projectile instance = Instantiate<Projectile>(_projectilePrefab);
        instance.transform.position = _muzzle.position;
        instance.transform.rotation = _muzzle.rotation;
    }
}
