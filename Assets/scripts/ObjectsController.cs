using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ObjectsController : MonoBehaviour
{
    [SerializeField] private Object objectPrefab;
    private Object objectActual;
    Slider MoodSlider;
    [SerializeField] EventController eventController;
    [SerializeField] private Slider sliderMood;
    [SerializeField] private Slider sliderImmunity;
    [SerializeField] private Slider sliderSatiety;
    [SerializeField] private Slider sliderToxinLevel;
    [SerializeField] private Slider sliderHydration;
    [SerializeField] private Slider sliderEnergy;


    [SerializeField] public GameObject documentPanel;
    [SerializeField] private Image docImage;
    [SerializeField] private TMP_Text docNameText;
    [SerializeField] private TMP_Text docDescriptionText;
    [SerializeField] private TMP_Text docStatsText;
    
    [SerializeField] private List<ObjectStats>  objectStats;
    
    [SerializeField] private Material scanMaterial;
    
    [SerializeField] private GameObject QuoteObj;
    [SerializeField] private TMP_Text QuoteText;

    public static ObjectsController I;

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
        
        /*sliderMood.interactable = false;
        sliderImmunity.interactable = false;
        sliderSatiety.interactable = false;
        sliderToxinLevel.interactable = false;
        sliderHydration.interactable = false;*/
    }

    private void Update()
    {
        sliderMood.value -= 0.00002f;
        sliderImmunity.value -= 0.00002f;
        sliderSatiety.value -=0.00002f;
        sliderToxinLevel.value -= 0.00002f;
        sliderHydration.value -= 0.00002f;
        sliderEnergy.value -= 0.00002f;
    }

    public static void createObject()
    {
        I.objectPrefab.stats = I.objectStats[Random.Range(0, I.objectStats.Count)];
        I.objectPrefab.Quote = I.QuoteObj;
        I.objectActual = Instantiate(I.objectPrefab);
        
        I.scanMaterial.SetTexture("_IntersectTex", I.objectActual.stats.spriteScan.texture);

        I.QuoteText.text = I.objectActual.stats.docQuote;
        I.docImage.sprite = I.objectActual.stats.docImage;
        I.docNameText.text = "Name: " + I.objectActual.stats.docName + "\n\nOrigin: " + I.objectActual.stats.docOrigin;
        I.docDescriptionText.text = "Description: " + I.objectActual.stats.docDescription;
        string s = "Stats: \n";
        if (I.objectActual.stats.Mood != 0)
        {
            if (I.objectActual.stats.Mood > 0)
                s += I.objectActual.stats.Mood + " Mood\n";
            else s += "<color=#992222>" + I.objectActual.stats.Mood + " Mood</color>\n";
        }if (I.objectActual.stats.Immunity != 0)
        {
            if (I.objectActual.stats.Immunity < 0)
                s += "<color=#992222>" + I.objectActual.stats.Immunity + " Immunity</color>\n";
            else s += I.objectActual.stats.Immunity + " Immunity\n";
        }if (I.objectActual.stats.Satiety != 0)
        {
            if (I.objectActual.stats.Satiety < 0)
                s += "<color=#992222>" + I.objectActual.stats.Satiety + " Satiety\n</color>";
            else s += I.objectActual.stats.Satiety +  " Satiety\n";
        }if (I.objectActual.stats.ToxinLevel != 0)
        {
            if (I.objectActual.stats.ToxinLevel < 0)
                s += "<color=#992222>" + I.objectActual.stats.ToxinLevel + " Toxin Level\n</color>";
            else s += I.objectActual.stats.ToxinLevel + " Toxin Level\n";
        }if (I.objectActual.stats.Hydration != 0)
        {
            if (I.objectActual.stats.Hydration < 0)
                s += "<color=#992222>" + I.objectActual.stats.Hydration + " Hydration\n</color>";
            else s += I.objectActual.stats.Hydration + " Hydration\n";
        }if (I.objectActual.stats.Energy != 0)
        {
            if (I.objectActual.stats.Energy < 0)
                s += "<color=#992222>" + I.objectActual.stats.Energy + " Energy\n</color>";
            else s += I.objectActual.stats.Energy + " Energy\n";;
        }
        I.docStatsText.text = s;
        if (I.objectActual.stats.Next != null)
        {
            I.objectStats.Add(I.objectActual.stats.Next);
        }

        I.objectStats.Remove(I.objectActual.stats);
    }

    public void onApproved()
    {
        I.objectActual.onApproved();
        sliderMood.value += I.objectActual.stats.Mood * eventController.eventData.Mood;
        sliderImmunity.value += I.objectActual.stats.Immunity  * eventController.eventData.Immunity;
        sliderSatiety.value += I.objectActual.stats.Satiety * eventController.eventData.Satiety;
        sliderToxinLevel.value += I.objectActual.stats.ToxinLevel  * eventController.eventData.ToxinLevel;
        sliderHydration.value += I.objectActual.stats.Hydration  * eventController.eventData.Hydration;
        sliderEnergy.value += I.objectActual.stats.Energy * eventController.eventData.Energy;
        
        createObject();
    }
    
    public void onRejection()
    {
        I.objectActual.onRejection();
        createObject();
    }
}
