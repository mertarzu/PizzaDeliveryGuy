using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItem : PooledObject
{
    public Action OnPurchase;

    bool _isTaken;
    public override bool IsPooledObjectTaken => _isTaken;

    [SerializeField] StackItemMover _stackItemMover;
    Transform _parent;
 
    public override void Dismiss()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.parent = _parent;    
        gameObject.SetActive(false);
        _isTaken = false;
    }

    public override void SetActive()
    {
        gameObject.SetActive(true);
        _isTaken = true;
    }

    public override void SetPosition(Vector3 pos)
    {       
        transform.position = pos;      
    }

    public void SetInitialParent(Transform parent)
    {
        _parent = parent;
    }

    public void Move(Transform startTransform, float index)
    {
        _stackItemMover.Move(startTransform, index);
    }

    public void Move(Transform targetTransform, Transform middleTransform, float index)
    {
        _stackItemMover.Move(targetTransform, middleTransform, index);
    }

    public void Move(Transform finalTransform, Transform middleTransform)
    {
        _stackItemMover.Move(finalTransform, middleTransform);
    }
    public void Purchase()
    {    
        Dismiss();
        if (OnPurchase != null)
            OnPurchase();
    }
}
