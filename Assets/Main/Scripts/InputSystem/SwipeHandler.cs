using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeHandler : IInputHandler<float>
{
    float _lastPosX;
    float _deltaPosX;

    
    public float Output => _deltaPosX;
   
    public void InputUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {          
            _lastPosX = Input.mousePosition.x;
        }
            
        if (Input.GetMouseButton(0))
        {
            _deltaPosX = Input.mousePosition.x - _lastPosX;
            _lastPosX = Input.mousePosition.x;
       
        }

        if (Input.GetMouseButtonUp(0))
        {           
            _deltaPosX = 0;
        }
       
    }
    
}
