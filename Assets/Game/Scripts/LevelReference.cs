using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReference : MonoBehaviour
{
    private static LevelReference _instance = null;
    public static LevelReference Instance
    {
        get
        {
            if (_instance == null)
            {
                LevelReference[] foundInstances = FindObjectsOfType<LevelReference>();

                if (foundInstances.Length == 0)
                {
                    // Error no singleton
                    Debug.LogError("No LevelReference found.");
                }

                if (foundInstances.Length > 1)
                {
                    // too many singleton
                    Debug.LogError("Too many LevelReference found.");
                }

                _instance = foundInstances[0];
            }

            return _instance;
        }
    }

    public EntityDatabase entityDatabase;

    public StatManager statManager = null;

    public EntityManager entityManager = null;

    public UIManager uiManager = null;


}
