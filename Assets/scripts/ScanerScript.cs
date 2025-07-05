using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanerScript : MonoBehaviour
{
    public Material mat;


    void Update()
    {
        mat.SetMatrix("_SecondWorldMatrix", transform.localToWorldMatrix.inverse);
    }
}
