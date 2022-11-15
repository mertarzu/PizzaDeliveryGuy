using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItemMover : MonoBehaviour
{   
    public bool IsPickedUp { get; set; }
  
    [SerializeField] BoxCollider _collider;
    [SerializeField] StackItem _stackItem;
    Transform _finalTransform;
    Transform _middleTransform;
    Vector3 _startPosition;
    Vector3 _middlePosition;
    Vector3 _targetPosition;
    Vector3 _finalInitialPosition;
    Vector3 _middleInitialPosition;
    float _index;
    float _time;
    float _timeModifier = 1f;
    bool _isDropping;
    bool _isPicking;
  
    const float OffsetY = .1f;
   

    public void Move(Transform startTransform, float index)
    {
        Vector3 offset = new Vector3(0, index * (_collider.size.y + OffsetY), 0);
        transform.position = startTransform.position + offset;
    }

    public void Move(Transform finalTransform, Transform middleTransform, float index)
    {
       
        _startPosition = transform.position;
        _finalTransform = finalTransform;
        _middleTransform = middleTransform;
        _index = index;
        StartCoroutine(WaitAndMove());
    }
    public void Move(Transform finalTransform, Transform middleTransform)
    {
      
        _startPosition = transform.position;
        _targetPosition = finalTransform.position;
        _middlePosition = middleTransform.position;
        _isDropping = true;
    }

    private void FixedUpdate()
    {
        if (_isDropping)
        {
            DroppingUpdate();

        }
        if (_isPicking) PickingUpdate(); 
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(Time.fixedDeltaTime * _index *2);
       
        _isPicking = true;
    }
    private void PickingUpdate()
    {
        _finalInitialPosition = _finalTransform.position;
        _middleInitialPosition = _middleTransform.position;
        _finalTransform.position += new Vector3(0, _index * (_collider.size.y + OffsetY), 0);
        _middleTransform.position += new Vector3(0, _index * (_collider.size.y + OffsetY), 0);

        transform.position = Bezier.QuadraticBezierCurveSolver(_time, _startPosition, _middleTransform.position, _finalTransform.position);
    
       
        _time += Time.fixedDeltaTime * _timeModifier;

        if (Vector3.Distance(transform.position, _finalTransform.position) < 0.001f)
        {
            transform.position = _finalTransform.position;
       
            transform.rotation =  Quaternion.identity;
            
            _time = 0;
            _isPicking = false;         
        }
        _finalTransform.position = _finalInitialPosition;
        _middleTransform.position = _middleInitialPosition;
    }

    private void DroppingUpdate()
    {
        transform.position = Bezier.QuadraticBezierCurveSolver(_time, _startPosition, _middlePosition, _targetPosition);

        _time += Time.fixedDeltaTime * _timeModifier;
        if (Vector3.Distance(transform.position, _targetPosition) < 0.001f)
        {
            transform.position = _targetPosition;
            transform.rotation = Quaternion.identity;
           
            _stackItem.Purchase();
            _time = 0;
            _isDropping = false;
        }
    }

}
