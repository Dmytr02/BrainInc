using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    int day = 0;
    const float dayDuration = 180;
    private float timer = dayDuration;
    public static UnityEvent<int> onDay = new UnityEvent<int>();
    private Vector3 clockHand;
    [SerializeField] private SpriteRenderer Shade;
    [SerializeField]private Sprite ShadeOpen;
    [SerializeField]private Sprite ShadeClose;
    [SerializeField]private Animator panelAnimator;
    [SerializeField] List<Vector3> calendar = new List<Vector3>();
    [SerializeField] private GameObject crossPrefab;
    
    public static List<Vector3> Calendar = new List<Vector3>();

    private void Awake()
    {
        Calendar = calendar;
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, timer / dayDuration*360);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //end day
            panelAnimator.gameObject.SetActive(true);
            Time.timeScale = 0;
            Shade.sprite = ShadeClose;
            day++;
            onDay.Invoke(day);
            timer = dayDuration;
            Instantiate(crossPrefab, calendar[day - 1], Quaternion.identity);
        }
    }
}
