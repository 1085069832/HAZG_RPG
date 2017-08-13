using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 底部菜单按钮组
/// </summary>
public class ButtomButtonGroupClick : MonoBehaviour
{
    [SerializeField]
    ShowUIAnim statusShowUIAnim;
    [SerializeField]
    ShowUIAnim bagShowUIAnim;
    [SerializeField]
    ShowUIAnim equipShowUIAnim;
    [SerializeField]
    ShowUIAnim skillShowUIAnim;
    [SerializeField]
    ShowUIAnim settingShowUIAnim;

    public void OnStatusClick()
    {
        if (statusShowUIAnim.isClose)
            statusShowUIAnim.OnUIOpen();
        else
            statusShowUIAnim.OnUIClose();
    }

    public void OnBagClick()
    {
        if (bagShowUIAnim.isClose)
            bagShowUIAnim.OnUIOpen();
        else
            bagShowUIAnim.OnUIClose();
    }

    public void OnEquipClick()
    {

    }

    public void OnSkillClick()
    {

    }

    public void OnSettingClick()
    {

    }
}
