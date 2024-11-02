using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoorController : MonoBehaviour
{

    [Tooltip("Referencia a que puerta es del tutorial")]
    [SerializeField] private int door;

    [Tooltip("Referencia a las partes del tutorial")]
    [SerializeField] private GameObject firstPart;
    [SerializeField] private GameObject secondPart;

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
                    }
                    break;
            }
        }
    }
}
