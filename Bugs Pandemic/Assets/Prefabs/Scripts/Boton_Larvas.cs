using UnityEngine;
using UnityEngine.UI;

public class Boton_Larvas : MonoBehaviour
{
    // Referencia al prefab que se va a instanciar
    public GameObject soldierPrefab;

    private LogiScript logiScript; // Cambiado a privado para seguir buenas prácticas

    // Posición donde se hará el spawn (tomar el objeto vacío como referencia)
    public Transform spawnPoint;

    public Button spawnButton;

    void Start()
    {
        // Obtener la referencia al componente LogiScript en el GameObject que lo contiene
        logiScript = FindObjectOfType<LogiScript>(); // Buscar el componente LogiScript en la escena

        // Asegúrate de que logiScript está asignado
        if (logiScript == null)
        {
            Debug.LogError("LogiScript no encontrado en la escena.");
        }

        // Asignar el listener al botón
        spawnButton.onClick.AddListener(SpawnSoldier);
    }

    // Método que se ejecutará al hacer clic en el botón
    void SpawnSoldier()
    {
        if (logiScript != null && logiScript.currency >= 10) // Asegúrate de que hay suficiente moneda
        {
            Instantiate(soldierPrefab, spawnPoint.position, spawnPoint.rotation);
            logiScript.currency -= 10; // Restar 10 a la moneda
            logiScript.UpdateCurrencyText(); // Actualizar el texto de la moneda, si tienes un método para ello
        }
        else
        {
            Debug.LogWarning("No hay suficiente moneda para crear un soldado.");
        }
    }
}
