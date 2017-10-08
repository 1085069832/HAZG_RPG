using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillShortCutItem : MonoBehaviour
{

    public void SetTexture(Texture texture)
    {
        GetComponent<RawImage>().texture = texture;
    }
}
