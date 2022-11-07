using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Hold a references to all entities in the scene
public class EntityManager : MonoBehaviour
{
    [SerializeField]
    private List<Entity> _entities = null;

    public int GetEntitiesCount()
    {
        return _entities.Count;
    }

    public void Register(Entity entity)
    {
        _entities.Add(entity);
    }

    public void Unregister(Entity entity)
    {
        _entities.Remove(entity);
    }
}
