using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionButon : MonoBehaviour
{
    [SerializeField] private ActionStats _action;
    
    [SerializeField] private Slider Mood;
    [SerializeField] private Slider Immunity;
    [SerializeField] private Slider Satiety;
    [SerializeField] private Slider ToxinLevel;
    [SerializeField] private Slider Hydration;
    [SerializeField] private Slider Energy;

    public int counter;
    public UnityEvent<int> onUseAction =  new UnityEvent<int>();

    [SerializeField] private TMP_Text doit;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text description;

    private void Start()
    {
        description.text = (_action.Mood != 0 ? $"{_action.Mood} Mood\n":"") + (_action.Immunity != 0 ? $"{_action.Immunity} Immunity\n":"") + (_action.Satiety != 0 ? $"{_action.Satiety} Satiety\n":"") + (_action.ToxinLevel != 0 ? $"{_action.ToxinLevel} ToxinLevel\n":"") + (_action.Hydration != 0 ? $"{_action.Hydration} Hydration\n":"") + $"{_action.Energy} Energy";;
    }

    private void Update()
    {
        if (-_action.Energy > Energy.value)
        {
            doit.color = Color.gray;
            name.color = Color.gray;
            description.color = Color.gray;
        }
        else
        {
            doit.color = Color.black;
            name.color = Color.black;
            description.color = Color.black;
        }
    }

    public void onClict()
    {
        if (_action.Energy + Energy.value > 0)
        {
            counter++;
            onUseAction.Invoke(counter);
            Mood.value += _action.Mood;
            Immunity.value += _action.Immunity;
            Satiety.value += _action.Satiety;
            ToxinLevel.value += _action.ToxinLevel;
            Hydration.value += _action.Hydration;
            Energy.value += _action.Energy;
        }
        else
        {
            Debug.Log("Low Energy");
        }
    }
}
