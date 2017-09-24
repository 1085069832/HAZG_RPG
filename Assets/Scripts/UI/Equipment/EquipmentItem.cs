using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isEnter;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        isEnter = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
        {
            if (Input.GetMouseButtonDown(1))//卸下装备
            {
                EquipmentItemGrid equipmentItemGrid = GetComponentInParent<EquipmentItemGrid>();
                Inventory.Instance.GetId(equipmentItemGrid.id);
                equipmentItemGrid.UpdatePlayerStatus(equipmentItemGrid.id, false);
                Destroy(gameObject);
            }
        }
    }
}
