using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    PlayerMove charactorMove;
    Animation anim;
    // Use this for initialization
    void Start()
    {
        charactorMove = GetComponent<PlayerMove>();
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (charactorMove.state == PlayerMove.PlayerState.Moving)
        {
            anim.CrossFade("Run");
        }
        else if (charactorMove.state == PlayerMove.PlayerState.Idle)
        {
            anim.CrossFade("Idle");
        }
    }
}
