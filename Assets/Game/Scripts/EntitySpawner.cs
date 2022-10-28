using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    private EntityDescription.EntityType _entityType;
    
    [SerializeField]
    private Path _path;

    void Start()
    {
        InvokeRepeating("SpawnEntity", 0, 2f);
        
        //LevelReference.Instance.toto;
    }

    void SpawnEntity()
    {
        Debug.Log("SpawnEntity");

        EntityDescription entityDescription = LevelReference.Instance.entityDatabase.GetEntityByType(_entityType);
        Entity entityInstance = Instantiate(entityDescription.EntityPrefab);
        entityInstance.SetPath(_path);
    }
}
