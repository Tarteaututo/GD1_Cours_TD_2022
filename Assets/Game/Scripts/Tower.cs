using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tower is a Facade.
/// </summary>
public class Tower : MonoBehaviour
{
    public enum Mode
    {
        FirstInTheList,
        Nearest,
        LowestHealth
    }

    [SerializeField]
    private Mode _mode = Mode.Nearest;

    [SerializeField]
    private OrientToTarget _orientToTarget = null;

    // variable cache
    [SerializeField] // juste read only, pas obligé
    private List<Damageable> damageables;

    private void Update()
    {
        RemoveNullDamageable();
        // Equivalent to TryGetTarget
        //Damageable testTarget = GetTarget();
        //if (testTarget != null)
        //{
        //    // Set target to Orient target
        //}

        if (TryGetTarget(out Damageable target) == true)
        {
            // Set target to Orient target
            _orientToTarget.SetTarget(target.transform);
        }

    }

    private void RemoveNullDamageable()
    {
        for (int i = damageables.Count - 1; i >= 0; i--)
        {
            if (damageables[i] == null)
            {
                damageables.RemoveAt(i);
            }
        }
    }

    private Damageable GetTarget()
    {
        if (damageables.Count > 0)
        {
            return damageables[0];
        }
        return null;
    }

    // Equivalent to GetTarget 
    private bool TryGetTarget(out Damageable target)
    {
        switch (_mode)
        {
            case Mode.FirstInTheList:
                {
                    if (damageables.Count > 0)
                    {
                        target = damageables[0];
                        return target != null;
                    }
                }
                break;
            case Mode.Nearest:
                {
                    if (damageables.Count > 0)
                    {
                        Damageable chosenTarget = null;
                        float closestDistance = float.MaxValue;
                        for (int i = 0; i < damageables.Count; i++)
                        {
                            float distance = Vector3.Distance(damageables[i].transform.position, transform.position);
                            if (distance < closestDistance)
                            {
                                closestDistance = distance;
                                chosenTarget = damageables[i];
                            }
                        }
                        target = chosenTarget;
                        return target != null;
                    }
                }
                break;
            case Mode.LowestHealth:
                {
                    if (damageables.Count > 0)
                    {
                        Damageable chosenTarget = null;
                        int lowestHealth = int.MaxValue;
                        for (int i = 0; i < damageables.Count; i++)
                        {
                            Damageable instance = damageables[i];
                            int instanceHealth = instance.GetHealth();

                            if (instanceHealth < lowestHealth)
                            {
                                lowestHealth = instanceHealth;
                                chosenTarget = instance;
                            }
                        }
                        target = chosenTarget;
                        return target != null;
                    }
                }
                break;
            default:
                break;
        }


        target = null;
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Damageable otherDamageable = other.GetComponentInParent<Damageable>();

        // Si on a trouvé un damageable
        if (otherDamageable != null)
        {
            if (damageables.Contains(otherDamageable) == false)
            {
                damageables.Add(otherDamageable);
                Debug.Log("Enter damageable " + otherDamageable.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Damageable otherDamageable = other.GetComponentInParent<Damageable>();

        // Si on a trouvé un damageable
        if (otherDamageable != null)
        {
            damageables.Remove(otherDamageable);
            Debug.Log("Exit damageable " + otherDamageable.name);
        }
    }
}
