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
                AudioManager.PlayOpenDoorSound();
                PlayerPrefs.SetInt("HP",HealthController.GetHealth());
                PlayerPrefs.SetInt("Coins",InventoryController.GetMoneda());
                SceneManager.LoadScene(nextLevel);
                Debug.Log("Abres la puerta");
            }else if(InventoryController.GetKey() == true) {
                PlayerPrefs.SetInt("HP",HealthController.GetHealth());
                PlayerPrefs.SetInt("Coins",InventoryController.GetMoneda());
                SceneManager.LoadScene(nextLevel);
                Debug.Log("Tienes llave y abres la puerta");
            }else {
                AudioManager.PlayLockDoorSound();
                Debug.Log("No tienes la llava necesaria");
            }
            
        }
    }
}
