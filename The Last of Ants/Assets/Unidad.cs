using System.Collections;
using UnityEngine;

public class Unidad : MonoBehaviour
{
    public float speed = 2.0f; 
    public int vida = 3; 
    public int ataque = 1; 
    protected bool isStopped = false; 
    protected bool attackingTower = false; 
    protected bool isALive = true;
    protected bool isColliding = false;

    public float repulsionForce = 5.0f;
    public float minDistance = 0.5f;


    public Animator animator;
    public string animCaminar = "Caminar";
    public string animAtacar = "Atacar";
    public string animQuieto = "Quieto";

    string enemyTower = "";

    private void Start()
    {
        if (gameObject.tag == "Tropa")
        {
            enemyTower = "EnemyTower";
        }
        else if (gameObject.tag == "Enemigo")
        {
            enemyTower = "PlayerTower";
        }

        // Iniciar con animación de caminar
        if (animator != null)
        {
            animator.Play(animCaminar);
        }
    }

    protected virtual void UpdateMovement(Vector2 direction)
    {
        if (!isStopped && !attackingTower)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            // Activar animación de caminar si la unidad se está moviendo
            if (animator != null)
            {
                animator.Play(animCaminar);
            }
        }
        else
        {
            // Activar animación de estar quieto si no está atacando ni moviéndose
            if (animator != null && !IsAttacking())
            {
                animator.Play(animQuieto);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            isStopped = true; // Detener la tropa
            StartCoroutine(Atacar(collision.GetComponent<Unidad>())); // Usar la clase base
        }
        else if (collision.gameObject.CompareTag("Tropa"))
        {
            isStopped = true; // Detener si colisiona con otra tropa
        }
        else if (collision.gameObject.CompareTag(enemyTower))
        {
            isStopped = true;
            attackingTower = true;
            StartCoroutine(AtacarTower(collision.GetComponent<Tower>()));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") ||
            collision.gameObject.CompareTag(enemyTower) ||
            collision.gameObject.CompareTag("Tropa"))
        {
            isStopped = false;
            attackingTower = false;
        }
    }

    protected virtual IEnumerator Atacar(Unidad unidad)
    {
        // Activar animación de ataque al iniciar el ataque
        if (animator != null)
        {
            animator.Play(animAtacar);
        }

        while (vida > 0 && unidad.vida > 0 && isStopped)
        {
            unidad.RecibirDaño(ataque);
            RecibirDaño(unidad.ataque);
            yield return new WaitForSeconds(1.0f);
        }

        // Al terminar el ataque, cambiar a la animación de quieto
        if (animator != null && vida > 0)
        {
            animator.Play(animQuieto);
        }

        Debug.Log($"{gameObject.name} ha muerto.");
        Destroy(gameObject);
    }

    protected virtual IEnumerator AtacarTower(Tower tower)
    {
        // Activar animación de ataque al iniciar el ataque
        if (animator != null)
        {
            animator.Play(animAtacar);
        }

        while (vida > 0 && tower != null && tower.tag == enemyTower)
        {
            tower.RecibirDaño(ataque);
            yield return new WaitForSeconds(1.0f);
        }

        // Al terminar el ataque, cambiar a la animación de quieto
        if (animator != null && vida > 0)
        {
            animator.Play(animQuieto);
        }

        Debug.Log($"{gameObject.name} ha muerto.");
        Destroy(gameObject);
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            isALive = false;
            Debug.Log($"{gameObject.name} ha muerto.");
            Destroy(gameObject);
        }
    }

    // Método para verificar si la unidad está atacando
    private bool IsAttacking()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animAtacar);
    }
}
