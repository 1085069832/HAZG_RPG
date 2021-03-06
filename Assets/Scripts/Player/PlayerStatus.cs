﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色状态
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus _instance;
    private int grade = 1;
    private int hp = 100;
    private int mp = 100;
    private int hp_remain = 100;
    private int mp_remain = 100;

    [SerializeField] int coin = 1000;//金币
    [SerializeField] int level = 1;

    private int attack = 20;
    private int attack_plus = 0;
    private int def = 20;
    private int def_plus = 0;
    private int speed = 20;
    private int speed_plus = 0;
    [SerializeField]
    int point_remain = 0;//剩余点数

    public ApplicationType applicationType;

    private void Awake()
    {
        _instance = this;
    }

    public int Coin
    {
        get
        {
            return coin;
        }

        set
        {
            coin = value;
        }
    }

    public int Grade
    {
        get
        {
            return grade;
        }

        set
        {
            grade = value;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Mp
    {
        get
        {
            return mp;
        }

        set
        {
            mp = value;
        }
    }

    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int Attack_plus
    {
        get
        {
            return attack_plus;
        }

        set
        {
            attack_plus = value;
        }
    }

    public int Def
    {
        get
        {
            return def;
        }

        set
        {
            def = value;
        }
    }

    public int Def_plus
    {
        get
        {
            return def_plus;
        }

        set
        {
            def_plus = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public int Speed_plus
    {
        get
        {
            return speed_plus;
        }

        set
        {
            speed_plus = value;
        }
    }

    public int Point_remain
    {
        get
        {
            return point_remain;
        }

        set
        {
            point_remain = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int Hp_remain
    {
        get
        {
            return hp_remain;
        }

        set
        {
            hp_remain = value;
        }
    }

    public int Mp_remain
    {
        get
        {
            return mp_remain;
        }

        set
        {
            mp_remain = value;
        }
    }
}
