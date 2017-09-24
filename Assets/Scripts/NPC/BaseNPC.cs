using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseNPC : MonoBehaviour
{
    void OnMouseEnter()
    {
        CursorManager.instance.SetCursorNpcTalk();
    }

    void OnMouseExit()
    {
        CursorManager.instance.SetCursorNormal();
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            OnMyMouseDown();
        }
    }

    protected abstract void OnMyMouseDown();

}
