using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{

    [SerializeField] private string nextLevel;
    [SerializeField] private bool needKey;

    // COLISIONES
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player")) {
            if(!needKey) {
                PlayerPrefs.SetInt("HP",HealthController.GetHealth());
                PlayerPrefs.SetInt("Coins",InventoryController.GetMoneda());
                SceneManager.LoadScene(nextLevel);
            }else if(InventoryController.GetKey() == true) {
                PlayerPrefs.SetInt("HP",HealthController.GetHealth());
                PlayerPrefs.SetInt("Coins",InventoryController.GetMoneda());
                SceneManager.LoadScene(nextLevel);
            }else {
                Debug.Log("No tienes la llava necesaria");
            }
            
        }
    }
}
