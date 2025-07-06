using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour
{
    private void OnMouseDown()
    {
        ObjectsController.I.documentPanel.SetActive(true);
    }

    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }
}
