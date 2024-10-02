using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DoorController : MonoBehaviour
{

    [SerializeField] private string nextLevel;

    // COLISIONES
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player")) {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
