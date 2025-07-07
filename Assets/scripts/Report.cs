using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Report : MonoBehaviour
{
    [SerializeField]private TMP_Text text;
    int count = 0;
    
    public void setText()
    {
        if(count == 0)
            text.text = "Welcome to the Department of Brain Activity!\nWe are happy to welcome you to your new workplace. Today is your first day, and we want it to be as pleasant as possible.\nTo help you get started, we've prepared a small instruction manual to guide you through your main tasks.\nYour goal is to carefully inspect all substances consumed by the brain.\nPlease note that in the BOTTOM RIGHT CORNER you will find stat bars indicating the current state of the body.\nThe list of stats (from left to right, again, LEFT TO RIGHT): \nMood, Immunity, Satiety, Toxicity Level, Hydration.\nTry to keep all sliders in the green zones.\nAfter reading the card of an incoming substance and reviewing its stats, please press the red button if the substance disrupts the body’s balance.\nIf the stats have a positive or neutral effect on the body’s balance, press the green button.\nYour shift ends precisely at 12 o’clock.\nGood luck!\n\nHead of the Department of Brain Activity,\nG.L.\n";
        else if (count == 1)
        {
            text.text = "ATTENTION: LONG MESSAGE – PLEASE READ CAREFULLY\nGood morning!\nCongratulations on a successful first day in the Department of Brain Activity!\nYour results from yesterday:\n";
            text.text += "•\tNumber of substances processed and accepted: " + ObjectsController.acceptedCount;
            text.text += "•\tNumber of substances processed and rejected: "+ ObjectsController.rejectedCount;
            int good = 0;
            int Average = 0;
            int Poor = 0;
            if (ObjectsController.I.sliderMood.value > 0.7f) good++;
            else if (ObjectsController.I.sliderMood.value > 0.6f) Average++;
            else Poor++;
            if (ObjectsController.I.sliderImmunity.value > 0.7f) good++;
            else if (ObjectsController.I.sliderImmunity.value > 0.6f) Average++;
            else Poor++;
            if (ObjectsController.I.sliderSatiety.value > 0.5f && ObjectsController.I.sliderImmunity.value < 0.9f) good++;
            else if (ObjectsController.I.sliderSatiety.value > 0.4f) Average++;
            else Poor++;
            if (ObjectsController.I.sliderToxinLevel.value > 0.3f && ObjectsController.I.sliderImmunity.value < 0.6f) good++;
            else if (ObjectsController.I.sliderToxinLevel.value > 0.2f && ObjectsController.I.sliderToxinLevel.value < 0.7f) Average++;
            else Poor++;
            if (ObjectsController.I.sliderSatiety.value > 0.7f && ObjectsController.I.sliderImmunity.value < 0.9f) good++;
            else if (ObjectsController.I.sliderSatiety.value > 0.6f) Average++;
            else Poor++;
            text.text += "•\tGeneral condition of the body: " + ((good>=Average && good>=Poor)?"good":(Average>Poor)?"Average":"Poor");
            text.text += "•\tForecast for the day: All departments are operating normally today.";
            text.text +=
                "Please note: after a Night Shift, some stats may decrease.\nThis is required for the execution of certain night-time tasks.\nYour job is to restore these stats to acceptable levels.\nWe would also like to inform you that the body has recently been under frequent viral attacks.\nThe Immune System Department is working on enhancing protection, but for now, we must manually inspect all incoming substances.\nTherefore, we ask you to carefully read all substance documents and check them for potential viruses.\nIf you encounter any suspicious substances, scan them using the scanner located to your LEFT.\nThe scanner’s charge is limited, so use it wisely.\nIf you find foreign bodies in substances, compare them with the reference graphic on the wall.\nRed bodies are dangerous to the body.\nGreen ones are acceptable.\n\nWishing you a productive workday!\nHead of the Department of Brain Activity,\nG.L.\n";
        }
        else
        {
            text.text = "Good morning!\nYour results from yesterday:\n";
            text.text += "•\tNumber of substances processed and accepted: " + ObjectsController.acceptedCount;
            text.text += "•\tNumber of substances processed and rejected: "+ ObjectsController.rejectedCount;
            int good = 0;
            int Average = 0;
            int Poor = 0;
            if (ObjectsController.I.sliderMood.value > 0.7f) good++;
            else if (ObjectsController.I.sliderMood.value > 0.6f) Average++;
            else Poor++;
            if (ObjectsController.I.sliderImmunity.value > 0.7f) good++;
            else if (ObjectsController.I.sliderImmunity.value > 0.6f) Average++;
            else Poor++;
            if (ObjectsController.I.sliderSatiety.value > 0.5f && ObjectsController.I.sliderImmunity.value < 0.9f) good++;
            else if (ObjectsController.I.sliderSatiety.value > 0.4f) Average++;
            else Poor++;
            if (ObjectsController.I.sliderToxinLevel.value > 0.3f && ObjectsController.I.sliderImmunity.value < 0.6f) good++;
            else if (ObjectsController.I.sliderToxinLevel.value > 0.2f && ObjectsController.I.sliderToxinLevel.value < 0.7f) Average++;
            else Poor++;
            if (ObjectsController.I.sliderSatiety.value > 0.7f && ObjectsController.I.sliderImmunity.value < 0.9f) good++;
            else if (ObjectsController.I.sliderSatiety.value > 0.6f) Average++;
            else Poor++;
            text.text += "•\tGeneral condition of the body: " + ((good>=Average && good>=Poor)?"good":(Average>Poor)?"Average":"Poor");
            text.text += "•\tForecast for the day: All departments are operating normally today.";
            text.text += "Wishing you a productive workday!\nHead of the Department of Brain Activity,\nG.L.\n";
        }

        count++;
    }
}
