using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinController : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    
    [SerializeField] private List<GameObject> listSpawnPositions;

    [SerializeField] private int maxCoins;

    private void Start() {
        for(int i = 0; i < maxCoins;i++) {
            int indice = Random.Range(0,listSpawnPositions.Count);
            Instantiate(coin,listSpawnPositions[indice].transform.position,Quaternion.identity);
            listSpawnPositions.RemoveAt(indice);
        }
    }
}
