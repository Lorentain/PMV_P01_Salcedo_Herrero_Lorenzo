using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

    // REFERENCIAS A LOS SISTEMAS DE PARTÍCULAS DE CADA CORAZON
    [Tooltip("Referencia al sistema de partículas del corazones")]
    [SerializeField] private ParticleSystem heartsParticles;

    // REFERENCIAS A LOS RENDER TEXTURE
    [SerializeField] private GameObject heart1RenderTexture;
    [SerializeField] private GameObject heart2RenderTexture;
    [SerializeField] private GameObject heart3RenderTexture;

     // DOTWEEN
     [Tooltip("Referencia a la cuerva de la animación del DOSCale de los corazones")]
    [SerializeField] private Ease movementEase;

    // INTERFAZ GAME OVER
    [SerializeField] private Image backgroundGameOverUI;

    // BOOL AUXILIAR
    private static bool dead;

    private void Start()
    {
        dead = false;
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
        if (hp <= 0 && dead == false)
        {
            instance.heart3.GetComponent<Animator>().enabled = false;
            instance.heart2.GetComponent<Animator>().enabled = false;
            instance.heart1.GetComponent<Animator>().enabled = false;

            if (instance.heart3.IsActive())
            {
                instance.heart3.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
                {
                    instance.heart3RenderTexture.SetActive(true);
                    instance.heartsParticles.Play();
                    instance.heart3.enabled = false;
                });
            }else {
                instance.heart3RenderTexture.SetActive(false);
            }

            if (instance.heart2.IsActive())
            {
                instance.heart2.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
                {
                    instance.heart2RenderTexture.SetActive(true);
                    instance.heartsParticles.Play();
                    instance.heart2.enabled = false;
                });
            }else {
                instance.heart2RenderTexture.SetActive(false);
            }

            instance.heart1.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
            {
                instance.heart1RenderTexture.SetActive(true);
                instance.heartsParticles.Play();
                instance.heart1.enabled = false;
            });

            instance.Invoke("SetGameOverUI", 2);
            AudioManager.StopMusicAmbient();
            dead = true;
        }
        switch (hp)
        {
            case 1:
                {
                    instance.heart3.GetComponent<Animator>().enabled = false;
                    instance.heart2.GetComponent<Animator>().enabled = false;

                    if (instance.heart3.IsActive())
                    {
                        instance.heart3.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
                        {
                            instance.heart3RenderTexture.SetActive(true);
                            instance.heartsParticles.Play();
                            instance.heart3.enabled = false;
                        });
                    }else {
                        instance.heart3RenderTexture.SetActive(false);
                    }

                    instance.heart2.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
                    {
                        instance.heart2RenderTexture.SetActive(true);
                        instance.heartsParticles.Play();
                        instance.heart2.enabled = false;
                    });
                }
                break;

            case 2:
                {
                    instance.heart3.GetComponent<Animator>().enabled = false;
                    instance.heart3.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
                    {
                        instance.heart3RenderTexture.SetActive(true);
                        instance.heartsParticles.Play();
                        instance.heart3.enabled = false;
                    });
                }
                break;
        }
    }

    public void SetGameOverUI()
    {
        AudioManager.PlayGameOverSound();
        instance.backgroundGameOverUI.gameObject.SetActive(true);
    }
}
