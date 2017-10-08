using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpMpCtrl : MonoBehaviour
{
    enum ValueMode
    {
        Hp,
        Mp
    }

    [SerializeField] Text value;
    [SerializeField] ValueMode valueMode;
    [SerializeField] Image progressBar;
    Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStatus playerStatus = PlayerStatus._instance;

        if (slider.value == 0)
        {
            progressBar.enabled = false;
        }
        else
        {
            progressBar.enabled = true;
        }

        switch (valueMode)
        {
            case ValueMode.Hp:
                slider.maxValue = playerStatus.Hp;
                slider.value = playerStatus.Hp_remain;
                break;
            case ValueMode.Mp:
                slider.maxValue = playerStatus.Mp;
                slider.value = playerStatus.Mp_remain;
                break;
        }

        value.text = slider.value + "\\" + slider.maxValue;

    }
}
