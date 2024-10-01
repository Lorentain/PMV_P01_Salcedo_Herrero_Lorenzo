using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Tooltip("Referencia al Rigidbody2D")]
    [SerializeField] private Rigidbody2D rb;

    // HUD DEL JUGADOR

    [Tooltip("Referencia al texto de la cantidad de monedas obtenidas")]
    [SerializeField] private TextMeshProUGUI coinsText;

    [Tooltip("Referencia a las imágenes de la vida del jugador")]
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    // INTERFAZ GAME OVER
    [SerializeField] private Image backgroundUI;

    [Tooltip("Referencia a la fuerza del salto del jugador")]

    [SerializeField] private float jumpForce;

    [Tooltip("Referencia a la fuerza de caida del salto del jugador")]
    [SerializeField] private float fallForce;

    [Tooltip("Referencia a la velocidad el jugador")]
    [SerializeField] private float speed;

    [Tooltip("Referencia a la vida actual del jugador")]
    [SerializeField] private int playerHP = 3;

    [Tooltip("Referencia al contador de monedas del jugador")]
    private int coinsCounter = 0;

    // INVENTARIO DEL JUGADOR
    [SerializeField] private bool keyLevel2 = false;

    // Start is called before the first frame update
    private void Start()
    {
        coinsText.text = coinsCounter.ToString();
        backgroundUI.gameObject.SetActive(false);

    }

    // Update is called once per frame
    private void Update()
    {

        // MOVIMIENTO BÁSICO DEL JUGADOR
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.down * fallForce);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Reiniciando Nivel");
    }

    // COLISIONES
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Spike")) // Colisión contra pinchos
        {
            Destroy(gameObject);
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
            backgroundUI.gameObject.SetActive(true);
            Debug.Log("MUERTO");
        }

        if (other.collider.CompareTag("Lava")) // Colisión contra lava
        {
            Destroy(gameObject);
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
            backgroundUI.gameObject.SetActive(true);
            Debug.Log("MUERTO");
        }

        if (other.collider.CompareTag("DoorLevel1"))
        { // Colisión contra la puerta hacia nivel 2
            SceneManager.LoadScene("Second Level");
            Debug.Log("Cargando el segundo nivel");
        }

        if(other.collider.CompareTag("DoorLevel2") && keyLevel2) {
            //SceneManager.LoadScene("Third Level");
            Debug.Log("Cargando el tercer nivel");
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
                        backgroundUI.gameObject.SetActive(true);
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

        if (other.CompareTag("Coin")) // Trigger contra monedas
        {
            Destroy(other.gameObject);
            coinsCounter++;
            coinsText.text = coinsCounter.ToString();
            Debug.Log("Monedas obtenidas " + coinsCounter);
        }

        if (other.CompareTag("KeyLevel2"))
        {
            Destroy(other.gameObject);
            keyLevel2 = true;
            Debug.Log("Llave nivel 2 obtenida");
        }
    }
}
