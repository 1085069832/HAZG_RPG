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
    [SerializeField] List<InventoryItemGrid> items = new List<InventoryItemGrid>();//物品
    [SerializeField] Text coin;//金币
    ShowUIAnim showUIAnim;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        showUIAnim = GetComponent<ShowUIAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!showUIAnim.isClose)
            coin.text = PlayerStatus.Instance.Coin + "";


    }
    /// <summary>
    /// 拾取物品
    /// </summary>
    /// <param name="id"></param>
    public void GetId(int id)
    {

    }
}
