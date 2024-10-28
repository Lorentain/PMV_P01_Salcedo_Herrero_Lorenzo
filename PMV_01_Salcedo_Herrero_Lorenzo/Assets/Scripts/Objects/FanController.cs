using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FanController : MonoBehaviour
{

    [Tooltip("Referencia al comienzo de la posición X")]
    [SerializeField] private float startXPos;

    [Tooltip("Referencia al final de la posición X")]
    [SerializeField] private float endXPos;

    [Tooltip("Referencia al tiempo del recorrido")]
    [SerializeField] private float movementTime;

    [Tooltip("Referencia al Ease (Curva)")]
    [SerializeField] private Ease easeMovement;

    [SerializeField] private ParticleSystem particleSystemLeft;

    [SerializeField] private ParticleSystem particleSystemRight;

    void Start()
    {

        Sequence moveSeq = DOTween.Sequence();
        particleSystemLeft.Play();
        moveSeq.Append(transform.DOMoveX(endXPos,movementTime).SetEase(easeMovement).OnComplete(() => {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
            particleSystemLeft.Stop();
            particleSystemRight.Play();
        }));
        moveSeq.Append(transform.DOMoveX(startXPos,movementTime).SetEase(easeMovement).OnComplete(() => {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = false;
            particleSystemRight.Stop();
            particleSystemLeft.Play();
        }));
        moveSeq.SetLoops(-1);
    }
}
