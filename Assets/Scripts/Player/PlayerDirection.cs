using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDirection : MonoBehaviour
{

    [SerializeField] GameObject clickGroundEffect;//点击特效
    [HideInInspector] public Vector3 playerFinalPos;//角色最终位置
    bool isMoving;

    // Use this for initialization
    void Start()
    {
        playerFinalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //点击到的不是物体，而是UI
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool isCollider = Physics.Raycast(ray, out raycastHit);
            if (isCollider)
            {
                if (raycastHit.transform.tag == MyConstants.GROUND)
                {
                    isMoving = true;
                    ShowClickGroundEffect(raycastHit.point);
                    //设置人物朝向
                    MoveDirection(raycastHit.point);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        //按下左键不松开，也改变朝向
        if (isMoving)
        {
            //移动
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool isCollider = Physics.Raycast(ray, out raycastHit);
            if (isCollider)
            {
                if (raycastHit.transform.tag == MyConstants.GROUND)
                {
                    Vector3 pos = raycastHit.point;
                    //设置人物朝向
                    MoveDirection(pos);
                    playerFinalPos = pos;
                }
            }
        }
    }
    /// <summary>
    /// 显示点击特效
    /// </summary>
    private void ShowClickGroundEffect(Vector3 raycastHitPoint)
    {
        Instantiate(clickGroundEffect, raycastHitPoint + new Vector3(0, 0.1f, 0), Quaternion.identity);
    }

    /// <summary>
    /// 人物朝向
    /// </summary>
    private void MoveDirection(Vector3 raycastHitPoint)
    {
        //人物Y不变
        Vector3 dirPoint = new Vector3(raycastHitPoint.x, transform.position.y, raycastHitPoint.z);
        transform.LookAt(dirPoint);
    }
}
