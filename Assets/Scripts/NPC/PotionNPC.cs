using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionNPC : BaseNPC
{
    [SerializeField] ShowUIAnim showUIAnim;

    private void OnMouseDown()
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
