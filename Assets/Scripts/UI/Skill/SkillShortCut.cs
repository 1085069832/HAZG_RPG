using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShortCut : MonoBehaviour
{
    [SerializeField] KeyCode keyCode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(keyCode))
        {
            if (transform.childCount > 0)
                print(keyCode);
        }
    }
}
