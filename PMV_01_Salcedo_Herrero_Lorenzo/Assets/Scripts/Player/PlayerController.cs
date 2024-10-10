using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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

    [Tooltip("Referencia al Raycast izquierdo del jugador")]
    [SerializeField] private Transform groundedRaycastLeftOrigin;

    [Tooltip("Referencia al Raycast derecho del jugador")]
    [SerializeField] private Transform groundedRaycastRightOrigin;

    [Tooltip("Referencia al sistema de partículas")]
    [SerializeField] private ParticleSystem particles;

    // HUD DEL JUGADOR

    // MOVIMIENTO BÁSICO DEL JUGADOR

    [Tooltip("Referencia a la fuerza del salto del jugador")]

    [SerializeField] private float jumpForce;

    [Tooltip("Referencia a la fuerza de caida del salto del jugador")]
    [SerializeField] private float fallForce;

    [Tooltip("Referencia a la velocidad el jugador")]
    [SerializeField] private float speed;

    [Tooltip("Referencia a la velocidadX máxima del jugador")]
    [SerializeField] private float maxVelocityX;

    [Tooltip("Referencia a la velocidadY máxima del jugador")]
    [SerializeField] private float maxVelocityY;

    [Tooltip("Referencia del tamaño del Raycast")]
    [SerializeField] private float sizeRaycast;

    [Tooltip("Referencia al máximo del coyote time")]
    [SerializeField] private float maxCoyoteTime = 0.003f;

    [Tooltip("Referencia al tiempo en el aire del jugador")]
    private float timeInAir;

    [Tooltip("Referencia a si el jugador esta saltando")]
    private bool isJumping = false;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // MOVIMIENTO BÁSICO DEL JUGADOR

        // Compruebo si se mueve a la derecha el jugador
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
            particles.Play();
        }

        // Compruebo si se mueve a la izquierda el jugador
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed);
            particles.Play();
        }

        // Compruebo si está tocando el suelo y si salta el jugador
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }

        if(Input.GetKey(KeyCode.P) && CanJump()) {
            Debug.DrawLine(groundedRaycastLeftOrigin.position, groundedRaycastLeftOrigin.position + Vector3.down*sizeRaycast, Color.magenta, 100);
            Debug.DrawLine(groundedRaycastRightOrigin.position, groundedRaycastRightOrigin.position + Vector3.down*sizeRaycast, Color.yellow, 100);
            EditorApplication.isPaused = true;
        }

        // Comprueba si esta cayendo, para agregar una fuerza de caida al jugador
        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.down * fallForce);
        }

        // Se limita la velocidad máxima x,y
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxVelocityX, maxVelocityX), Mathf.Clamp(rb.velocity.y, -maxVelocityY, maxVelocityY));

        // Animación de movimiento en x del jugador
        animator.SetBool("Walking", rb.velocity.x != 0);
        spriteRenderer.flipX = rb.velocity.x < 0;

        // Comprobación tiempo del Coyote
        if (!IsGrounded())
        {
            timeInAir += Time.deltaTime;
        }
        else
        {
            timeInAir = 0;
        }

        if (rb.velocity.y < 0 && IsGrounded())
        {
            isJumping = false;
        }


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

    private bool IsGrounded()
    {

        bool res = false;

        RaycastHit2D hit = Physics2D.Raycast(groundedRaycastLeftOrigin.position, Vector2.down, sizeRaycast);
        if (hit.collider != null)
        {
            res = true;
            Debug.Log(hit.collider.name);
        }

        if (!res)
        {
            hit = Physics2D.Raycast(groundedRaycastRightOrigin.position, Vector2.down, sizeRaycast);
            if (hit.collider != null)
            {
                res = true;
                Debug.Log(hit.collider.name);
            }
        }

        return res;
    }

    private bool CanJump()
    {

        bool res = false;

        if (!isJumping)
        {
            if (IsGrounded())
            {
                res = true;
            }
            else
            {
                if (rb.velocity.y < 0 && timeInAir <= maxCoyoteTime)
                {
                    res = true;
                }
            }
        }else {
            res = false;
        }

        return res;
    }
}
