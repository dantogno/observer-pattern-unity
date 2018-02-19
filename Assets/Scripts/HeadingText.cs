using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadingText : MonoBehaviour
{
    [SerializeField]
    private int coinsRequiredToWin = 3;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void OnCoinValueChanged(int coinCount)
    {
        UpdateText(coinCount);
    }

    private void UpdateText(int coinCount)
    {
        if (CheckForWin(coinCount))
        {
            text.text = "You win!";
        }
        else
        {
            int coinsNeeded = coinsRequiredToWin - coinCount;
            text.text = String.Format("You need {0} more coin(s)!", coinsNeeded);
        }
    }

    private bool CheckForWin(int coinCount)
    {
        bool playerHasWon = coinCount == coinsRequiredToWin;

        return playerHasWon;
    }

    // Subscribe and unsubscribe from the event
    private void OnEnable()
    {
        Coin.CoinCountValueChanged += OnCoinValueChanged;
    }

    private void OnDisable()
    {
        Coin.CoinCountValueChanged -= OnCoinValueChanged;
    }
}
