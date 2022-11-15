using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    [SerializeField] SellerSensor _sellerSensor;
    [SerializeField] int _productAmount = 10;
    [SerializeField] Transform _startTransform;
    [SerializeField] Transform _parentTransform;
    [SerializeField] string _productName = "Pizza";

    List<StackItem> _stackItems = new List<StackItem>();
    public List<StackItem> StackItems => _stackItems;
   
    public void Initialize()
    {     
        for (int i = 0; i < _productAmount; i++)
        {
            StackItem stackItem = (StackItem)PoolManager.Instance.GetItemByName(_productName);
            AddStackItem(stackItem);
            stackItem.SetInitialParent(stackItem.transform.parent);
            stackItem.gameObject.transform.parent = _parentTransform;
            stackItem.SetActive();
            stackItem.SetPosition(_startTransform.position);
        }
    }

    void AddStackItem(StackItem stackItem)
    {
        _stackItems.Add(stackItem);

    }
   

    public void End()
    {
        foreach  (StackItem stackItem in _stackItems)
        {
            if(stackItem != null)
                stackItem.Dismiss();
        }
        _stackItems.Clear();
    }
}
