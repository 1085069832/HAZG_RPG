using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 光标管理类
/// </summary>
public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;
    [SerializeField] Texture2D cursorNormal;
    [SerializeField] Texture2D cursorAttack;
    [SerializeField] Texture2D cursorLockTarget;
    [SerializeField] Texture2D cursorNpcTalk;
    [SerializeField] Texture2D cursorPick;

    Vector2 hotspot = Vector2.zero;
    CursorMode mode = CursorMode.Auto;

    private void Awake()
    {
        instance = this;
    }

    public void SetCursorNpcTalk()
    {
        Cursor.SetCursor(cursorNpcTalk, hotspot, mode);
    }

    public void SetCursorNormal()
    {
        Cursor.SetCursor(cursorNormal, hotspot, mode);
    }

    public void SetCursorAttack()
    {
        Cursor.SetCursor(cursorAttack, hotspot, mode);
    }

    public void SetCursorLockTarget()
    {
        Cursor.SetCursor(cursorLockTarget, hotspot, mode);
    }

    public void SetCursorPick()
    {
        Cursor.SetCursor(cursorPick, hotspot, mode);
    }

}
