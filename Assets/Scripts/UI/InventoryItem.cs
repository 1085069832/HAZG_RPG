using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 物品拖拽
/// </summary>
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RawImage objectIcon;

    private void Start()
    {
        objectIcon = GetComponent<RawImage>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //开始拖拽
    }

    public void OnDrag(PointerEventData eventData)
    {
        //正在拖拽
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //结束拖拽
        print(eventData.position);

    }

    /// <summary>
    /// 设置图片
    /// </summary>
    /// <param name="id"></param>
    public void SetId(int id)
    {
        ObjectInfo objectInfo = ParseObjectInfo.Instance.GetObjectInfo(id);
        objectIcon.name = objectInfo._icon_name;
    }

    public void SetIconName(string iconName)
    {
        objectIcon.name = iconName;
    }
}
