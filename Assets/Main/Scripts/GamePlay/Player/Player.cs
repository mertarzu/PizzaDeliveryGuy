using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class Player : MonoBehaviour
{

    bool _isActive;
 
    public void Initialize()
    {
        _isActive = false;
    }
  
    public void StartGame()
    {
        _isActive = true;
        gameObject.SetActive(true);
    
    }
    public void GameOver()
    {     
        _isActive = false;      
    }

    public void Reload()
    {
        transform.rotation = Quaternion.identity;
    }

   

}
