using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI界面的动画
/// </summary>
public class ShowUIAnim : MonoBehaviour
{
    [SerializeField] Transform endIndex;//最终位置
    [SerializeField] float speed = 0.1f;//移动的速度
    [HideInInspector]
    public bool isClose = true;//是否关闭
    [SerializeField] Transform startIndex;//开始位置
    // Use this for initialization
    void Start()
    {
    }

    /// <summary>
    /// 开启UI
    /// </summary>
    public void OnUIOpen()
    {
        if (isClose)
            StartCoroutine(MyConstants.UIOPEN);
    }

    /// <summary>
    /// 关闭UI
    /// </summary>
    public void OnUIClose()
    {
        if (!isClose)
            StartCoroutine(MyConstants.UICLOSE);
    }

    /// <summary>
    /// 开启UI
    /// </summary>
    /// <returns></returns>
    IEnumerator UIOpen()
    {
        isClose = false;
        yield return 0;
        //lerp,两个值不停缩小
        transform.position = Vector3.Lerp(transform.position, endIndex.position, speed);
        StartCoroutine(MyConstants.UIOPEN);
        if (Vector3.Distance(transform.position, endIndex.position) < 0.1f)
        {
            StopCoroutine(MyConstants.UIOPEN);
        }
    }

    /// <summary>
    /// 开启UI
    /// </summary>
    /// <returns></returns>
    IEnumerator UIClose()
    {
        isClose = true;
        yield return 0;
        //lerp,两个值不停缩小
        transform.position = Vector3.Lerp(transform.position, startIndex.position, speed);
        StartCoroutine(MyConstants.UICLOSE);
        print("移动");
        if (Vector3.Distance(transform.position, startIndex.position) < 0.1f)
        {
            StopCoroutine(MyConstants.UICLOSE);
        }
    }
}
