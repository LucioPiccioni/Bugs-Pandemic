using System.Collections;
using UnityEngine;

public class Enemigo : Unidad
{
    private void Update()
    {
        UpdateMovement(Vector2.right);
    }

    protected override IEnumerator Atacar(Unidad tropa)
    {
        if (tropa.tag != gameObject.tag)
        {

            if (animator != null)
            {
                animator.Play(animAtacar);
            }

            while (vida > 0 && tropa.vida > 0 && isTouchingEnemy && isALive && tropa.tag != gameObject.tag)
            {
                tropa.RecibirDaño(ataque);
                RecibirDaño(tropa.ataque);
                yield return new WaitForSeconds(1.0f);
            }

            if (animator != null && vida > 0)
            {
                animator.Play(animQuieto);
            }
        }
    }
}
