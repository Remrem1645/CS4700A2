using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage Struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;
    
    // Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing
    private Animator animator;
    private float cooldown = 0.5f;
    private float lastSwing;
    
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player_0")
            return;
        if (coll.CompareTag("Fighter"))
        {
            Damage damage = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };
            
            coll.SendMessage("ReceiveDamage", damage);
            Debug.Log(coll.name);
        }
        
    }

    private void Swing()
    {
        animator.SetTrigger("Swing");
    }
    
}
