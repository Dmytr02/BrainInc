using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ObjectStats")]
public class ObjectStats : ScriptableObject
{
    public Sprite sprite;
    public Sprite spriteScan;
    
    public float Mood;
    public float Immunity;
    public float Satiety;
    public float ToxinLevel;
    public float Hydration;
    public float Energy;
    
    public Sprite docImage;
    public string docName;
    public string docDescription;
    public string docOrigin;
    public string docQuote;
    
    public bool hasVirus;

    public ObjectStats Next;

}
