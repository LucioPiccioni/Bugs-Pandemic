using System.Collections;
using UnityEngine;

public class Movimiento_Enemigo : MonoBehaviour
{
    public float speed = 2.0f;
    public int vida = 3; // Vida inicial
    public int ataque = 1; // Da�o de ataque
    //public int puntosPorMuerte = 5; // Puntos por matar a este enemigo
    private bool isStopped = false; // Estado de detenci�n

    // Referencia al gestor de puntos
    public LogiScript gestorDePuntos;

    private void Update()
    {
        if (!isStopped)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tropa"))
        {
            isStopped = true; // Detener el enemigo
            StartCoroutine(Atacar(collision.GetComponent<Movimiento_Soldado>()));
        }
        else if(collision.CompareTag("Enemigo"))
        {
            isStopped = true; // Detener si colisiona con otro enemigo
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Restablecer isStopped a false cuando la colisi�n termine
        if (collision.CompareTag("Enemigo") || collision.CompareTag("Tropa"))
        {
            isStopped = false; // Reanudar movimiento
        }
    }

    private IEnumerator Atacar(Movimiento_Soldado tropa)
    {
        while (vida > 0)
        {
            if (tropa.vida > 0)
            {
                tropa.RecibirDa�o(ataque); // Atacar a la tropa
                RecibirDa�o(tropa.ataque); // Recibir da�o de la tropa
            }

            yield return new WaitForSeconds(1.0f); // Esperar 1.0 segundos
        }
        Debug.Log("Muerte Enemigo");

        Destroy(gameObject); // Destruir el enemigo al morir
    }

    public void RecibirDa�o(int da�o)
    {
        Debug.Log("Ataque Enemigo");
        vida -= da�o;
        if (vida <= 0)
        {
            // Otorgar puntos por matar al enemigo
            //gestorDePuntos.A�adirPuntos(puntosPorMuerte); (debugear)

            Destroy(gameObject); // Destruir si se queda sin vida
        }
    }
}