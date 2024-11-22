using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoorController : MonoBehaviour
{

    [Tooltip("Referencia a que puerta es del tutorial")]
    [SerializeField] private int door;

    [Tooltip("Referencia al jugador")]
    [SerializeField] private GameObject player;

    [Tooltip("Referencia a las partes del tutorial")]
    [SerializeField] private GameObject firstPart;

    [SerializeField] private GameObject secondPart;

    [SerializeField] private GameObject thirdPart;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            switch (door)
            {
                case 1:
                    {
                        AudioManager.PlayOpenDoorSound();
                        player.transform.position = new Vector3(8f,-3.5f,0f);
                        firstPart.SetActive(false);
                        secondPart.SetActive(true);
                        break;
                    }
                case 2:
                    {
                        AudioManager.PlayOpenDoorSound();
                        player.transform.position = new Vector3(8f,-3.5f,0f);
                        secondPart.SetActive(false);
                        thirdPart.SetActive(true);
                        break;
                    }
                case 3:
                    {
                        AudioManager.PlayOpenDoorSound();
                        Invoke("EmpezarJuego", 1f);
                        break;
                    }
            }
        }
    }

    private void EmpezarJuego()
    {
        SceneManager.LoadScene("Game");
    }

}
