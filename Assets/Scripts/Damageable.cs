using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class Damageable : MonoBehaviour
{
    public UnityEvent<int,Vector2> damageableHit; 
    [SerializeField]
    private int _maxHealth=100;

    Animator animator;

    public int MaxHealth {
        get {
            return _maxHealth;
        }
        set {
            _maxHealth=value;
        }
    }
    [SerializeField]
    private int _health=100;

    public int Health {
        get {
            return _health;
        }
        set {
            _health=value;

            if (_health<=0)
            {
                IsAlive = false;
                Debug.Log("Isalive: "+value);
                if (gameObject.CompareTag("Player") && !IsAlive)
                {
                    Debug.Log("Entra");
                    SaliendoDelJuego();
                    
                }
            }
        }
    }

    [SerializeField]
    private bool _isAlive=true;
    private bool isInvincible=false;

    public bool IsHit { get{
       return animator.GetBool(ValoresAnimator.isHit);
    } private set{
        animator.SetBool(ValoresAnimator.isHit,value);
        //IsHit=value;
    } }

    private float timeSinceHit=0;
    public float invicibilityTime=0.25f;

    public bool IsAlive { get{return _isAlive;} 
    private set{
        _isAlive=value;
        animator.SetBool(ValoresAnimator.isAlive,value);
    } }

    void Awake()
    {
        animator= GetComponent<Animator>();
    }


    public void Update ()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invicibilityTime)
            {
                isInvincible=false;
                timeSinceHit=0;
            }

            timeSinceHit+=Time.deltaTime;
        }
    }

    void Start ()
    {
        
    }

    public bool Hit(int damage, Vector2 knockback)
    {
        if(IsAlive && !isInvincible)
        {
            Health-=damage;
            isInvincible=true;
            animator.SetTrigger(ValoresAnimator.Hit);
            damageableHit?.Invoke(damage,knockback);
            return true;
        }

        
        return false;
    }

    private void SaliendoDelJuego()
    {
        Invoke("Nivel1", 2f);
    }
}
