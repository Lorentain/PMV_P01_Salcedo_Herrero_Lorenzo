using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayAgainController : MonoBehaviour
{

    [SerializeField] private string LevelToLoad;
    public void NewGameLevel() {
        SceneManager.LoadScene(LevelToLoad);
    }
}
