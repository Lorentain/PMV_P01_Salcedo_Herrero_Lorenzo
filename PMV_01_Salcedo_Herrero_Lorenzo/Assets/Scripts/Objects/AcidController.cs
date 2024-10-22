using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//[RequireComponent(typeof(SpriteRenderer))]

public class AcidController : MonoBehaviour
{

    [Tooltip("Posición inicial en Y")]
    [SerializeField] private float startYPos;

    [Tooltip("Posición final en Y")]
    [SerializeField] private float endYPosDown;

    [Tooltip("Posición inicial en Y")]
    [SerializeField] private float startYPosTop;

    [Tooltip("Delay del comienzo de la lava")]
    [SerializeField] private float delayAcid;

    [Tooltip("Posición inicial en X")]
    [SerializeField] private float startXPos;

    [Tooltip("Posición final en X")]
    [SerializeField] private float endXPos;

    [Tooltip("Tiempo del recorrido")]
    [SerializeField] private float movementTimeVertical;

    [Tooltip("Tiempo del recorrido")]
    [SerializeField] private float movementTimeHorizontal;

    [Tooltip("Forma de la curva")]
    [SerializeField] private Ease movementEase;

    Sequence moveXSeq;
    Sequence moveYSeq;

    private void Awake() {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        ;
        moveXSeq = DOTween.Sequence(); // Secuencia movimiento en Y
        moveXSeq.Append(transform.DOMoveX(endXPos, movementTimeHorizontal).SetEase(movementEase));
        moveXSeq.Append(transform.DOMoveX(startXPos, movementTimeHorizontal).SetEase(movementEase));
        moveXSeq.SetLoops(-1);
        moveXSeq.Pause();
        moveYSeq = DOTween.Sequence();
        moveYSeq.Append(transform.DOMoveY(endYPosDown, movementTimeVertical).SetEase(movementEase).OnComplete(() => {
            moveXSeq.Pause();
            Debug.Log("Hola");
        }));
        moveYSeq.Append(transform.DOMoveY(startYPosTop, movementTimeVertical).SetEase(movementEase).OnComplete(() => {
            moveXSeq.Play();
        }));
        moveYSeq.SetLoops(-1);
        moveYSeq.Pause();
    }

    public void TriggerStart() {
        moveYSeq.Play();
        moveXSeq.Play();
    }
}
