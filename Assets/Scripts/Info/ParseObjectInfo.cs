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
        print(dictInfos.Count);
        print(dictInfos[1002]._icon_name);
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
