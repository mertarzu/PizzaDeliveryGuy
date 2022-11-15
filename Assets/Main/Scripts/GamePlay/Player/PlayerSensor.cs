using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public Action<SellerSensor> OnStackItemPickup;
    public Action<BuyerSensor> OnStackItemDrop;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Seller"))
        {
           SellerSensor sellerSensor = other.GetComponent<SellerSensor>();

            if (OnStackItemPickup != null)
            {
                OnStackItemPickup(sellerSensor);
            }
        }

        if (other.CompareTag("Buyer"))
        {
            if (PlayerHelper.GetStackItemAmount() == 0) return;
            BuyerSensor buyerSensor = other.GetComponent<BuyerSensor>();
            if (OnStackItemDrop != null)
            {
                OnStackItemDrop(buyerSensor);
            }
        }
    }
}
