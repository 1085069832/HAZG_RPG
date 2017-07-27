using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 背包
/// </summary>
public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField] List<InventoryItem> items = new List<InventoryItem>();//物品
    [SerializeField] Text coin;//金币

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coin.text = PlayerStatus.Instance.Coin + "";
    }
}
 