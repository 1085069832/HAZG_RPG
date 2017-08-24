using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetId(int id)
    {
        ObjectInfo objectInfo = ParseObjectInfo.Instance.GetObjectInfo(id);
        EquipmentItem[] equipmentItems = GetComponentsInChildren<EquipmentItem>();
        for (int i = 0; i < equipmentItems.Length; i++)
        {
            if (objectInfo.dressType == equipmentItems[i].dressType)
            {
                equipmentItems[i].SetInfo(objectInfo);
            }
        }
    }
}
