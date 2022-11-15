using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void SetWinAnim(bool value)
    {
        AnimUpdate("IsWin", value);

    }
    void AnimUpdate(string id, bool value)
    {

        anim.SetBool(id, value);
    }
}
