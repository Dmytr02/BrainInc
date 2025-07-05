using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ObjectsController : MonoBehaviour
{
    [SerializeField] private Object objectPrefab;
    private Object objectActual;
    Slider MoodSlider;
    [SerializeField] private Slider sliderMood;
    [SerializeField] private Slider sliderImmunity;
    [SerializeField] private Slider sliderSatiety;
    [SerializeField] private Slider sliderToxinLevel;
    [SerializeField] private Slider sliderHydration;
    
    [SerializeField] private ObjectStats[]  objectStats;

    private static ObjectsController I;

    private void Awake()
    {
        I = this;
    }

    void Start()
    {
        createObject();
        sliderMood.value = 0.5f;
        sliderImmunity.value = 0.5f;
        sliderSatiety.value = 0.5f;
        sliderToxinLevel.value = 0.5f;
        sliderHydration.value = 0.5f;
    }

    public static void createObject()
    {
        I.objectActual = Instantiate(I.objectPrefab);
        I.objectActual.stats = I.objectStats[Random.Range(0, I.objectStats.Length)];
    }

    public void onApproved()
    {
        I.objectActual.onApproved();
        sliderMood.value += I.objectActual.stats.Mood;
        sliderImmunity.value += I.objectActual.stats.Immunity;
        sliderSatiety.value += I.objectActual.stats.Satiety;
        sliderToxinLevel.value += I.objectActual.stats.ToxinLevel;
        sliderHydration.value += I.objectActual.stats.Hydration;
        
        createObject();
    }
    
    public void onRejection()
    {
        I.objectActual.onRejection();
        createObject();
    }
}
