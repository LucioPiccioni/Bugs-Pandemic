using UnityEngine;

public class Boton_Salir : MonoBehaviour
{
    // Método público para salir del juego
    public void ExitGame()
    {
#if UNITY_EDITOR
        // Si estamos en el editor de Unity, mostrar un mensaje en la consola
        Debug.Log("Has salido del nivel (En el editor no se cierra la aplicación).");
#else
            // Si estamos en la build, cerrar la aplicación
            Application.Quit();
#endif
    }
}
