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

    // MOVIMIENTO BÁSICO DEL JUGADOR

    [Tooltip("Referencia a la fuerza del salto del jugador")]

    [SerializeField] private float jumpForce;

    [Tooltip("Referencia a la fuerza de caida del salto del jugador")]
    [SerializeField] private float fallForce;

    [Tooltip("Referencia a la velocidad el jugador")]
    [SerializeField] private float speed;

    // Start is called before the first frame update
    private void Start()
    {

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

    }

    // TRIGGERS
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin")) // Trigger contra monedas
        {
            AudioManager.PlayCoinPickUpSound();
            Destroy(other.gameObject);
            InventoryController.AddMoneda();
        }

        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            InventoryController.AddKey();
        }
    }
}
