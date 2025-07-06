using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private Document documentPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public ObjectStats stats;
    public GameObject Quote;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("onComeIn", animator.GetCurrentAnimatorStateInfo(0).length); 
        spriteRenderer.sprite = stats.sprite;  
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

    public void showQuote()
    {
        Quote.SetActive(true);
        Invoke("hideQuote", 4);
    }
    public void hideQuote()
    {
        Quote.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
