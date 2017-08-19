using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField] Text attack;
    [SerializeField] Button attackPlusButton;
    [SerializeField] Text def;
    [SerializeField] Button defPlusButton;
    [SerializeField] Text speed;
    [SerializeField] Button speedPlusButton;
    [SerializeField] Text pointRemainText;
    [SerializeField] Text summaryText;
    [SerializeField] Button close;
    PlayerStatus playerStatus;
    ShowUIAnim showUIAnim;
    int attackPlus;
    int defPlus;
    int speedPlus;

    void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag(MyConstants.PLAYER).GetComponent<PlayerStatus>();
        showUIAnim = GetComponent<ShowUIAnim>();
    }

    void OnEnable()
    {
        attackPlusButton.onClick.AddListener(AddAttackPlus);
        defPlusButton.onClick.AddListener(AddDefPlus);
        speedPlusButton.onClick.AddListener(AddSpeedPlus);
        close.onClick.AddListener(OnCloseClick);
    }

    void OnDisable()
    {
        attackPlusButton.onClick.RemoveAllListeners();
        defPlusButton.onClick.RemoveAllListeners();
        speedPlusButton.onClick.RemoveAllListeners();
        close.onClick.RemoveAllListeners();
    }

    void OnCloseClick()
    {
        showUIAnim.OnUIClose();
    }

    void AddSpeedPlus()
    {
        speedPlus++;
        playerStatus.Speed++;
        playerStatus.Point_remain--;
    }

    void AddDefPlus()
    {
        defPlus++;
        playerStatus.Def++;
        playerStatus.Point_remain--;
    }

    void AddAttackPlus()
    {
        attackPlus++;
        playerStatus.Attack++;
        playerStatus.Point_remain--;
    }

    private void Update()
    {
        if (!showUIAnim.isClose)
        {
            SetPlayerStatus();
        }
    }

    void SetPlayerStatus()
    {
        attack.text = playerStatus.Attack - attackPlus + "(+" + attackPlus + ")";
        def.text = playerStatus.Def - defPlus + "(+" + defPlus + ")";
        speed.text = playerStatus.Speed - speedPlus + "(+" + speedPlus + ")";
        pointRemainText.text = playerStatus.Point_remain + "";
        summaryText.text = "攻击：" + playerStatus.Attack + " 防御：" + playerStatus.Def + " 速度：" + playerStatus.Speed;
        if (playerStatus.Point_remain > 0)
        {
            attackPlusButton.gameObject.SetActive(true);
            defPlusButton.gameObject.SetActive(true);
            speedPlusButton.gameObject.SetActive(true);
        }
        else
        {
            attackPlusButton.gameObject.SetActive(false);
            defPlusButton.gameObject.SetActive(false);
            speedPlusButton.gameObject.SetActive(false);
        }
    }
}
