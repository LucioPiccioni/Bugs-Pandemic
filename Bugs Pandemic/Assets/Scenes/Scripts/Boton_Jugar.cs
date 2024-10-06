using UnityEngine;
using UnityEngine.SceneManagement;  // Importar el m�dulo para cambiar escenas

public class Boton_Jugar : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string levelName;

    // M�todo que se llama cuando el bot�n es presionado
    public void OnClickChangeLevel()
    {
        // Cargar la escena con el nombre especificado
        SceneManager.LoadScene(levelName);
    }
}
