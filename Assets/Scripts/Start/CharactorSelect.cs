using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] GameObject[] charactorPrefabs;
    GameObject[] charactorGameObjects;//保存角色
    [SerializeField] InputField inputName;
    int charactorIndex = 0;//角色索引
    // Use this for initialization
    void Start()
    {
        charactorGameObjects = new GameObject[charactorPrefabs.Length];
        for (int i = 0; i < charactorPrefabs.Length; i++)
        {
            charactorGameObjects[i] = Instantiate(charactorPrefabs[i], transform.position, transform.rotation);
        }
        CharatorShow();
    }

    /// <summary>
    /// 角色的显示
    /// </summary>
    private void CharatorShow()
    {
        charactorGameObjects[charactorIndex].SetActive(true);
        for (int i = 0; i < charactorGameObjects.Length; i++)
        {
            if (i != charactorIndex)
            {
                charactorGameObjects[i].SetActive(false);
            }
        }
    }
    /// <summary>
    /// 下个角色
    /// </summary>
    public void NextCharator()
    {
        charactorIndex++;
        charactorIndex %= charactorPrefabs.Length;
        CharatorShow();
    }
    /// <summary>
    /// 上个角色
    /// </summary>
    public void PrevCharator()
    {
        charactorIndex--;
        if (charactorIndex == -1)
        {
            charactorIndex = charactorPrefabs.Length - 1;
        }
        CharatorShow();
    }
    /// <summary>
    /// 点击OK,进入游戏场景
    /// </summary>
    public void ClickOK()
    {
        PlayerPrefs.SetString(MyConstants.INPUTNAME, inputName.text);
        Debug.Log(PlayerPrefs.GetString(MyConstants.INPUTNAME));
        //进入游戏

    }
}
