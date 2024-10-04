using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    private static HealthController instance;

    [Tooltip("Referencia a la vida actual del jugador")]
    [SerializeField] private int playerHP = 3;

    #region Funciones públicas

    private void Awake() {
        instance = this;
    }

    public static int GetHealth() {
        return instance.playerHP;
    }

    public void TakeDamage(int damage)
    {
        playerHP -= damage;
        UIController.SetHealthUI(playerHP);
        if(playerHP <= 0) {
            Destroy(gameObject);
            PlayerPrefs.DeleteAll();
        }
    }

    #endregion

    #region Unity Colisión y Trigger
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Spike") || other.collider.CompareTag("Lava")) // Colisión contra pinchos
        {
            Destroy(gameObject);
            PlayerPrefs.DeleteAll();
        }
    }

    // TRIGGERS
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Trigger contra enemigo
        {
            playerHP--;
        }
    }
    #endregion
}
