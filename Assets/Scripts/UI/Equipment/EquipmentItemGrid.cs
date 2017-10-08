using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItemGrid : MonoBehaviour
{
    public DressType dressType;
    GameObject equipmentItem;
    public int id;

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
                Inventory.Instance.GetId(id);//旧装备id
                UpdatePlayerStatus(id, false);
            }
            this.equipmentItem.GetComponent<RawImage>().texture = texture;
            id = info._id;//新装备id
            UpdatePlayerStatus(id, true);
            return true;
        }
        return false;
    }

    /// <summary>
    /// 更新角色属性
    /// </summary>
    /// <param name="id"></param>
    public void UpdatePlayerStatus(int id, bool isAdd)
    {
        ObjectInfo info = ParseObjectInfo.Instance.GetObjectInfo(id);
        PlayerStatus status = PlayerStatus._instance;
        status.Attack = isAdd ? status.Attack += info.attack : status.Attack -= info.attack;
        status.Def = isAdd ? status.Def += info.def : status.Def -= info.def;
        status.Speed = isAdd ? status.Speed += info.speed : status.Speed -= info.speed;
    }
}
