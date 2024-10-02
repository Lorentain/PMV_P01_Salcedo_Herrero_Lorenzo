using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    // INTERFAZ HP DEL JUGADOR

    [Tooltip("Referencia a las imágenes de la vida del jugador")]
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    [Tooltip("Referencia a la vida actual del jugador")]
    [SerializeField] private int playerHP = 3;

    // INTERFAZ GAME OVER
    [SerializeField] private Image backgroundGameOverUI;

    #region Funciones públicas

    public void TakeDamage(int damage)
    {
        playerHP -= damage;
        switch (playerHP)
        {
            case 0:
                {
                    Destroy(gameObject);
                    heart1.gameObject.SetActive(false);
                    backgroundGameOverUI.gameObject.SetActive(true);
                    Debug.Log("MUERTO");
                }
                break;

            case 1:
                {
                    heart2.gameObject.SetActive(false);
                    Debug.Log("1 vida restante");
                }
                break;

            case 2:
                {
                    heart3.gameObject.SetActive(false);
                    Debug.Log("2 vidas restantes");
                }
                break;
        }
    }

    #endregion

    #region Unity Colisión y Trigger
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Spike")) // Colisión contra pinchos
        {
            Destroy(gameObject);
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
            backgroundGameOverUI.gameObject.SetActive(true);
            Debug.Log("MUERTO");
        }

        if (other.collider.CompareTag("Lava")) // Colisión contra lava
        {
            Destroy(gameObject);
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
            backgroundGameOverUI.gameObject.SetActive(true);
            Debug.Log("MUERTO");
        }
    }

    // TRIGGERS
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Trigger contra enemigo
        {
            playerHP--;
            switch (playerHP)
            {
                case 0:
                    {
                        Destroy(gameObject);
                        heart1.gameObject.SetActive(false);
                        backgroundGameOverUI.gameObject.SetActive(true);
                        Debug.Log("MUERTO");
                    }
                    break;

                case 1:
                    {
                        heart2.gameObject.SetActive(false);
                        Debug.Log("1 vida restante");
                    }
                    break;

                case 2:
                    {
                        heart3.gameObject.SetActive(false);
                        Debug.Log("2 vidas restantes");
                    }
                    break;
            }
        }
    }
    #endregion
}
