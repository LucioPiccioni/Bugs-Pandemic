using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class LogiScript : MonoBehaviour
{
    public string levelName;
    public int currency;
    public Text currencyText;
    int showCurrency;
    float timer = 0;

    bool pause = false;

    private enum MatchResult
    {
        None,
        Player,
        Enemy,
        Draw
    }

    MatchResult result = MatchResult.None;

    public Tower playerTower;
    public Tower enemyTower;

    void Start()
    {
        currency = 25;
    }

    private void Update()
    {
        if (result == MatchResult.None)
        {
            CheckGameStatus();

            if (timer >= 2)
            {
                currency += 10;
                UpdateCurrencyText();
                timer = 0;
            }
            else
            {
                timer = timer + 1 * Time.deltaTime;
            }
        }

        if (result != MatchResult.None)
        {
            SceneManager.LoadScene(levelName);
        }
    }

    public void UpdateCurrencyText()
    {
        int showCurrency = (int)currency;
        currencyText.text = showCurrency.ToString();
    }

    // Método para añadir puntos
    public void AñadirPuntos(int puntos)
    {
        currency += puntos;
        UpdateCurrencyText(); // Actualizar el texto en la UI
    }

    MatchResult CheckGameStatus()
    {
        if (playerTower.IsDestroyed() && !enemyTower.IsDestroyed())
        {
            Debug.Log("Has perdido.");
            result = MatchResult.Enemy;
        }
        else if (!playerTower.IsDestroyed() && enemyTower.IsDestroyed())
        {
            Debug.Log("Has ganado.");
            result = MatchResult.Player;
        }
        else if (playerTower.IsDestroyed() && enemyTower.IsDestroyed())
        {
            Debug.Log("Es un empate.");
            result = MatchResult.Draw;
        }
        else
        {
            result = MatchResult.None;
        }

        return result;
    }

}