using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackItemHandler : MonoBehaviour
{
    public Action OnMoneyChange;

    [SerializeField] PlayerSensor _playerSensor;
    [SerializeField] Transform _parentTransform;
    [SerializeField] Transform _finalTransform;
    [SerializeField] Transform _middleTransform;

    List<StackItem> _collectedStackItem = new List<StackItem>();
     
    bool _isPicked;
    public bool IsPicked => _isPicked;

    public void Initialize()
    {
        _playerSensor.OnStackItemPickup += OnStackItemPickup;
        _playerSensor.OnStackItemDrop += OnStackItemDrop;
    }

    public void StartGame()
    {
       
    }
    public void GameOver(Transform endTransform)
    {
        if (_collectedStackItem.Count == 0) return;
        foreach (StackItem stackItem in _collectedStackItem)
        {
            stackItem.Dismiss();
        }
        _collectedStackItem.Clear();
     
    }

    void OnStackItemPickup(SellerSensor sellerSensor)
    {
        foreach (StackItem stackItem in sellerSensor.StackItems)
        {
            stackItem.gameObject.transform.parent = _parentTransform;
            _collectedStackItem.Add(stackItem);
            stackItem.Move(_finalTransform, _middleTransform, _collectedStackItem.Count);
            PlayerHelper.UpdateStackItemAmount(1);
        }
        _isPicked = true;
    }

    void OnStackItemDrop(BuyerSensor buyerSensor)
    {
        for(int i=0; i< buyerSensor.BuyAmount; i++)
        {
            int j = _collectedStackItem.Count - 1;
            if (j < 0) return;

            StackItem stackItem = _collectedStackItem[j];
            stackItem.gameObject.transform.parent = buyerSensor.transform;
            StartCoroutine(WaitAndDrop(i * .1f + .02f, stackItem,buyerSensor.transform));
            _collectedStackItem.Remove(stackItem);
            PlayerHelper.UpdateStackItemAmount(-1);
            moneyUpdate(1);
        }      
    }

    IEnumerator WaitAndDrop(float wait, StackItem stackItem, Transform finalTransform)
    {
        yield return new WaitForSeconds(wait);
        stackItem.Move(finalTransform, _middleTransform);
      
    }

    void moneyUpdate(int amount)
    {
        PlayerHelper.UpdateMoneyAmount(amount);
        if (OnMoneyChange != null)
            OnMoneyChange();
    }
    
}
