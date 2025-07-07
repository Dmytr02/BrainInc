using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInfo : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void setShow(bool show)
    {
        animator.SetBool("isOpen", show);
        Debug.Log(show);
    }
}
