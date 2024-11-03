using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Tooltip("Referencia al daño que produce")]
    [SerializeField] private int damage;

    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player")) {
            other.gameObject.GetComponent<HealthController>().TakeDamage(damage);
        }
    }
}
