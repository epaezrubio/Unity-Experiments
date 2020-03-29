using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGamePlay : MonoBehaviour
{
    [SerializeField]
    PlayerModeChanger playerModeChanger;

    private void OnTriggerEnter(Collider collider)
    {
        PlayerModeScriptable playerMode = playerModeChanger.currentPlayerMode;
        GameObject go = collider.transform.gameObject;

        if (playerMode.matchingTag != go.tag)
        {
            Debug.Log("Game Over :)");
        }
    }
}
