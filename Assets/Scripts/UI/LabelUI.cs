﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 显示物品信息label
/// </summary>
public class LabelUI : MonoBehaviour
{

    [SerializeField] Text label;
    [SerializeField] Text content;

    public void ShowLabel(int id)
    {
        label.gameObject.SetActive(true);
        string contentText = ShowInfo(id);
        //为了在前端显示内容，设置两次
        label.text = contentText;
        content.text = contentText;
    }

    public void HideLabel()
    {
        label.gameObject.SetActive(false);
    }

    void Update()
    {
        if (label.gameObject.activeSelf)
        {
            label.transform.position = Input.mousePosition;
        }
    }

    string ShowInfo(int id)
    {
        ObjectInfo info = ParseObjectInfo.Instance.GetObjectInfo(id);
        string des = "";
        switch (info._type)
        {
            case ObjectType.Drug:
                des += "名称：" + info._name + "\n";
                des += "+HP：" + info._hp + "\n";
                des += "+MP：" + info._mp + "\n";
                des += "购买价：" + info._price_buy + "\n";
                des += "出售价：" + info._price_sell;
                break;
            case ObjectType.Equip:
                des += "名称：" + info._name + "\n";
                des += "+攻击：" + info.attack + "\n";
                des += "+防御：" + info.def + "\n";
                des += "+速度：" + info.speed + "\n";
                des += "穿戴类型：" + info.dressType + "\n";
                des += "适用类型：" + info.applicationType + "\n";
                des += "购买价：" + info._price_buy + "\n";
                des += "出售价：" + info._price_sell;
                break;
            case ObjectType.Mat:

                break;
        }

        return des;
    }
}
