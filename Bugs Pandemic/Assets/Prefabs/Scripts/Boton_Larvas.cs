using UnityEngine;
using UnityEngine.UI;

public class Boton_Larvas : MonoBehaviour
{
    // Referencia al prefab que se va a instanciar
    public GameObject soldierPrefab;

    // Posición donde se hará el spawn (tomar el objeto vacio como referencia)
    public Transform spawnPoint;

    public Button spawnButton;
    
    void Start()
    {
        spawnButton.onClick.AddListener(SpawnSoldier);
    }

    // Método que se ejecutará al hacer clic en el botón
    void SpawnSoldier()
    {
        // Instanciar el prefab en la posición deseada con su rotación original
        Instantiate(soldierPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
