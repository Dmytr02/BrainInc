using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ActionStats")]
public class ActionStats : ScriptableObject
{
    public float Mood;
    public float Immunity;
    public float Satiety;
    public float ToxinLevel;
    public float Hydration;
    public float Energy;
}
