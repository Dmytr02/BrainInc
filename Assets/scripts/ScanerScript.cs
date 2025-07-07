using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScanerScript : MonoBehaviour
{
    public Material mat;
    public Material mat2;
    [SerializeField] Transform targetTransform;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] float speed;
    [SerializeField] GameObject shadow;
    Vector3 ofsertPosition;
    Vector3 startPosition;
    private int energy = 4;
    [SerializeField] SpriteRenderer[] energySprites; 
    [SerializeField] Animator animator;
    
    private void Start()
    {
        startPosition =  transform.position;
    }

    void Update()
    {
        mat.SetMatrix("_SecondWorldMatrix", targetTransform.localToWorldMatrix.inverse);
        mat2.SetMatrix("_SecondWorldMatrix", targetTransform.localToWorldMatrix.inverse);
        if (ofsertPosition != Vector3.zero)
        {
            transform.position = ofsertPosition + Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        if (energy > 0)
        {
            energy -= 1;
            energySprites[energy].color = new Color(0.8f, 0.4f, 0.4f);
            ofsertPosition = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shadow.SetActive(false);
        }
        else
        {
            animator.SetTrigger("lowEnergy");
        }
    }

    private void OnMouseUp()
    {
        ofsertPosition = Vector3.zero;
        shadow.SetActive(true);
    }
}
