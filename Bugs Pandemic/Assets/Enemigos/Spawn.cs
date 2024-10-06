using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab; // Prefab a instanciar
    public Transform puntoDeSpawn; // Punto donde se instanciar� el prefab
    public float tiempoEntreSpawns = 5f; // Tiempo entre cada spawn
    private float tiempoTranscurrido; // Contador de tiempo

    private void Update()
    {
        // Incrementar el contador de tiempo
        tiempoTranscurrido += Time.deltaTime;

        // Si ha pasado suficiente tiempo, instanciar el prefab
        if (tiempoTranscurrido >= tiempoEntreSpawns)
        {
            SpawnPrefab(); // Llama a la funci�n para crear el objeto
            tiempoTranscurrido = 0f; // Reiniciar el contador de tiempo
        }
    }

    // Funci�n que instancia el prefab en el punto de spawn
    private void SpawnPrefab()
    {
        Instantiate(prefab, puntoDeSpawn.position, puntoDeSpawn.rotation);
    }
}