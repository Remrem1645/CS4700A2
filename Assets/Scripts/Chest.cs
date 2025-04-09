using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    private Animator animator;
    public Sprite emptyChest;
    public int pesosAmount = 10;


    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }
    
    protected override void OnCollect()
    {
        if (!collected)
        {
            animator.SetBool("Opened", true);
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.pesos += pesosAmount;
            GameManager.instance.ShowText(
                "+" + pesosAmount + " pesos!", 
                25,
                Color.yellow, 
                transform.position, 
                Vector3.up * 25,
                1.0f);
            
            
        }
    }
}
