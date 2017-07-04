using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarNPC : BaseNPC
{
    [SerializeField] GameObject task;//任务面板
    [SerializeField] GameObject acceptButton;
    [SerializeField] GameObject cancelButton;
    [SerializeField] GameObject okButton;
    [SerializeField] Text taskDes;
    [SerializeField] int wolfKilledCount;//已经击杀数量
    int wolfTotalCount = 10;//需击杀数量
    int taskCoin = 1000;//奖励金币
    bool isTasking;//是否在任务中
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        task.GetComponent<ShowUIAnim>().OnUIOpen();

        if (isTasking)
        {
            ShowAcceptTask();
        }
        else
        {
            ShowTask();
        }
    }

    /// <summary>
    /// 任务
    /// </summary>
    private void ShowTask()
    {
        isTasking = false;
        okButton.SetActive(false);
        acceptButton.SetActive(true);
        cancelButton.SetActive(true);
        taskDes.text = "任务：\n  击杀" + wolfTotalCount + "只小野狼" + "\n\n完成奖励：\n  " + taskCoin + "金币";
    }

    /// <summary>
    /// 接受任务
    /// </summary>
    private void ShowAcceptTask()
    {
        isTasking = true;
        okButton.SetActive(true);
        acceptButton.SetActive(false);
        cancelButton.SetActive(false);
        taskDes.text = "当前任务进度:\n  " + wolfKilledCount + "/" + wolfTotalCount + "(击杀" + wolfTotalCount + "只狼)" + "\n\n完成奖励：\n  " + taskCoin + "金币";
    }

    public void OnAcceptClick()
    {
        ShowAcceptTask();
    }

    /// <summary>
    /// 取消对话框
    /// </summary>
    public void OnCancelClick()
    {
        GameObject.Find(MyConstants.QUEST).GetComponent<ShowUIAnim>().OnUIClose();
    }
    /// <summary>
    /// 任务进度确认，未完成任务关闭对话框，完成任务则奖励金币操作
    /// </summary>
    public void OnOKClick()
    {
        if (wolfKilledCount < wolfTotalCount)
        {
            //任务中

        }
        else
        {
            //完成任务，奖励金币
            isTasking = false;
            wolfKilledCount = 0;
            PlayerStatus player = GameObject.FindGameObjectWithTag(MyConstants.PLAYER).GetComponent<PlayerStatus>();
            player.Coin += taskCoin;
            //显示新任务
            ShowTask();
        }
        GameObject.Find(MyConstants.QUEST).GetComponent<ShowUIAnim>().OnUIClose();
    }
}
