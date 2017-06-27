using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNPC : MonoBehaviour
{
    [SerializeField] GameObject task;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        task.SetActive(true);
    }
}
