using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _entityCountText = null;

    private void Update()
    {
        _entityCountText.text = LevelReference.Instance.statManager.GetEntityCount().ToString();
    }
}
