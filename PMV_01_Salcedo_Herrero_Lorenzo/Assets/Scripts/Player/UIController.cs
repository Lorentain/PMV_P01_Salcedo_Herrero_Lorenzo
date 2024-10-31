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
    [Tooltip("Referencia al sistema de partículas del corazón 1")]
    [SerializeField] private ParticleSystem heart1Particles;
    [Tooltip("Referencia al sistema de partículas del corazón 2")]
    [SerializeField] private ParticleSystem heart2Particles;
    [Tooltip("Referencia al sistema de partículas del corazón 3")]
    [SerializeField] private ParticleSystem heart3Particles;

    // INTERFAZ GAME OVER
    [SerializeField] private Image backgroundGameOverUI;

    // DOTWEEN
    [SerializeField] private Ease movementEase;

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
                    instance.heart3Particles.Play();
                    instance.heart3.gameObject.SetActive(false);
                });
            }

            if (instance.heart2.IsActive())
            {
                instance.heart2.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
                {
                    instance.heart2Particles.Play();
                    instance.heart2.gameObject.SetActive(false);
                });
            }

            instance.heart1.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
            {
                instance.heart1Particles.Play();
                instance.heart1.gameObject.SetActive(false);
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
                            instance.heart3Particles.Play();
                            instance.heart3.gameObject.SetActive(false);
                        });
                    }

                    instance.heart2.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
                    {
                        instance.heart2Particles.Play();
                        instance.heart2.gameObject.SetActive(false);
                    });
                }
                break;

            case 2:
                {
                    instance.heart3.GetComponent<Animator>().enabled = false;
                    instance.heart3.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 1f).SetEase(instance.movementEase).OnComplete(() =>
                    {
                        instance.heart3Particles.Play();
                        instance.heart3.gameObject.SetActive(false);
                    });
                }
                break;
        }
    }

    //     ParticleSystem coinParticles = other.GetComponentInChildren<ParticleSystem>();
    // coinParticles.transform.parent = null;
    // coinParticles.Play();
    // Destroy(coinParticles.gameObject,coinParticles.main.duration + coinParticles.main.startLifetime.constantMax);
    // Destroy(other.gameObject);

    public void SetGameOverUI()
    {
        AudioManager.PlayGameOverSound();
        instance.backgroundGameOverUI.gameObject.SetActive(true);
    }
}
