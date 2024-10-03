using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExitController : MonoBehaviour
{
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
}
