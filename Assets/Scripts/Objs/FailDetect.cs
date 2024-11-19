using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailDetect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Debug.Log("Thua");
            UIManager.uiManager.SetFailPanelState(true);
        }
    }
}
