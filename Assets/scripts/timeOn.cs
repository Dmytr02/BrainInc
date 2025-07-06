using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeOn : MonoBehaviour
{
    public void _timeOn()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Clock.I.Shade.sprite = Clock.I.ShadeOpen;
    }
}
