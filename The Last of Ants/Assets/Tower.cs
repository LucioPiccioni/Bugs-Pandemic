using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public float life = 1000;

    public Text displayLife;

    public void RecibirDaño(int daño)
    {
        life -= daño;
        if (life <= 0)
        {
            Debug.Log($"{gameObject.name} ha sido destruida.");
        }
    }

    private void Update()
    {
        displayLife.text = life.ToString();
    }

    public bool IsDestroyed()
    {
        return life <= 0;
    }
}