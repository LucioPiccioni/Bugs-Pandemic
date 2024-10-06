using UnityEngine;
using UnityEngine.SceneManagement;  // Importar el módulo para cambiar escenas

public class Boton_Jugar : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string levelName;

    // Método que se llama cuando el botón es presionado
    public void OnClickChangeLevel()
    {
        // Cargar la escena con el nombre especificado
        SceneManager.LoadScene(levelName);
    }
}
