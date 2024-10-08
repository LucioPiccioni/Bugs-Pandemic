using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Boton_Tropas : MonoBehaviour
{
    float timer = 0;

    public float coldoown;

    public int Cost;

    bool active = true;
    // Referencia al prefab que se va a instanciar
    public GameObject prefab;

    private LogiScript logiScript;

    // Posición donde se hará el spawn (tomar el objeto vacio como referencia)
    public Transform spawnPoint;

    public Button spawnButton;
    
    void Start()
    {
        // Obtener la referencia al componente LogiScript en el GameObject que lo contiene
        logiScript = FindObjectOfType<LogiScript>(); // Buscar el componente LogiScript en la escena

        spawnButton.onClick.AddListener(SpawnSoldier);
    }

    private void Update()
    {
        Coldoown();
    }

    // Método que se ejecutará al hacer clic en el botón
    void SpawnSoldier()
    {
        if (logiScript.currency >= Cost && active)
        {
            prefab.tag = "Tropa";
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            logiScript.currency -= Cost; // Restar 10 a la moneda
            logiScript.UpdateCurrencyText(); // Actualizar el texto de la moneda, si tienes un método para ello
            active = false;
        }
    }

    private void Coldoown()
    {
        if(!active)
        {
            if (timer >= coldoown)
            {
                timer = 0;
                active = true;
            }
            else
            {
                timer = timer + 1 * Time.deltaTime;
            }
        }
    }
}
