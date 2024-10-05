using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private static InventoryController instance;

    private int coinsCounter;

    [SerializeField]private bool key;

    private void Start() {
        coinsCounter = PlayerPrefs.GetInt("Coins");
        UIController.SetCoinUI();
        key = false;
    }

    private void Awake() {
        instance = this;
    }

    public static void AddMoneda() {
        instance.coinsCounter++;
        UIController.SetCoinUI();
    }

    public static int GetMoneda() {
        return instance.coinsCounter;
    }

    public static void AddKey() {
        instance.key = true;
    }

    public static bool GetKey() {
        return instance.key;
    }

}
