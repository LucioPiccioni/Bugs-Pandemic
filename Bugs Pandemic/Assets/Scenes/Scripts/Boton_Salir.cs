using UnityEngine;

public class Boton_Salir : MonoBehaviour
{
    // M�todo p�blico para salir del juego
    public void ExitGame()
    {
#if UNITY_EDITOR
        // Si estamos en el editor de Unity, mostrar un mensaje en la consola
        Debug.Log("Has salido del nivel (En el editor no se cierra la aplicaci�n).");
#else
            // Si estamos en la build, cerrar la aplicaci�n
            Application.Quit();
#endif
    }
}
