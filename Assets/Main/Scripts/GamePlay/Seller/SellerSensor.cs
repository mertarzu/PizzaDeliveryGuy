using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerSensor : MonoBehaviour
{
    [SerializeField] Seller _seller;
    public List<StackItem> StackItems => _seller.StackItems;

  
}
