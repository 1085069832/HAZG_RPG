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
