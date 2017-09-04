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
    public int _id;//id
    public string _name;//物品名字
    public string _icon_name;//这个名称是存储在图集中的名称
    public ObjectType _type;//物品类型
    public int _hp;//血
    public int _mp;//蓝
    public int _price_sell;//售价
    public int _price_buy;//购买价
    public int attack;
    public int def;
    public int speed;
    public DressType dressType;
    public ApplicationType applicationType;
}
