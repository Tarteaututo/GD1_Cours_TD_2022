using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityDescription", menuName = "GameSup/EntityDescription")]
public class EntityDescription : ScriptableObject
{ 
    public enum EntityType
    {
        Light,
        Heavy,
        Speedy
    }

    [SerializeField]
    private EntityType _entityType = EntityType.Light;

    [SerializeField]
    private Entity _entityPrefab = null;

    [SerializeField]
    private Sprite _entityIcon = null;

    public EntityType Type { get => _entityType; }
    public Entity EntityPrefab { get => _entityPrefab; }
    public Sprite EntityIcon { get => _entityIcon; }

    // Equivalent to above
    //public EntityType TypeSecondExample
    //{ 
    //    get
    //    {
    //        return _entityType; 
    //    }
    //    set
    //    {
    //        _entityType = value;
    //    }
    //}




}
