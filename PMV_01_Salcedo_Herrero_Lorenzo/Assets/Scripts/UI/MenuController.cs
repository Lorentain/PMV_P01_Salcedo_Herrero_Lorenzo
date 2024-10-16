using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [Tooltip("")]
    [SerializeField] private GameObject initialWarning; // Canvas aviso al iniciar el juego

    [SerializeField] private string linkSurvey; // Link de la encuesta

    [SerializeField] private string LevelToLoad;

    public void AceptarComienzo()
    {
        initialWarning.gameObject.SetActive(false);
    }

    public void AbrirEncuesta()
    {
        Application.OpenURL(linkSurvey);
    }

    public void ExitGame()
    {
        // Si estás en el editor de Unity, esto parará la ejecución del juego.
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Esto cerrará la aplicación si está ejecutándose fuera del editor.
        Application.Quit();
        #endif
    }

    public void NewGameLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
