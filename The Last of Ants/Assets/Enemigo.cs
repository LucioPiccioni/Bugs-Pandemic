using System.Collections;
using UnityEngine;

public class Enemigo : Unidad
{
    private void Update()
    {
        UpdateMovement(Vector2.right); // Movimiento hacia la derecha
    }

    protected override IEnumerator Atacar(Unidad tropa)
    {
        // Activar animación de ataque al iniciar el ataque
        if (animator != null)
        {
            animator.Play(animAtacar);
        }

        while (vida > 0 && tropa.vida > 0 && isALive && tropa.tag != gameObject.tag)
        {
            tropa.RecibirDaño(ataque);
            RecibirDaño(tropa.ataque);
            yield return new WaitForSeconds(1.0f);
        }

        // Al terminar el ataque, cambiar a la animación de quieto
        if (animator != null && vida > 0)
        {
            animator.Play(animQuieto);
        }
    }
}
