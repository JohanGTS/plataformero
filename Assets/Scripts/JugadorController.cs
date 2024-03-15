using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Rigidbody2D),typeof(TouchingDirectionFlipped))]
public class JugadorController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float walkSpeed =5f;
    Rigidbody2D rb;
    Animator animator;
    Vector2 moveInput;

    private TMP_Text texto;

    TouchingDirectionFlipped touchingDirection;

    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        touchingDirection= GetComponent<TouchingDirectionFlipped>();
        texto = FindObjectOfType<TMP_Text>();
    }
    private bool _isMoving= false, _isAlive=true;
    private bool _isFacingRight = true;
    public float jumpImpulse=10f;

    public float CurrentMoveSpeed { get {
        if (IsMoving && !touchingDirection.IsOnWall)
        {
            return walkSpeed;
        }
        else
        {
            return 0;
        }
    }}


    public bool IsFacingRight { get{
        return _isFacingRight;
    } private set{
        if (_isFacingRight!= value)
        {
            transform.localScale*= new Vector2(-1,1); //girando el sprite
        }
        _isFacingRight=value;}
    }
    
    public bool IsAlive { get{
        return _isAlive;
    } private set{
        _isAlive=value;
        animator.SetBool(ValoresAnimator.isAlive,value); }
    }

    public bool IsMoving { get{
        return _isMoving;
    } private set{
        _isMoving=value;
        animator.SetBool(ValoresAnimator.isMoving,value); }
    }


    void FixedUpdate()
    {
            rb.velocity= new Vector2(moveInput.x * CurrentMoveSpeed , rb.velocity.y);
            
    }

    private void CambiarEscena()
    {
        string nombreEscenaActual = SceneManager.GetActiveScene().name;
        String escena;
        Debug.Log("estoy");
        if (nombreEscenaActual=="Nivel1")
            escena="Nivel2";
        else if (nombreEscenaActual=="Nivel2")
            escena="Nivel3";
        else
            escena="Menu";

        SceneManager.LoadSceneAsync(escena);
    }

    public void OnMove (InputAction.CallbackContext context)
    {

        moveInput= context.ReadValue<Vector2>();

        IsMoving = moveInput!=Vector2.zero;

        SetFacingDriection(moveInput);
    }

    private void SetFacingDriection(Vector2 moveInput)
    {
       if (moveInput.x>0 && !IsFacingRight) 
       {
            IsFacingRight=true;
       }
       else if(moveInput.x<0 && IsFacingRight)
       {
            IsFacingRight=false;
       }
    }

    public void OnJump (InputAction.CallbackContext context){
        
        if (context.started && touchingDirection.IsGrounded){
            rb.velocity = new Vector2( rb.velocity.x, jumpImpulse);
        }
    }
    void Update ()
    {
         if (!GameObject.FindGameObjectWithTag("Enemy")  )
        {
            CambiarEscena();
        }

        if (!IsAlive)
        {
            Debug.Log("Juas");
            SceneManager.LoadSceneAsync("Nivel1");
        }
    }
    public void OnAttack (InputAction.CallbackContext context){
        animator.SetTrigger(ValoresAnimator.isAttacking);  
    }

    public void onHit (int damage, Vector2 knockback){
        rb.velocity= new Vector2(knockback.x,rb.velocity.y+knockback.y);
    }

    
}
