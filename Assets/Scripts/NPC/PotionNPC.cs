using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionNPC : BaseNPC
{
    [SerializeField] ShowUIAnim showUIAnim;

    protected override void OnMyMouseDown()
    {
        if (showUIAnim.isClose)
        {
            showUIAnim.OnUIOpen();
        }
        else
        {
            showUIAnim.OnUIClose();
        }
    }
}
