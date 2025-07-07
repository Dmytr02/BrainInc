using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quote : MonoBehaviour
{
    public static Quote I;

    private void Awake()
    {
        I = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
