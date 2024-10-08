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

            // Atacar mientras ambas unidades est�n vivas y se est� tocando un enemigo
            while (vida > 0 && unidad.vida > 0 && isTouchingEnemy && isALive)
            {
                unidad.RecibirDa�o(ataque);
                RecibirDa�o(unidad.ataque);
                yield return new WaitForSeconds(1.0f);
            }

            // Si el enemigo ha muerto o no estamos tocando un enemigo, se reproducir� la animaci�n de estar quieto
            if (animator != null && vida > 0)
            {
                animator.Play(animQuieto);
            }
        }
    }
}
