using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItemGrid : MonoBehaviour
{

    public DressType dressType;
    GameObject equipmentItem;
    int id;

    /// <summary>
    /// id设置图片
    /// </summary>
    /// <param name="id"></param>
    public bool SetInfo(ObjectInfo info, GameObject equipmentItem)
    {
        if (!this.equipmentItem)
        {
            this.equipmentItem = Instantiate(equipmentItem, transform);
        }

        Texture texture = Resources.Load<Texture>("GUI/Icon/" + info._icon_name);

        if (this.equipmentItem.GetComponent<RawImage>().texture != texture)
        {
            if (this.equipmentItem.GetComponent<RawImage>().texture)
            {
                //不为空
                //回退被替换的物品
                Inventory.Instance.GetId(id);
            }
            this.equipmentItem.GetComponent<RawImage>().texture = texture;
            id = info._id;
            return true;
        }
        return false;
    }
}
