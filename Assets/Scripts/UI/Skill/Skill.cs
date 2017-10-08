using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] Transform content;//parent
    [SerializeField] GameObject skillItem;
    ApplicableRole applicableRole;
    [SerializeField] GameObject label;
    [SerializeField] Button close;
    [SerializeField] GameObject skillShortCutItem;
    ShowUIAnim showUIAnim;

    void Awake()
    {
        SkillItem.BeginDrag += BeginDrag;
        SkillItem.Draging += Draging;
        SkillItem.EndDrag += EndDrag;
        showUIAnim = GetComponentInChildren<ShowUIAnim>();
        close.onClick.AddListener(Close);
    }

    void BeginDrag(RawImage icon)
    {
        label.SetActive(true);
        label.GetComponent<RawImage>().texture = icon.texture;
    }

    void Draging()
    {
        label.transform.position = Input.mousePosition;
    }

    void EndDrag(PointerEventData eventData, Texture texture)
    {
        label.SetActive(false);

        //拖拽到快捷栏
        GameObject go = eventData.pointerCurrentRaycast.gameObject;
        if (go && go.tag == "SkillShortCut")
        {
            if (go.transform.childCount == 0)
            {
                GameObject skillShortCutItemGo = Instantiate(skillShortCutItem, go.transform);
                skillShortCutItemGo.GetComponent<SkillShortCutItem>().SetTexture(texture);
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        switch (PlayerStatus._instance.applicationType)
        {
            case ApplicationType.Magician:
                applicableRole = ApplicableRole.Magician;
                break;
            case ApplicationType.Swordman:
                applicableRole = ApplicableRole.Swordman;
                break;
        }
        ListSkillItem();
    }

    void Update()
    {
        if (!showUIAnim.isClose)
            UpdateSkill();
    }

    void Close()
    {
        showUIAnim.OnUIClose();
    }

    /// <summary>
    /// skillitem
    /// </summary>
    void ListSkillItem()
    {
        switch (applicableRole)
        {
            case ApplicableRole.Swordman:
                for (int i = 4001; i < 4007; i++)
                {
                    SkillInfo skillInfo = ParseSkillInfo._instance.GetSkillInfoById(i);
                    GameObject skillItemGo = Instantiate(skillItem, content);
                    skillItemGo.GetComponent<SkillItem>().SetSkillItemInfo(skillInfo);
                }
                break;

            case ApplicableRole.Magician:

                for (int i = 5001; i < 5007; i++)
                {
                    SkillInfo skillInfo = ParseSkillInfo._instance.GetSkillInfoById(i);
                    GameObject skillItemGo = Instantiate(skillItem, content);
                    skillItemGo.GetComponent<SkillItem>().SetSkillItemInfo(skillInfo);
                }
                break;
        }
    }

    /// <summary>
    /// 更新技能是否可用
    /// </summary>
    void UpdateSkill()
    {
        SkillItem[] skillItems = content.GetComponentsInChildren<SkillItem>();

        for (int i = 0; i < skillItems.Length; i++)
        {
            if (PlayerStatus._instance.Level <= skillItems[i].level)
            {
                skillItems[i].SetDisenableImage(true);
            }
            else
            {
                skillItems[i].SetDisenableImage(false);
            }
        }
    }
}
