using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameObject initialWarning;

    public void AceptarComienzo() {
        initialWarning.gameObject.SetActive(false);
    }
}
