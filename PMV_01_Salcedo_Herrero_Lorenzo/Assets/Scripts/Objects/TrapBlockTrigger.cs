using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBlockTrigger : MonoBehaviour
{

    [SerializeField] private TrapBlockController trapBlockController;

    [SerializeField] private GameObject key;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Rigidbody2D keyRB = key.GetComponent<Rigidbody2D>();
            keyRB.gravityScale = 1;
            trapBlockController.StartTrigger();
        }
    }

}
