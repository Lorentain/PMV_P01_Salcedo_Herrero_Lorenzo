using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameObject initialWarning; // Canvas aviso al iniciar el juego

    [SerializeField] private string linkSurvey; // Link de la encuesta

    [SerializeField] private string LevelToLoad;

    public void AceptarComienzo()
    {
        AudioManager.PlayButtonClickSound();
        initialWarning.gameObject.SetActive(false);
    }

    public void AbrirEncuesta()
    {
        AudioManager.PlayButtonClickSound();
        Application.OpenURL(linkSurvey);
    }

    public void ExitGame()
    {
        // Si estás en el editor de Unity, esto parará la ejecución del juego.
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Esto cerrará la aplicación si está ejecutándose fuera del editor.
        AudioManager.PlayButtonClickSound();
        Application.Quit();
        #endif
    }

    public void NewGameLevel()
    {
        AudioManager.PlayButtonClickSound();
        Invoke("NewGameLevelInvoke",1f);
    }

    public void NewGameLevelInvoke() {
        SceneManager.LoadScene(LevelToLoad);
    }
}
