using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//[RequireComponent(typeof(SpriteRenderer))]

public class LavaController : MonoBehaviour
{

    [Tooltip("Posición inicial en Y")]
    [SerializeField] private float startYPos;

    [Tooltip("Posición final en Y")]
    [SerializeField] private float endYPos;

    [Tooltip("Delay del comienzo de la lava")]
    [SerializeField] private float delayLava;

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

    [Tooltip("Color de inicio de la sequencia")]
    [SerializeField] private Color startColor;

    [Tooltip("Color final de la sequencia")]
    [SerializeField] private Color endColor;

    [Tooltip("Color tiempo de la sequencia")]
    [SerializeField] private float timeColor;

    private void Awake() {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        transform.DOMoveY(endYPos, movementTimeVertical).SetEase(movementEase).SetDelay(delayLava); // Moverse lentamente en Y
        // Sequencia moverse en X
        Sequence moveSeq = DOTween.Sequence();
        moveSeq.Append(transform.DOMoveX(endXPos,movementTimeHorizontal).SetEase(movementEase));
        //moveSeq.Append(spriteRenderer.DOColor(endColor,timeColor));
        moveSeq.Append(transform.DOMoveX(startXPos,movementTimeHorizontal).SetEase(movementEase));
        //moveSeq.Append(spriteRenderer.DOColor(startColor,timeColor));
        moveSeq.SetLoops(-1);

        // spriteRenderer.DOFade(0,10).OnComplete(() =>
        // {
        //     Destroy(gameObject);
        // });
    }
}
