using System.Collections;
using UnityEngine;

public class Movimiento_Soldado : MonoBehaviour
{
    public float speed = 2.0f;
    public int vida = 3;
    public int ataque = 1;
    private bool isStopped = false;

    private void Update()
    {
        if (!isStopped)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            isStopped = true; // Detener la tropa
            StartCoroutine(Atacar(collision.GetComponent<Movimiento_Enemigo>()));
        }
        else if (collision.CompareTag("Tropa"))
        {
            isStopped = true; // Detener si colisiona con otra tropa
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

    private IEnumerator Atacar(Movimiento_Enemigo enemigo)
    {
        while (vida > 0)
        {
            if (enemigo.vida > 0)
            {
                enemigo.RecibirDa�o(ataque); // Atacar al enemigo
                RecibirDa�o(enemigo.ataque); // Recibir da�o del enemigo
            }

            yield return new WaitForSeconds(1.0f); // Esperar 1.0 segundos
        }
        Debug.Log("Muerte Soldado");
        Destroy(gameObject); // Destruir si se queda sin vida
    }

    public void RecibirDa�o(int da�o)
    {
        Debug.Log("Ataque Soldado");
        vida -= da�o;
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruir si se queda sin vida
        }
    }
}