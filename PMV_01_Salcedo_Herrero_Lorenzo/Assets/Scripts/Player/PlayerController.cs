using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Tooltip("Referencia al Rigidbody2D")] 
    [SerializeField] private Rigidbody2D rb;

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

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Coin")) {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
    }
}
