using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class LogiScript : MonoBehaviour
{
    public float currency;
    public Text currencyText;
    int showCurrency;

    // Start is called before the first frame update
    void Start()
    {
        currency = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currency = currency + 10 * Time.deltaTime;
        UpdateCurrencyText();
    }

    public void UpdateCurrencyText()
    {
        int showCurrency = (int)currency;
        currencyText.text = showCurrency.ToString();
    }
}
