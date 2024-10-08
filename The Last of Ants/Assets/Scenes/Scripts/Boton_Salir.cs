using UnityEngine;

public class Boton_Salir : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR

        Debug.Log("Has salido del nivel (En el editor no se cierra la aplicación).");
#else
            // Si estamos en la build, cerrar la aplicación
            Application.Quit();
#endif
    }
}
