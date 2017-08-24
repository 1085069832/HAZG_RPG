using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 物品拖拽
/// </summary>
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static Action<Transform> BeginDrag;
    public static Action Draging;
    public static Action<Transform, PointerEventData> EndDrag;
    public static Action<int, InventoryItemGrid, GameObject> PointerEnter;
    public static Action PointerExit;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //开始拖拽
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (BeginDrag != null)
                BeginDrag(transform);
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (Draging != null)
            Draging();

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
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

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (PointerEnter != null)
        {
            InventoryItemGrid inventoryItemGrid = transform.GetComponentInParent<InventoryItemGrid>();
            PointerEnter(inventoryItemGrid.id, inventoryItemGrid, gameObject);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (PointerExit != null)
            PointerExit();
    }
}
