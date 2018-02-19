using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // public delegate void CoinCountValueChangedDelegate(int newCoinCount);

    // Using Action<T> allows us to skip defining our own delegate template
    public static event Action<int> CoinCountValueChanged;

    private static int coinCountUseProperty;

    public static int CoinCount
    {
        get { return coinCountUseProperty; }
        private set
        {
            coinCountUseProperty = value;
            if (CoinCountValueChanged != null)
                CoinCountValueChanged.Invoke(coinCountUseProperty);
        }
    }

    private void OnMouseDown()
    {
        CollectCoin();
    }

    private void CollectCoin()
    {
        CoinCount++;
        Destroy(gameObject);
    }
}
