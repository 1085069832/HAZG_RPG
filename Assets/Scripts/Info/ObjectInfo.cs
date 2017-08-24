using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品类型
/// </summary>
public enum ObjectType
{
    Drug, Equip, Mat
}

public enum DressType
{
    Headgear,
    Armor,
    RightHand,
    LeftHand,
    Shoe,
    Accessory
}

public enum ApplicationType
{
    Swordman,
    Magician,
    Common
}

/// <summary>
/// 物品实体类
/// </summary>
public class ObjectInfo
{

    [HideInInspector]
    public int _id;//id
    [HideInInspector]
    public string _name;//物品名字
    [HideInInspector]
    public string _icon_name;//这个名称是存储在图集中的名称
    [HideInInspector]
    public ObjectType _type;//物品类型
    [HideInInspector]
    public int _hp;//血
    [HideInInspector]
    public int _mp;//蓝
    [HideInInspector]
    public int _price_sell;//售价
    [HideInInspector]
    public int _price_buy;//购买价
    [HideInInspector]
    public int attack;
    [HideInInspector]
    public int def;
    [HideInInspector]
    public int speed;
    [HideInInspector]
    public DressType dressType;
    [HideInInspector]
    public ApplicationType applicationType;
}
