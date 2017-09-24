using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] Transform content;//parent
    [SerializeField] GameObject skillItem;
    ApplicableRole applicableRole;
    public GameObject label;
    [SerializeField] Button close;

    void Awake()
    {
        close.onClick.AddListener(Close);
    }

    // Use this for initialization
    void Start()
    {
        switch (PlayerStatus.Instance.applicationType)
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

    void Close()
    {
        GetComponent<ShowUIAnim>().OnUIClose();
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
}
