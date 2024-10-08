using System.Collections;
using UnityEngine;

public class Unidad : MonoBehaviour
{
    public float speed = 2.0f;
    public int vida = 3;
    public int ataque = 1;
    protected bool isTouchingTower = false;
    protected bool isTouchingEnemy = false;
    protected bool isALive = true;

    public float repulsionForce = 5.0f;
    public float minDistance = 0.5f;

    public Animator animator;
    public string animCaminar = "Caminar";
    public string animAtacar = "Atacar";
    public string animQuieto = "Quieto";

    string enemyTower = "";
    string rivalTag = "";

    private void Start()
    {
        if (gameObject.tag == "Tropa")
        {
            enemyTower = "EnemyTower";
            rivalTag = "Enemigo";
        }
        else if (gameObject.tag == "Enemigo")
        {
            enemyTower = "PlayerTower";
            rivalTag = "Tropa";
        }

        if (animator != null)
        {
            animator.Play(animCaminar);
        }
    }

    protected virtual void UpdateMovement(Vector2 direction)
    {
        if (!isTouchingTower && !isTouchingEnemy)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            if (animator != null)
            {
                animator.Play(animCaminar);
            }
        }
        else
        {
            if (animator != null && !IsAttacking())
            {
                animator.Play(animQuieto);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(rivalTag))
        {
            isTouchingEnemy = true;
            StartCoroutine(Atacar(collision.GetComponent<Unidad>()));
        }
        else if (collision.gameObject.CompareTag(enemyTower))
        {
            isTouchingTower = true;
            StartCoroutine(AtacarTower(collision.GetComponent<Tower>()));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(rivalTag))
        {
            isTouchingEnemy = false;
        }
        else if (collision.gameObject.CompareTag(enemyTower))
        {
            isTouchingTower = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag) && !isTouchingEnemy && !isTouchingTower)
        {
            Vector2 direction = transform.position - collision.transform.position;
            float distance = direction.magnitude;

            if (distance < minDistance)
            {
                Vector2 repulsion = direction.normalized * repulsionForce * Time.deltaTime;
                transform.Translate(repulsion);
            }
        }
    }


    protected virtual IEnumerator Atacar(Unidad unidad)
    {
        if (unidad.gameObject.tag != gameObject.tag)
        {
            if (animator != null)
            {
                animator.Play(animAtacar);
            }

            while (vida > 0 && unidad.vida > 0 && isTouchingEnemy)
            {
                unidad.RecibirDaño(ataque);
                RecibirDaño(unidad.ataque);
                yield return new WaitForSeconds(1.0f);
            }

            if (unidad.vida <= 0)
            {
                isTouchingEnemy = false;
            }

            if (animator != null && vida > 0)
            {
                animator.Play(animQuieto);
            }
        }
    }

    protected virtual IEnumerator AtacarTower(Tower tower)
    {
        if (animator != null)
        {
            animator.Play(animAtacar);
        }

        while (vida > 0 && tower != null && tower.tag == enemyTower)
        {
            tower.RecibirDaño(ataque);
            yield return new WaitForSeconds(1.0f);
        }

        if (tower == null)
        {
            isTouchingTower = false;
        }

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
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private bool IsAttacking()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animAtacar);
    }
}
