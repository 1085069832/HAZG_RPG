using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUIClick : MonoBehaviour
{
   
    public void OnCloseClick()
    {
        transform.GetComponentInParent<ShowUIAnim>().OnUIClose();
    }
}
