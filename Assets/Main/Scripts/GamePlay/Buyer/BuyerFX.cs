using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerFX : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void Initialize()
    {
        AnimUpdate("IsWaving", true);
    }

    public void SetIdleAnim()
    {
        AnimUpdate("IsWaving", false);
      
    }
    void AnimUpdate(string id, bool value)
    {
        
        anim.SetBool(id, value);
    }
}
