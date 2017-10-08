using System;
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
    [SerializeField] Button close;
    ShowUIAnim showUIAnim;
    public GameObject inventoryItem;
    [SerializeField] GameObject inventoryItemCopy;//显示拖拽的物品
    LabelUI labelUI;
    PlayerStatus playerStatus;
    int id;
    bool isPointEnter;
    [SerializeField] Equipment equipment;
    InventoryItemGrid inventoryItemGrid;
    GameObject inventoryItemGo;

    void Awake()
    {
        Instance = this;
        showUIAnim = GetComponent<ShowUIAnim>();
        labelUI = GetComponent<LabelUI>();
        playerStatus = PlayerStatus._instance;

        InventoryItem.BeginDrag += OnItemBeginDrag;
        InventoryItem.Draging += OnItemDraging;
        InventoryItem.EndDrag += OnItemEndDrag;
        InventoryItem.PointerEnter += OnItemPointerEnter;
        InventoryItem.PointerExit += OnItemPointerExit;
    }

    void OnEnable()
    {
        close.onClick.AddListener(OnCloseClick);
    }

    void OnCloseClick()
    {
        showUIAnim.OnUIClose();
    }

    void OnItemBeginDrag(Transform inventoryItem)
    {
        inventoryItemCopy.SetActive(true);
        inventoryItemCopy.GetComponent<InventoryItemCopy>().SetTexture(inventoryItem.GetComponent<RawImage>().texture);
    }

    void OnItemDraging()
    {
        inventoryItemCopy.transform.position = Input.mousePosition;
    }

    void OnItemEndDrag(Transform inventoryItem, UnityEngine.EventSystems.PointerEventData eventData)
    {
        //结束拖拽
        //判断拖拽到哪个物体上
        //有饰品的格子,自己或其他饰品
        //没饰品的格子
        //其他
        inventoryItemCopy.SetActive(false);

        GameObject eventDataGo = eventData.pointerCurrentRaycast.gameObject;
        if (!eventDataGo)
        {
            //空地
            //丢弃物品
            print("丢弃物品");
            var itemGrid = inventoryItem.GetComponentInParent<InventoryItemGrid>();
            Destroy(inventoryItem.gameObject);
            itemGrid.ClearInfo();
            return;
        }

        DragEndCheck(inventoryItem, eventDataGo.transform);
    }

    void OnItemPointerEnter(int id, InventoryItemGrid inventoryItemGrid, GameObject inventoryItemGo)
    {
        this.id = id;
        this.inventoryItemGrid = inventoryItemGrid;
        this.inventoryItemGo = inventoryItemGo;
        isPointEnter = true;
        labelUI.ShowLabel(id);
    }

    void OnItemPointerExit()
    {
        isPointEnter = false;
        labelUI.HideLabel();
    }

    void DragEndCheck(Transform inventoryItem, Transform endTransform)
    {
        if (endTransform.tag == MyConstants.INVENTORYITEMGRID)
        {
            if (endTransform.childCount == 1)
            {
                //拖拽到空grid上
                print("拖拽到空grid上");
                var oldItemGrid = inventoryItem.GetComponentInParent<InventoryItemGrid>();
                var newItemGrid = endTransform.GetComponent<InventoryItemGrid>();
                newItemGrid.SetId(oldItemGrid.id, oldItemGrid.num);
                oldItemGrid.ClearInfo();
                Destroy(inventoryItem.gameObject);
            }
        }
        else if (endTransform.tag == MyConstants.INVENTORYITEM)
        {
            //拖拽到item上
            //自己
            //其它
            if (inventoryItem == endTransform)
            {
                print("拖拽到自己");

            }
            else
            {
                print("拖拽到其它Item");
                //交换
                var oldItemGrid = inventoryItem.GetComponentInParent<InventoryItemGrid>();
                var newItemGrid = endTransform.GetComponentInParent<InventoryItemGrid>();
                oldItemGrid.id = oldItemGrid.id ^ newItemGrid.id;
                oldItemGrid.num = oldItemGrid.num ^ newItemGrid.num;

                newItemGrid.id = oldItemGrid.id ^ newItemGrid.id;
                newItemGrid.num = oldItemGrid.num ^ newItemGrid.num;

                oldItemGrid.SetId(oldItemGrid.id ^ newItemGrid.id, oldItemGrid.num ^ newItemGrid.num);
                newItemGrid.SetId(newItemGrid.id, newItemGrid.num);
            }
        }
        else
        {
            //拖拽到inventory空的地方
            print("拖拽到inventory空的地方");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //显示金币
        if (!showUIAnim.isClose)
            coin.text = playerStatus.Coin + "";

        if (Input.GetMouseButtonDown(2))
        {
            GetId(UnityEngine.Random.Range(2001, 2022));
        }

        //装备物品
        if (Input.GetMouseButtonDown(1))
        {
            AddEquipment();
        }
    }

    /// <summary>
    /// 添加到装备
    /// </summary>
    void AddEquipment()
    {
        if (isPointEnter)
        {
            if (inventoryItemGrid.num > 0)
            {
                bool isAddEquip = equipment.SetId(id);
                if (isAddEquip)
                {
                    inventoryItemGrid.AddNum(-1);
                    if (inventoryItemGrid.num == 0)
                    {
                        Destroy(inventoryItemGo);
                        inventoryItemGrid.ClearInfo();
                        labelUI.HideLabel();
                        isPointEnter = false;
                    }
                }
            }
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
                grid.SetId(id);
            }
            else
            {
                print("没有多的格子了");
            }
        }
    }

    /// <summary>
    /// 购买
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="price">单件价格</param>
    /// <param name="count">购买数量</param>
    /// <returns></returns>
    public bool BuyObj(int id, int price, int count)
    {
        if (price * count <= playerStatus.Coin)
        {
            for (int i = 0; i < count; i++)
            {
                GetId(id);
            }
            playerStatus.Coin -= price * count;
            return true;
        }
        return false;
    }
}
