using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSplash : MonoBehaviour
{

    [SerializeField] Image bgImage;//背景
    [SerializeField] RawImage titleImage;//标题
    [SerializeField] RawImage pressToStart;//任意键开始
    [SerializeField] float pressAlphaDuration = 1f;
    [SerializeField] GameObject selectGame;
    // Use this for initialization
    void Start()
    {
        titleImage.CrossFadeAlpha(0, 0, false);
        pressToStart.CrossFadeAlpha(0, 0, false);

        bgImage.CrossFadeAlpha(0, 7, false);
        titleImage.CrossFadeAlpha(1, 7, false);
        StartCoroutine("StartToShow");
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            selectGame.SetActive(true);
            pressToStart.gameObject.SetActive(false);
        }
    }

    IEnumerator StartToShow()
    {
        pressToStart.CrossFadeAlpha(1, pressAlphaDuration, false);
        yield return new WaitForSeconds(pressAlphaDuration);
        pressToStart.CrossFadeAlpha(0, pressAlphaDuration, false);
        yield return new WaitForSeconds(pressAlphaDuration);
        StartCoroutine("StartToShow");
    }
}
