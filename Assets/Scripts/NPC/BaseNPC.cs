using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNPC : MonoBehaviour
{
    private void OnMouseEnter()
    {
        CursorManager.instance.SetCursorNpcTalk();
    }

    private void OnMouseExit()
    {
        CursorManager.instance.SetCursorNormal();
    }
}
