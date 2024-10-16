using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    private static LavaController instance;

    [SerializeField] private GameObject lavaPrefab;
    [SerializeField] private float moveDistance = 0.5f;
    [SerializeField] private float moveInterval = 2f;

    private void Awake() {
        instance = this;
    }

    public static void StartMoveLava() {
        instance.StartCoroutine(instance.MoveLavaCoroutine());
    }

    private IEnumerator MoveLavaCoroutine() {
        while(true) {
            yield return new WaitForSeconds(moveInterval);
            lavaPrefab.transform.position += new Vector3(0,moveDistance,0);
        }
    }
}
