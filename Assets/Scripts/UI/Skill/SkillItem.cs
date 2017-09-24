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
    Skill skill;

    void Awake()
    {
        skill = GetComponentInParent<Skill>();
    }

    /// <summary>
    /// 设置技能item信息
    /// </summary>
    /// <param name="skillInfo"></param>
    public void SetSkillItemInfo(SkillInfo skillInfo)
    {
        icon.texture = LoadResource(skillInfo.icon_name);
        _name.text = skillInfo.name;
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
        skill.label.SetActive(true);
        skill.label.GetComponent<RawImage>().texture = icon.texture;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        skill.label.transform.position = Input.mousePosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        skill.label.SetActive(false);
    }
}
