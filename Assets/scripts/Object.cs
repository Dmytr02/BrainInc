using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private Document documentPrefab;
    [SerializeField] private Animator animator;
    public ObjectStats stats;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("onComeIn", animator.GetCurrentAnimatorStateInfo(0).length); 
    }

    private void onComeIn()
    {
        Instantiate(documentPrefab);
    }

    public void onApproved()
    {
        animator.SetBool("isApproved",  true);
    }

    public void onRejection()
    {
        animator.SetBool("isRejected",  true);
    }

    void Destry()
    {
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
