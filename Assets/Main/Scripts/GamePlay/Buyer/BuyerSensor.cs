using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerSensor : MonoBehaviour
{
    [SerializeField] int _buyAmount = 1;
    public int BuyAmount => _buyAmount;
    public Action OnPizzaPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerSensor"))
        {
            if (OnPizzaPickup != null)
            {
                OnPizzaPickup();
            }
        }
    }
}
