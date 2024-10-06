using UnityEngine;
using UnityEngine.UI;

public class Boton_Larvas : MonoBehaviour
{
    // Referencia al prefab que se va a instanciar
    public GameObject soldierPrefab;

    private LogiScript logiScript; // Cambiado a privado para seguir buenas pr�cticas

    // Posici�n donde se har� el spawn (tomar el objeto vac�o como referencia)
    public Transform spawnPoint;

    public Button spawnButton;

    void Start()
    {
        // Obtener la referencia al componente LogiScript en el GameObject que lo contiene
        logiScript = FindObjectOfType<LogiScript>(); // Buscar el componente LogiScript en la escena

        // Aseg�rate de que logiScript est� asignado
        if (logiScript == null)
        {
            Debug.LogError("LogiScript no encontrado en la escena.");
        }

        // Asignar el listener al bot�n
        spawnButton.onClick.AddListener(SpawnSoldier);
    }

    // M�todo que se ejecutar� al hacer clic en el bot�n
    void SpawnSoldier()
    {
        if (logiScript != null && logiScript.currency >= 10) // Aseg�rate de que hay suficiente moneda
        {
            Instantiate(soldierPrefab, spawnPoint.position, spawnPoint.rotation);
            logiScript.currency -= 10; // Restar 10 a la moneda
            logiScript.UpdateCurrencyText(); // Actualizar el texto de la moneda, si tienes un m�todo para ello
        }
        else
        {
            Debug.LogWarning("No hay suficiente moneda para crear un soldado.");
        }
    }
}
