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
    [SerializeField] private float endYPosTop;

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

    private void Awake() {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        transform.DOMoveY(endYPosDown, movementTimeVertical).SetEase(movementEase);
        Sequence moveXSEQ = DOTween.Sequence(); // Secuencia movimiento en Y
        moveXSEQ.Append(transform.DOMoveX(endXPos, movementTimeHorizontal).SetEase(movementEase));
        moveXSEQ.Append(transform.DOMoveX(startXPos, movementTimeHorizontal).SetEase(movementEase));
        moveXSEQ.SetLoops(5);
        transform.DOMoveY(endYPosTop, movementTimeVertical).SetEase(movementEase).SetDelay(10);
    }
}
