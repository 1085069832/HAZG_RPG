using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 物品拖拽
/// </summary>
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Action<Transform> BeginDrag;
    public static Action Draging;
    public static Action<Transform, PointerEventData> EndDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //开始拖拽
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (BeginDrag != null)
                BeginDrag(transform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Draging != null)
            Draging();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (EndDrag != null)
            EndDrag(transform, eventData);
    }

    /// <summary>
    /// id设置图片
    /// </summary>
    /// <param name="id"></param>
    public void SetId(int id)
    {
        ObjectInfo objectInfo = ParseObjectInfo.Instance.GetObjectInfo(id);
        Texture texture = Resources.Load<Texture>("GUI/Icon/" + objectInfo._icon_name);
        GetComponent<RawImage>().texture = texture;
    }

    /// <summary>
    /// 名称设置图片
    /// </summary>
    /// <param name="iconName"></param>
    public void SetIconName(string iconName)
    {
        Texture texture = Resources.Load<Texture>("GUI/Icon/" + iconName);
        GetComponent<RawImage>().texture = texture;
    }
}
