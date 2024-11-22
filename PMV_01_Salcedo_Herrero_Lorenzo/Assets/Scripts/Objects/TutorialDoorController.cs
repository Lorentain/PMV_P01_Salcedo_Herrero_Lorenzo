using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoorController : MonoBehaviour
{

    [Tooltip("Referencia a que puerta es del tutorial")]
    [SerializeField] private int door;

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
                        firstPart.SetActive(false);
                        secondPart.SetActive(true);
                        break;
                    }
                case 2:
                    {
                        AudioManager.PlayOpenDoorSound();
                        secondPart.SetActive(false);
                        thirdPart.SetActive(true);
                        break;
                    }
                case 3:
                    {
                        AudioManager.PlayOpenDoorSound();
                        Invoke("EmpezarJuego", 2f);
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
