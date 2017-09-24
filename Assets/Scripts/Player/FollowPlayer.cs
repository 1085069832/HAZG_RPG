using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 摄像机跟随
/// </summary>
public class FollowPlayer : MonoBehaviour
{

    Vector3 offset;//角色到摄像机的距离
    Vector3 offsetNormalized;//距离向量方向
    bool isRotating;
    GameObject player;
    [SerializeField] float scrollSpeed = 1f;//滑动速度
    [SerializeField] float minDistance = 2f;//拉近的最近距离
    [SerializeField] float maxDistance = 12f;//拉远的最远距离
    [SerializeField] float mouseSpeed = 1f;//鼠标拖动速度
    PlayerMove playerMove;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(MyConstants.PLAYER);
        playerMove = player.GetComponent<PlayerMove>();
        transform.LookAt(player.transform.position);
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        RotateView();//镜头旋转

        ScrollView();//镜头拉近和拉远

        //让摄像机和角色保持距离
        transform.position = player.transform.position + offset;
    }

    /// <summary>
    /// 镜头旋转
    /// </summary>
    private void RotateView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating && playerMove.state == PlayerMove.PlayerState.Idle && !EventSystem.current.IsPointerOverGameObject())
        {
            float mouseX = Input.GetAxis(MyConstants.MOUSEX);//鼠标滑动值
            float mouseY = Input.GetAxis(MyConstants.MOUSEY);
            //记录位置和旋转
            Vector3 originPos = transform.position;
            Quaternion originRotation = transform.rotation;

            //X旋转
            transform.RotateAround(player.transform.position, player.transform.up, mouseX * mouseSpeed * Time.deltaTime);
            //Y旋转
            transform.RotateAround(player.transform.position, transform.right, -mouseY * mouseSpeed * Time.deltaTime);
            float x = transform.eulerAngles.x;
            if (x < 10 || x > 80)
            {
                //重置位置和旋转
                transform.position = originPos;
                transform.rotation = originRotation;
            }
            offset = transform.position - player.transform.position;
        }

        //重新更新角色到摄像机的向量
        offsetNormalized = offset.normalized;
    }

    /// <summary>
    /// 镜头拉近和拉远
    /// </summary>
    private void ScrollView()
    {
        float scrollValue = Input.GetAxis(MyConstants.MOUSESW);
        if (scrollValue != 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            DoScrollView(scrollValue);
        }
    }

    /// <summary>
    /// 改变距离
    /// </summary>
    /// <param name="scrollValue">鼠标中键值</param>
    private void DoScrollView(float scrollValue)
    {
        //限制距离
        if (offset.magnitude < minDistance)
        {
            offset = offsetNormalized * minDistance;
        }
        else if (offset.magnitude > maxDistance)
        {
            offset = offsetNormalized * maxDistance;
        }
        //设置距离
        offset -= offsetNormalized * scrollValue * scrollSpeed * Time.deltaTime;
    }
}
