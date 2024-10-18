using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidTrigger : MonoBehaviour
{

    [SerializeField] private AcidController acidController;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            acidController.TriggerStart();
        }
    }
}
