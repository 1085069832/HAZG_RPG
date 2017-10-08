using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugShop : MonoBehaviour
{
    [SerializeField] Button close;
    ShowUIAnim showUIAnim;
    [SerializeField] Button buySmallRedDrug;
    [SerializeField] Button buyBigRedDrug;
    [SerializeField] Button buyBlueDrug;
    [SerializeField] Button ok;
    [SerializeField] InputField count;
    [SerializeField] GameObject buyDetail;
    [SerializeField] Inventory inventory;
    PlayerStatus playerStatus;
    int buyCount = 1;//购买数量
    int price;//价格
    int id;//id

    // Use this for initialization
    void Start()
    {
        showUIAnim = GetComponent<ShowUIAnim>();
        playerStatus = PlayerStatus._instance;
    }

    private void OnEnable()
    {
        close.onClick.AddListener(OnCloseShop);
        buySmallRedDrug.onClick.AddListener(OnBuySmallRedDrug);
        buyBigRedDrug.onClick.AddListener(OnBuyBigRedDrug);
        buyBlueDrug.onClick.AddListener(OnBuyBlueDrug);
        ok.onClick.AddListener(OnConfirmBuy);
        count.onValueChanged.AddListener(BuyCount);
    }

    void BuyCount(string count)
    {
        buyCount = int.Parse(count);
    }

    /// <summary>
    /// 确认购买
    /// </summary>
    void OnConfirmBuy()
    {
        bool isBuy = inventory.BuyObj(id, price, buyCount);
        if (isBuy)
            buyDetail.SetActive(false);
        else
            print("金币不足");
    }

    void OnBuyBlueDrug()
    {
        BuyDrugById(1003);
    }

    void OnBuyBigRedDrug()
    {
        BuyDrugById(1002);
    }

    void OnBuySmallRedDrug()
    {
        BuyDrugById(1001);
    }

    void BuyDrugById(int id)
    {
        this.id = id;
        buyDetail.SetActive(true);
        count.text = "1";
        switch (id)
        {
            case 1001:
                price = 60;
                break;
            case 1002:
                price = 100;
                break;
            case 1003:
                price = 80;
                break;
        }
    }

    void OnCloseShop()
    {
        showUIAnim.OnUIClose();
    }
}
