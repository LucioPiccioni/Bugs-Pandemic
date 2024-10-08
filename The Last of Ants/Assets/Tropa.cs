using System.Collections;
using UnityEngine;

public class Tropa : Unidad
{
    private void Update()
    {
        UpdateMovement(Vector2.left); // Movimiento hacia la izquierda
    }

    protected override IEnumerator Atacar(Unidad unidad)
    {
        // Activar animación de ataque al iniciar el ataque
        if (animator != null)
        {
            animator.Play(animAtacar);
        }

        while (vida > 0 && unidad.vida > 0 && isStopped && isALive && unidad.tag != gameObject.tag)
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
    }
}
