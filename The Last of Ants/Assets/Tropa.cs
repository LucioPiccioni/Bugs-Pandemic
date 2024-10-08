using System.Collections;
using UnityEngine;

public class Tropa : Unidad
{
    private void Update()
    {
        // La tropa siempre se mueve hacia la izquierda
        UpdateMovement(Vector2.left);
    }

    // Sobreescribe el comportamiento de atacar
    protected override IEnumerator Atacar(Unidad unidad)
    {
        if (unidad.tag != gameObject.tag)
        {
            if (animator != null)
            {
                animator.Play(animAtacar);
            }

            // Atacar mientras ambas unidades estén vivas y se esté tocando un enemigo
            while (vida > 0 && unidad.vida > 0 && isTouchingEnemy && isALive)
            {
                unidad.RecibirDaño(ataque);
                RecibirDaño(unidad.ataque);
                yield return new WaitForSeconds(1.0f);
            }

            // Si el enemigo ha muerto o no estamos tocando un enemigo, se reproducirá la animación de estar quieto
            if (animator != null && vida > 0)
            {
                animator.Play(animQuieto);
            }
        }
    }
}
