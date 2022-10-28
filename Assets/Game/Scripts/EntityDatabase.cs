using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDatabase : MonoBehaviour
{
    // List of EntityDescription + public function to accede it

    [SerializeField]
    private EntityDescription _entityLight = null;
    
    [SerializeField]
    private EntityDescription _entityHeavy = null;
    
    [SerializeField]
    private EntityDescription _entitySpeedy = null;

    public EntityDescription GetEntityByType(EntityDescription.EntityType entityType)
    {
        switch (entityType)
        {
            case EntityDescription.EntityType.Light: return _entityLight;
            case EntityDescription.EntityType.Heavy: return _entityHeavy;
            case EntityDescription.EntityType.Speedy: return _entitySpeedy;
            default: return null;
        }
    }
}
