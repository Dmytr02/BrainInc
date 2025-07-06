using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventController : MonoBehaviour
{
    private List<int> eventDays =  new List<int>();
    [SerializeField] private List<eventData> eventList;
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private ActionButon actionLearningForeignLanguageButon;
    [SerializeField] private ActionButon actionWorkOnTheProjectButon;
    [SerializeField] private ActionButon actionGoingToTheGymButon;
    [SerializeField] private ActionButon actionDateButon;
    [SerializeField] private ActionButon actionJoggingButon;
    public eventData eventData;
    
    private void Start()
    {
        for (int i = 4; i < 31; i += Random.Range(5, 7))
        {
            eventDays.Add(i);
            Instantiate(circlePrefab, Clock.Calendar[i], Quaternion.identity);
        }
        Clock.onDay.AddListener(onNextDay);
        
        eventList.Add(new eventData(2, 1, 1, 1, 1, 0.5f, 0.5f, 0.5f, 1, 1, 1, 0.5f, () => actionLearningForeignLanguageButon.counter>=4));
        eventList.Add(new eventData(2, 1, 0.5f, 1, 1, 0.5f, 0.5f, 0.5f, 1, 1, 1, 0.5f, () => actionLearningForeignLanguageButon.counter>=4));
        eventData = new eventData();
    }

    void onNextDay(int day)
    {
        if (eventDays.Contains(day))
        {
            eventDays.Remove(day);
            int index = Random.Range(0, eventList.Count);
            if (eventList[index].isCheck.Invoke())
            {
                eventData = eventList[index];
            }
            else
            {
                eventData = eventList[index];
                eventData.Mood = eventData.elseMood;
                eventData.Immunity =  eventData.elseImmunity;
                eventData.Satiety =  eventData.elseSatiety;
                eventData.ToxinLevel =  eventData.elseToxinLevel;
                eventData.Hydration =  eventData.elseHydration;
                eventData.Energy =  eventData.elseEnergy;
            }
            eventList.RemoveAt(index);
        }
    }
}

[Serializable]
public class eventData // от него наследоватся
{
    public float Mood = 1;
    public float Immunity = 1;
    public float Satiety = 1;
    public float ToxinLevel = 1;
    public float Hydration = 1;
    public float Energy = 1;
    public float elseMood = 1;
    public float elseImmunity = 1;
    public float elseSatiety = 1;
    public float elseToxinLevel = 1;
    public float elseHydration = 1;
    public float elseEnergy = 1;
    public Func<bool> isCheck = () => true;

    public eventData()
    {
        
    }

    public eventData(float Mood,  float Immunity, float Satiety, float ToxinLevel, float Hydration, float Energy, float elseMood, float elseImmunity, float elseSatiety, float elseToxinLevel, float elseHydration, float elseEnergy , Func<bool> isCheck)
    {
        this.Mood = Mood;
        this.Immunity = Immunity;
        this.Satiety = Satiety;
        this.ToxinLevel = ToxinLevel;
        this.Hydration = Hydration;
        this.Energy = Energy;
        this.elseMood = elseMood;
        this.elseImmunity = elseImmunity;
        this.elseSatiety = elseSatiety;
        this.elseToxinLevel = elseToxinLevel;
        this.elseHydration = elseHydration;
        this.elseEnergy = elseEnergy;
        this.isCheck = isCheck;
    }
}
