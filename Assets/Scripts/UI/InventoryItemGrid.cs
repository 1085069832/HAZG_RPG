using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemGrid : MonoBehaviour
{

    int id = 0;
    int num = 0;//物体数量
    ObjectInfo objectInfo;
    Text objectNumText;//显示物体数量
    // Use this for initialization
    void Start()
    {
        objectNumText = GetComponentInChildren<Text>();
    }

    public void SetId(int id, int num = 1)
    {
        objectInfo = ParseObjectInfo.Instance.GetObjectInfo(id);
        InventoryItem item = GetComponentInChildren<InventoryItem>();
        item.SetIconName(objectInfo._icon_name);
        objectNumText.gameObject.SetActive(true);
        this.num = num;
        objectNumText.text = num.ToString();
    }
    /// <summary>
    /// 清空信息
    /// </summary>
    public void ClearInfo()
    {
        id = 0;
        num = 0;
        objectInfo = null;
        objectNumText.gameObject.SetActive(false);
    }
}
