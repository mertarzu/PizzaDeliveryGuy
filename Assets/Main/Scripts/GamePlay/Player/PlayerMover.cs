using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public Action OnGameOver;
    [SerializeField] Transform _pivot;
    const float MinX = -3f;
    const float MaxX = 3f;
    const float SwipeSpeed = 5f;
    const float ForwardSpeed = 8;
    float swingTimer;
    const float swingDuration = .8f;
    const float swingRate = 3f;
    float swingAngle = 1;
   
    public void MoveForward()
    {
        transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);   
    }
    public void MovementUpdate(float output)
    {     
        transform.position += (Vector3.right * output).normalized * SwipeSpeed * Time.deltaTime;
        transform.position = CheckBoundary(transform.position);
       
        float angle = transform.eulerAngles.z;
        angle = (angle > 180) ? angle - 360 : angle;
        if (Mathf.Abs(angle) > 5) return;
        transform.Rotate(new Vector3(0,0, -output).normalized * .5f);     
    }

    public Vector3 CheckBoundary(Vector3 checkPos)
    {
        Vector3 pos = checkPos;
        pos.x = Mathf.Clamp(checkPos.x, MinX, MaxX);
        checkPos = pos;
        return checkPos;
    }

    public void Swing()
    {
        if (swingTimer < swingDuration)
        {
            _pivot.rotation = Quaternion.Lerp(_pivot.rotation, Quaternion.Euler(0, 0, swingAngle), swingTimer);
            swingTimer += swingRate * Time.deltaTime;
        }
        else
        {
            swingAngle = -swingAngle;
            swingTimer = 0;
        }
    }

    public void GameOverUpdate(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition,2* Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 160, 0), 2* Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            transform.position = targetPosition;
            transform.rotation = Quaternion.Euler(0, 160, 0);
            if(OnGameOver != null)
            {
                OnGameOver();
            }
        }

    }
}
