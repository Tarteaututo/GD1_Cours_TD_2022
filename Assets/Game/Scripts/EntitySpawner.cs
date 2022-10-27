using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    private Entity _entityPrefab;
    
    [SerializeField]
    private Path _path;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEntity", 0, 2f); 
    }

    void SpawnEntity()
    {
        Debug.Log("SpawnEntity");
        Entity entityInstance = Instantiate(_entityPrefab);
        entityInstance.SetPath(_path);
    }
}
