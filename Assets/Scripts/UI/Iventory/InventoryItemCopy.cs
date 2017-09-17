using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemCopy : MonoBehaviour
{

    /// <summary>
    /// 设置图片
    /// </summary>
    public void SetTexture(Texture texture)
    {
        GetComponent<RawImage>().texture = texture;
    }
}
