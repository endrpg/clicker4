using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
public class InAppPurchase : MonoBehaviour
{
    public bool coins;
    public float coinsToGive = 100;
    public int heartsToGive = 1;
    void Start()
    {
    }
    public void OnPurchaseComplete(Product product)
    {
            if(coins)
            {
                GameManager.Instance.AddGold(coinsToGive);
            }
            else if(!coins)
            {
                if(GameManager.Instance.hearts + heartsToGive <= 3)
                {
                    GameManager.Instance.hearts += heartsToGive;
                }
            }
    }
    public void OnPurchaseFailure(Product product,PurchaseFailureReason reason)
    {
        Debug.Log("Failure");
    }
}
