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
    [SerializeField] public Slider sliderMood;
    [SerializeField] public Slider sliderImmunity;
    [SerializeField] public Slider sliderSatiety;
    [SerializeField] public Slider sliderToxinLevel;
    [SerializeField] public Slider sliderHydration;
    [SerializeField] public Slider sliderEnergy;


    [SerializeField] public GameObject documentPanel;
    [SerializeField] private Image docImage;
    [SerializeField] private TMP_Text docNameText;
    [SerializeField] private TMP_Text docDescriptionText;
    [SerializeField] private TMP_Text docStatsText;
    
    [SerializeField] private List<ObjectStats>  objectStats;
    
    [SerializeField] private Material scanMaterial;
    [SerializeField] private Material virusMaterial;
    
    [SerializeField] private Sprite virusRed;
    [SerializeField] private Sprite virusGreen;
    [SerializeField] private Sprite virusEnpty;
    
    [SerializeField] private GameObject QuoteObj;
    [SerializeField] private TMP_Text QuoteText;

    [SerializeField]private ObjectStats greenVirusStats;
    [SerializeField] private ObjectStats redVirusStats;

    private bool hasvirus = false;
    
    public static int rejectedCount = 0;
    public static int acceptedCount = 0;

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
        bool rand = Random.Range(0, 3)==0;
        I.virusMaterial.SetTexture("_IntersectTex", I.objectActual.stats.hasVirus? I.virusRed.texture:rand?I.virusGreen.texture:I.virusEnpty.texture);
        I.hasvirus = rand && !I.objectActual.stats.hasVirus;

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
        if (I.objectActual.stats.Next != null && !I.objectStats.Contains(I.objectActual.stats.Next))
        {
            I.objectStats.Add(I.objectActual.stats.Next);
        }

        //I.objectStats.Remove(I.objectActual.stats);
    }

    public void onApproved()
    {
        
        acceptedCount ++;
        I.objectActual.onApproved();
        sliderMood.value += (I.objectActual.stats.Mood+(I.hasvirus?greenVirusStats.Mood:I.objectActual.stats.hasVirus?redVirusStats.Mood:0)) * eventController.eventData.Mood;
        sliderImmunity.value += (I.objectActual.stats.Immunity+(I.hasvirus?greenVirusStats.Immunity:I.objectActual.stats.hasVirus?redVirusStats.Immunity:0))  * eventController.eventData.Immunity;
        sliderSatiety.value += (I.objectActual.stats.Satiety+(I.hasvirus?greenVirusStats.Satiety:I.objectActual.stats.hasVirus?redVirusStats.Satiety:0)) * eventController.eventData.Satiety;
        sliderToxinLevel.value += (I.objectActual.stats.ToxinLevel+(I.hasvirus?greenVirusStats.ToxinLevel:I.objectActual.stats.hasVirus?redVirusStats.ToxinLevel:0))  * eventController.eventData.ToxinLevel;
        sliderHydration.value += (I.objectActual.stats.Hydration+(I.hasvirus?greenVirusStats.Hydration:I.objectActual.stats.hasVirus?redVirusStats.Hydration:0))  * eventController.eventData.Hydration;
        sliderEnergy.value += (I.objectActual.stats.Energy+(I.hasvirus?greenVirusStats.Energy:I.objectActual.stats.hasVirus?redVirusStats.Energy:0)) * eventController.eventData.Energy;
        
        createObject();
    }
    
    public void onRejection()
    {
        rejectedCount ++;
        I.objectActual.onRejection();
        createObject();
    }
}
