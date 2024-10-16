using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] private bool needKey;
    [SerializeField] private float delayBeforeLoading = 0.1f;

    // COLISIONES
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (!needKey)
            {
                AudioManager.PlayOpenDoorSound();
                PlayerPrefs.SetInt("HP", HealthController.GetHealth());
                PlayerPrefs.SetInt("Coins", InventoryController.GetMoneda());

                // Usar Invoke para hacer el delay en una sola línea
                Invoke("LoadNextLevel", delayBeforeLoading);

                Debug.Log("Abres la puerta");
            }
            else if (InventoryController.GetKey() == true)
            {
                AudioManager.PlayOpenDoorSound();
                PlayerPrefs.SetInt("HP", HealthController.GetHealth());
                PlayerPrefs.SetInt("Coins", InventoryController.GetMoneda());
                
                // Usar Invoke para hacer el delay en una sola línea
                Invoke("LoadNextLevel", delayBeforeLoading);

                Debug.Log("Abres la puerta");
                Debug.Log("Tienes llave y abres la puerta");
            }
            else
            {
                AudioManager.PlayLockDoorSound();
                Debug.Log("No tienes la llave necesaria");
            }
        }
    }

    // Método para cargar el siguiente nivel
    private void LoadNextLevel()
    {
        if(nextLevel == "Second Level") {
            LavaController.StartMoveLava();
            Debug.Log("La lava empieza a moverse");
        }
        
        SceneManager.LoadScene(nextLevel);
    }
}

