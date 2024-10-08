using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton_Volver : MonoBehaviour
{
    public string levelName;

    public void OnClickChangeLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
