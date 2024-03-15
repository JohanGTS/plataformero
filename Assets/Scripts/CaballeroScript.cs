using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaballeroScript : MonoBehaviour
{   

    Rigidbody2D rb;

    Animator animator;
    public DetectionScript attackZone;

    public DetectionScript cliffDetectionZone;

    public float walkSpeed=3f;

    public enum walkableDirection {Right,Left}

    TouchingDirection touchingDirection;
    private walkableDirection _walkDirection= walkableDirection.Left;
    private Vector2 walkDirectionVector;

    public walkableDirection walkDirection{
        get {return _walkDirection;}
        set {
            
            if(_walkDirection!=value)
            {
                gameObject.transform.localScale=  new Vector2(gameObject.transform.localScale.x*-1,gameObject.transform.localScale.y);

                if (value== walkableDirection.Right)
                {
                    walkDirectionVector= Vector2.right;
                }
                else if (value== walkableDirection.Left)
                {
                    walkDirectionVector= Vector2.left;
                }
            
            }
            
            _walkDirection=value;

            }
            
    }

    public bool _hasTarget;
    public bool HasTarget { get{ return _hasTarget;} private set
    {
        _hasTarget =value;
        animator.SetBool(ValoresAnimator.hasTarget,value);
    }}

    void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        touchingDirection= GetComponent<TouchingDirection>();
    }

   
    void Update ()
    {
        HasTarget = attackZone.DetectionList.Count>0;
    }

    void FixedUpdate()
    {
        if ( touchingDirection.IsOnWall && touchingDirection.IsGrounded || cliffDetectionZone.DetectionList.Count==0)
        {
            FlipDirection();
        }

        

        Vector2 aplicar=walkDirectionVector; 

        if (walkDirection==walkableDirection.Left)
        {
            aplicar.x*=4;
        }
        
        

        rb.velocity= new Vector2 (walkSpeed+aplicar.x,rb.velocity.y);
        // Debug.Log("Velocidad:"+walkSpeed);
        // Debug.Log("Vector: "+aplicar.x);
    }

    private void FlipDirection()
    {
        if (walkDirection==walkableDirection.Right)
        {
            walkDirection=walkableDirection.Left;
        }
        else 
        {
            walkDirection=walkableDirection.Right;
        }

    }

        public void onHit (int damage, Vector2 knockback){
        rb.velocity= new Vector2(knockback.x,rb.velocity.y+knockback.y);
    }
}
