using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    private static HealthController instance;

    [Tooltip("Referencia a la vida actual del jugador")]
    [SerializeField] private int playerHP = 3;
    [SerializeField] private int actualHP;

    private void Start() {
        actualHP = PlayerPrefs.GetInt("HP",playerHP);
        UIController.SetHealthUI(actualHP);
    }

    #region Funciones públicas

    private void Awake() {
        instance = this;
    }

    public static int GetHealth() {
        return instance.actualHP;
    }

    public void TakeDamage(int damage)
    {
        actualHP -= damage;
        UIController.SetHealthUI(actualHP);
        if(actualHP <= 0) {
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
            actualHP--;
        }
    }
    #endregion
}
