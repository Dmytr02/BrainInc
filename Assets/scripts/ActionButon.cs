using System.Collections;
using System.Collections.Generic;
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
