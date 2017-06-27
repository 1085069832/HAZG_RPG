using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 移动摄像机
/// </summary>
public class MoveCamera : MonoBehaviour
{

    [SerializeField] float speed = 5f;
    [SerializeField] float endPos = -20f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < endPos)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }
}
