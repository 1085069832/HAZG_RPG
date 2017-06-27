using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIClick : MonoBehaviour
{

    public void NewGame()
    {
        PlayerPrefs.SetInt(MyConstants.STARTGAMEDATA, 0);
        //创建角色场景

    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt(MyConstants.STARTGAMEDATA, 1);
        //进入保存的场景

    }
}
