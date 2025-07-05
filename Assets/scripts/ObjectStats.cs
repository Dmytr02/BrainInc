using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ObjectStats")]
public class ObjectStats : ScriptableObject
{
    public float Mood;
    public float Immunity;
    public float Satiety;
    public float ToxinLevel;
    public float Hydration;
}
