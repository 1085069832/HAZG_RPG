using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    [SerializeField] Button close;
    [SerializeField] GameObject equipmentItem;

    void OnEnable()
    {
        close.onClick.AddListener(OnCloseClick);
    }

    void OnCloseClick()
    {
        GetComponent<ShowUIAnim>().OnUIClose();
    }

    public bool SetId(int id)
    {
        ObjectInfo objectInfo = ParseObjectInfo.Instance.GetObjectInfo(id);
        EquipmentItemGrid[] equipmentItemGrids = GetComponentsInChildren<EquipmentItemGrid>();
        for (int i = 0; i < equipmentItemGrids.Length; i++)
        {
            if (objectInfo.applicationType == PlayerStatus._instance.applicationType || objectInfo.applicationType == ApplicationType.Common)
            {
                if (objectInfo.dressType == equipmentItemGrids[i].dressType)
                {
                    return equipmentItemGrids[i].SetInfo(objectInfo, equipmentItem);
                }
            }
        }
        return false;
    }
}
