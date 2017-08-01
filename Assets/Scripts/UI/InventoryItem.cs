using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 物品拖拽
/// </summary>
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    RaycastHit raycastHit;
    Button bt;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //开始拖拽
        eventData.pointerCurrentRaycast.gameObject.transform.parent = GetComponentInParent<Inventory>().gameObject.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //正在拖拽
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //注意射线检测不到UI
        //结束拖拽
        //判断拖拽到哪个物体上
        bool isCollider = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit);
        if (isCollider)
        {
            //有饰品的格子,自己或其他饰品
            //没饰品的格子
            //其他
            print(raycastHit.transform.name);

        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            print("点击到UI");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("OnPointerEnter" + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

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
