using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public void setGreenLight()
    {
        spriteRenderer.color = new Color(0, 1, 0, 0.5f);
        gameObject.SetActive(true);
        Invoke("turnOff", 0.6f);
    }public void setRedLight()
    {
        spriteRenderer.color = new Color(1, 0, 0, 0.5f);
        gameObject.SetActive(true);
        Invoke("turnOff", 0.6f);
    }

    void turnOff()
    {
        gameObject.SetActive(false);   
    }
}
