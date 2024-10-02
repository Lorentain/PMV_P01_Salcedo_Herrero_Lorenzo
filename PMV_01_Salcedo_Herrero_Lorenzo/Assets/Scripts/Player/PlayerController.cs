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

    [Tooltip("Referencia al Animator2D")]
    [SerializeField] private Animator animator;

    [Tooltip("Referencia al SpriteRenderer")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    // HUD DEL JUGADOR

    [Tooltip("Referencia al texto de la cantidad de monedas obtenidas")]
    [SerializeField] private TextMeshProUGUI coinsText;

    // MOVIMIENTO BÁSICO DEL JUGADOR

    [Tooltip("Referencia a la fuerza del salto del jugador")]

    [SerializeField] private float jumpForce;

    [Tooltip("Referencia a la fuerza de caida del salto del jugador")]
    [SerializeField] private float fallForce;

    [Tooltip("Referencia a la velocidad el jugador")]
    [SerializeField] private float speed;

    [Tooltip("Referencia al contador de monedas del jugador")]
    private int coinsCounter = 0;

    // INVENTARIO DEL JUGADOR
    [Header("Inventario del jugador")]
    [SerializeField] private bool keyLevel2 = false;

    // Start is called before the first frame update
    private void Start()
    {
        coinsText.text = coinsCounter.ToString();
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

        animator.SetBool("Walking",rb.velocity.x != 0);
        spriteRenderer.flipX = rb.velocity.x < 0;

    }

    // COLISIONES
    private void OnCollisionEnter2D(Collision2D other)
    {
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
