using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField]
    private int _entityCount = 0;

    private void Update()
    {
        _entityCount = LevelReference.Instance.entityManager.GetEntitiesCount();
    }
}
