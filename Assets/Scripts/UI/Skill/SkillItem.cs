using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] RawImage icon;
    [SerializeField] Text _name;
    [SerializeField] Text _type;
    [SerializeField] Text _des;
    [SerializeField] Text _mp;
    public GameObject disenableImage;
    public static Action<RawImage> BeginDrag;
    public static Action Draging;
    public static Action<PointerEventData, Texture> EndDrag;
    public int level;

    public void SetDisenableImage(bool enable)
    {
        disenableImage.SetActive(enable);
    }

    /// <summary>
    /// 设置技能item信息
    /// </summary>
    /// <param name="skillInfo"></param>
    public void SetSkillItemInfo(SkillInfo skillInfo)
    {
        icon.texture = LoadResource(skillInfo.icon_name);
        _name.text = skillInfo.name;
        level = skillInfo.level;
        switch (skillInfo.applyType)
        {
            case ApplyType.Buff:
                _type.text = "增益";
                break;
            case ApplyType.Passive:
                _type.text = "减益";
                break;
            case ApplyType.SingleTarget:
                _type.text = "单体目标";
                break;
            case ApplyType.MultiTarget:
                _type.text = "群体目标";
                break;
        }
        _des.text = skillInfo.des;
        _mp.text = skillInfo.mp + "MP";
    }

    Texture LoadResource(string name)
    {
        Texture texture = Resources.Load<Texture>("GUI/Icon/" + name);
        return texture;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (BeginDrag != null && !disenableImage.activeSelf)
            BeginDrag(icon);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (Draging != null && !disenableImage.activeSelf)
            Draging();
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (EndDrag != null && !disenableImage.activeSelf)
            EndDrag(eventData, icon.texture);
    }
}
