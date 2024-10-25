using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    private static HealthController instance;

    [Tooltip("Referencia al Animator2D")]
    [SerializeField] private Animator animator;

    [Tooltip("Referencia a la vida del jugador")]
    [SerializeField] private int playerHP = 3;

    [Tooltip("Referencia a la vida actual del jugador")]
    [SerializeField] private int actualHP;

    [Tooltip("Referencia a la camara")]
    [SerializeField] private new Camera camera;

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
        camera.DOShakePosition(0.8f,0.1f,10,70);
        actualHP -= damage;
        UIController.SetHealthUI(actualHP);
        if(actualHP <= 0) {
            animator.SetBool("Dead",true);
            PlayerPrefs.DeleteAll();
        }
    }

    #endregion
}
