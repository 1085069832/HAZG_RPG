using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemGrid : MonoBehaviour
{
    [HideInInspector]
    public int id = 0;//物品id
    int num = 0;//物体数量
    ObjectInfo objectInfo;
    Transform numberLabel;
    // Use this for initialization
    void Start()
    {
        numberLabel = transform.FindChild("NumberLabel");
    }

    /// <summary>
    /// 添加物品
    /// </summary>
    /// <param name="id"></param>
    /// <param name="num"></param>
    public void SetId(int id, int num = 1)
    {
        objectInfo = ParseObjectInfo.Instance.GetObjectInfo(id);
        InventoryItem item = GetComponentInChildren<InventoryItem>();
        item.SetIconName(objectInfo._icon_name);
        numberLabel.gameObject.SetActive(true);
        this.id = id;
        this.num = num;
        //显示物体数量
        numberLabel.GetComponent<Text>().text = num.ToString();
        //设置层级
        numberLabel.SetSiblingIndex(item.transform.GetSiblingIndex() + 1);
    }

    /// <summary>
    /// 清空信息
    /// </summary>
    public void ClearInfo()
    {
        id = 0;
        num = 0;
        objectInfo = null;
        numberLabel.gameObject.SetActive(true);
    }

    /// <summary>
    /// 添加数量
    /// </summary>
    /// <param name="num"></param>
    public void AddNum(int num = 1)
    {
        this.num += num;
        numberLabel.GetComponent<Text>().text = this.num.ToString();
    }
}
