using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventController : MonoBehaviour
{
    private List<int> eventDays =  new List<int>();
    [SerializeField] private List<eventData> eventList;
    public eventData eventData;
    
    private void Start()
    {
        for (int i = 4; i < 31; i += Random.Range(5, 7))
        {
            eventDays.Add(i);
        }
    }

    void onNextDay(int day)
    {
        if (eventDays.Contains(day))
        {
            eventDays.Remove(day);
            int index = Random.Range(0, eventList.Count);
            if (eventList[index].isCheck())
            {
                eventData =  eventList[index];
            }
            eventList.RemoveAt(index);
        }
    }
}

[Serializable]
public class eventData // от него наследоватся
{
    public float Mood;
    public float Immunity;
    public float Satiety;
    public float ToxinLevel;
    public float Hydration;
    public float Energy;

    public virtual bool isCheck() // это переписать если надо будет добавить условие 
    {
        return true;
    }
}
