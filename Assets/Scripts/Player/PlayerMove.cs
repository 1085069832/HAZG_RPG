using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// 角色状态
    /// </summary>
    public enum PlayerState
    {
        Moving, Idle
    }

    PlayerDirection charactorDir;
    CharacterController characterController;
    [HideInInspector] public PlayerState state;
    // Use this for initialization
    void Start()
    {
        charactorDir = GetComponent<PlayerDirection>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, charactorDir.playerFinalPos);
        //判断是否还有距离
        if (distance > 0.5f)
        {
            //移动
            characterController.SimpleMove(transform.forward * 5f);
            state = PlayerState.Moving;
        }
        else
        {
            //静止
            state = PlayerState.Idle;
        }
    }
}
