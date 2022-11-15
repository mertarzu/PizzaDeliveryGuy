using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyer : MonoBehaviour
{
    [SerializeField] BuyerFX _buyerFX;
    [SerializeField] BuyerSensor _buyerSensor;
    public void Initialize()
    {
        _buyerFX.Initialize();
        _buyerSensor.OnPizzaPickup += OnPizzaPickUp; 
    }

    public void End()
    {
       
    }

    void OnPizzaPickUp()
    {
        _buyerFX.SetIdleAnim();
    }
}
