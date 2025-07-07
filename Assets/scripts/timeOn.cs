using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeOn : MonoBehaviour
{
    [SerializeField] private GameObject report;
    public void _timeOn()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        report.SetActive(true);
        Clock.I.Shade.sprite = Clock.I.ShadeOpen;
    }
}
