using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController instance;

    [Tooltip("Referencia al texto de la cantidad de monedas obtenidas")]
    [SerializeField] private TextMeshProUGUI coinsText;

    // INTERFAZ HP DEL JUGADOR

    [Tooltip("Referencia a las imágenes de la vida del jugador")]
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    // INTERFAZ GAME OVER
    [SerializeField] private Image backgroundGameOverUI;

    private void Start() {
         
    }

    private void Awake()
    {
        instance = this;
    }

    public static void SetCoinUI()
    {
        instance.coinsText.text = InventoryController.GetMoneda().ToString();
    }

    public static void SetHealthUI(int hp)
    {
        if (hp <= 0)
        {
            instance.heart1.gameObject.SetActive(false);
            instance.heart2.gameObject.SetActive(false);
            instance.heart3.gameObject.SetActive(false);
            instance.Invoke("SetGameOverUI",2);
        }
        switch (hp)
        {
            case 1:
                {
                    instance.heart3.gameObject.SetActive(false);
                    instance.heart2.gameObject.SetActive(false);
                }
                break;

            case 2:
                {
                    instance.heart3.gameObject.SetActive(false);
                }
                break;
        }
    }

    public void SetGameOverUI() {
        instance.backgroundGameOverUI.gameObject.SetActive(true);
    }
}
