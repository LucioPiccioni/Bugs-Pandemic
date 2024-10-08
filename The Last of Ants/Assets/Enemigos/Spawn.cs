using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab1; // Primer prefab a instanciar
    public GameObject prefab2; // Segundo prefab a instanciar
    public Transform puntoDeSpawn; // Punto donde se instanciarán los prefabs
    public float tiempoEntreSpawns = 5f; // Tiempo entre cada spawn
    private float tiempoTranscurrido; // Contador de tiempo

    private void Update()
    {
        // Incrementar el contador de tiempo
        tiempoTranscurrido += Time.deltaTime;

        // Si ha pasado suficiente tiempo, instanciar un prefab
        if (tiempoTranscurrido >= tiempoEntreSpawns)
        {
            SpawnPrefab(); // Llama a la función para crear el objeto
            tiempoTranscurrido = 0f; // Reiniciar el contador de tiempo
        }
    }

    // Función que elige uno de los dos prefabs con un 50% de probabilidad y lo instancia
    private void SpawnPrefab()
    {
        GameObject prefabAInstanciar;

        // Generar un número aleatorio entre 0 y 1
        int randomValue = Random.Range(0, 2); // Esto devolverá 0 o 1

        // Si el valor es 0, instanciar el primer prefab; si es 1, el segundo
        if (randomValue == 0)
        {
            prefabAInstanciar = prefab1;
        }
        else
        {
            prefabAInstanciar = prefab2;
        }

        // Instanciar el prefab seleccionado
        Instantiate(prefabAInstanciar, puntoDeSpawn.position, puntoDeSpawn.rotation);
    }
}
