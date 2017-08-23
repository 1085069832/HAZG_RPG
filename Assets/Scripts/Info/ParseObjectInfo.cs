using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 解析text物品数据
/// </summary>
public class ParseObjectInfo : MonoBehaviour
{
    public static ParseObjectInfo Instance;
    [SerializeField] TextAsset gameInfo;//text数据
    Dictionary<int, ObjectInfo> dictInfos = new Dictionary<int, ObjectInfo>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ParseText();
        //print(dictInfos.Count);
        //print(dictInfos[1002]._icon_name);
    }

    public ObjectInfo GetObjectInfo(int id)
    {
        return dictInfos[id];
    }

    /// <summary>
    /// 解析数据
    /// </summary>
    private void ParseText()
    {
        string info = gameInfo.text;
        string[] oneLineInfos = info.Split('\n');
        foreach (string lineInfo in oneLineInfos)
        {
            ObjectInfo objectInfo = new ObjectInfo();
            string[] values = lineInfo.Split(',');
            objectInfo._id = int.Parse(values[0]);
            objectInfo._name = values[1];
            objectInfo._icon_name = values[2];
            string type = values[3];
            switch (type)
            {
                case "Drug":
                    objectInfo._type = ObjectInfo.ObjectType.Drug;
                    objectInfo._hp = int.Parse(values[4]);
                    objectInfo._mp = int.Parse(values[5]);
                    objectInfo._price_sell = int.Parse(values[6]);
                    objectInfo._price_buy = int.Parse(values[7]);
                    break;
                case "Equip":
                    objectInfo._type = ObjectInfo.ObjectType.Equip;
                    objectInfo.attack = int.Parse(values[4]);
                    objectInfo.def = int.Parse(values[5]);
                    objectInfo.speed = int.Parse(values[6]);
                    switch (values[7])
                    {
                        case "Headgear":
                            objectInfo.dressType = ObjectInfo.DressType.Headgear;
                            break;
                        case "Armor":
                            objectInfo.dressType = ObjectInfo.DressType.Armor;
                            break;
                        case "RightHand":
                            objectInfo.dressType = ObjectInfo.DressType.RightHand;
                            break;
                        case "LeftHand":
                            objectInfo.dressType = ObjectInfo.DressType.LeftHand;
                            break;
                        case "Shoe":
                            objectInfo.dressType = ObjectInfo.DressType.Shoe;
                            break;
                        case "Accessory":
                            objectInfo.dressType = ObjectInfo.DressType.Accessory;
                            break;
                    }

                    switch (values[8])
                    {
                        case "Swordman":
                            objectInfo.applicationType = ObjectInfo.ApplicationType.Swordman;
                            break;
                        case "Magician":
                            objectInfo.applicationType = ObjectInfo.ApplicationType.Magician;
                            break;
                        case "Common":
                            objectInfo.applicationType = ObjectInfo.ApplicationType.Common;
                            break;
                    }
                    objectInfo._price_sell = int.Parse(values[9]);
                    objectInfo._price_buy = int.Parse(values[10]);

                    break;
                case "Mat":
                    objectInfo._type = ObjectInfo.ObjectType.Mat;
                    break;
                default:
                    break;
            }
            dictInfos.Add(objectInfo._id, objectInfo);
        }
    }
}
