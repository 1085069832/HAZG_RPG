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
    [SerializeField] GameObject inventoryItem;
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
        //显示金币
        if (!showUIAnim.isClose)
            coin.text = PlayerStatus.Instance.Coin + "";

        if (Input.GetMouseButtonDown(1))
        {
            GetId(Random.Range(1001, 1004));
        }
    }
    /// <summary>
    /// 拾取物品
    /// </summary>
    /// <param name="id"></param>
    public void GetId(int id)
    {
        //查找是否存在该物品
        //存在 num+1
        //不存在 查找空的方格存放进去
        InventoryItemGrid grid = null;

        foreach (InventoryItemGrid temp in items)
        {
            if (temp.id == id)
            {
                grid = temp; break;
            }
        }

        if (grid != null)
        {
            //存在
            grid.AddNum();
        }
        else
        {
            //不存在,查找空的方格
            foreach (InventoryItemGrid temp in items)
            {
                if (temp.id == 0)
                {
                    grid = temp; break;
                }
            }

            if (grid != null)
            {
                //有足够的格子
                GameObject itemGo = Instantiate(inventoryItem, grid.transform);
                grid.SetId(id);
            }
        }
    }
}
