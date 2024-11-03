using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyController : MonoBehaviour
{

    private static HealthEnemyController instance;

    [Tooltip("Referencia al Animator2D")]
    [SerializeField] private Animator animator;

    [Tooltip("Referencia a la vida del enemigo")]
    [SerializeField] private int enemyHP = 1;

    [Tooltip("Referencia a si está muerto")]
    private bool isDead;

    [Tooltip("Referencia al sistemas de partículas de la muerte")]
    [SerializeField] private ParticleSystem particleSystemDead;

    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isDead = false;
    }

    void Update()
    {
        if (enemyHP <= 0 && !isDead)
        {
            isDead = true;
            particleSystemDead.Play();
            animator.SetBool("Dead",true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            enemyHP--;
            Debug.Log("Daño recibido del jugador");
        }
    }

    public static bool GetIsDead()
    {
        return instance.isDead;
    }
}
