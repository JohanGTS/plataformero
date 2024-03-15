using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchingDirectionFlipped : MonoBehaviour
{
    // Start is called before the first frame update
    public ContactFilter2D castFilter;
    CapsuleCollider2D touchingCol;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[1000005];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    Animator animator;
    private float groudDistance=0.05f;
    private float wallDistance=0.25f;
    private float ceilingDistance=0.05f;
    
    [SerializeField]
    private bool _isGrounded;
    public bool IsGrounded { get{return _isGrounded;} 
    private set {
        _isGrounded=value;
        animator.SetBool(ValoresAnimator.isGrounded,value);
    } }

    private bool _isOnWall;
    public bool IsOnWall { get{return _isOnWall;} 
    private set {
        _isOnWall=value;
        animator.SetBool(ValoresAnimator.isOnWall,value);
    } }

    private bool _isOnCeiling;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right :Vector2.left ;

    public bool IsOnCeiling { get{return _isOnCeiling;} 
    private set {
        _isOnCeiling=value;
        animator.SetBool(ValoresAnimator.isOnCeiling,value);
    } }

    void Awake()
    {
        touchingCol= GetComponent<CapsuleCollider2D>();
        animator= GetComponent<Animator>();
    }

    void FixedUpdate()
    {
         IsGrounded = touchingCol.Cast(Vector2.down,castFilter,groundHits,groudDistance)>0;
         IsOnWall = touchingCol.Cast(wallCheckDirection,castFilter,wallHits,wallDistance)>0;
         //IsOnCeiling = touchingCol.Cast(Vector2.up,castFilter,ceilingHits,ceilingDistance)>0;
    }
}
