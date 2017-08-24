using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItem : MonoBehaviour
{

    public DressType dressType;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// id设置图片
    /// </summary>
    /// <param name="id"></param>
    public void SetInfo(ObjectInfo info)
    {
        Texture texture = Resources.Load<Texture>("GUI/Icon/" + info._icon_name);
        GetComponent<RawImage>().texture = texture;
    }
}
