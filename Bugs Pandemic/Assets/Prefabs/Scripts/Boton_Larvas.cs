using UnityEngine;
using UnityEngine.UI;

public class Boton_Larvas : MonoBehaviour
{
    // Referencia al prefab que se va a instanciar
    public GameObject soldierPrefab;

    // Posici�n donde se har� el spawn (tomar el objeto vacio como referencia)
    public Transform spawnPoint;

    public Button spawnButton;
    
    void Start()
    {
        spawnButton.onClick.AddListener(SpawnSoldier);
    }

    // M�todo que se ejecutar� al hacer clic en el bot�n
    void SpawnSoldier()
    {
        // Instanciar el prefab en la posici�n deseada con su rotaci�n original
        Instantiate(soldierPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
