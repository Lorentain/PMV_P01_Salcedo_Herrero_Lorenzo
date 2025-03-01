using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Tooltip("Referencia al animator")]
    [SerializeField] private Animator animator;

    [Tooltip("Referencia al daño que produce")]
    [SerializeField] private int damage;

    [SerializeField] private bool inmortal = false;

    [SerializeField] private ParticleSystem particleSystemDead;

    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player")) {
            if(other.GetContact(0).normal.y < 0 && gameObject.CompareTag("Enemy") && !inmortal) {
                particleSystemDead.Play();
                animator.SetBool("Dead", true);
                Destroy(gameObject,2f);
            }else {
                other.gameObject.GetComponent<HealthController>().TakeDamage(damage);
            }
        }
    }
}
