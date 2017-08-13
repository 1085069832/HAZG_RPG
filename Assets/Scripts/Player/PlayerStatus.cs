using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色状态
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance;
    public int grade = 1;
    public int hp = 100;
    public int mp = 100;
    [SerializeField] int coin = 200;//金币

    public int attack = 20;
    public int attack_plus = 0;
    public int def = 20;
    public int def_plus = 0;
    public int speed = 20;
    public int speed_plus = 0;

    public int point_remain = 0;//剩余点数

    private void Awake()
    {
        Instance = this;
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
}
