using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    Vector2 MoveInput;
    [SerializeField]float jumpforce = 10;
    float MoveSpeed = 5;
    Rigidbody2D Rigidbody;
    Animator animator;
    
    CapsuleCollider2D capsuleCollider;
    BoxCollider2D boxCollider;
    [SerializeField] Vector2 deathforce;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject Bow;
    [SerializeField] GameObject afterlevel;


    int CoinCount = 0;

    bool IsAlive = true;
    
    float gravity;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        gravity = Rigidbody.gravityScale;
    }

    void Update()
    {
        if (IsAlive)
        {
            Run();
            ClimbLadder();

            Flipsprite();
            if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Spikes")))
            {
                Die();
            }
        }
        
    }

    void OnMove(InputValue input)
    {
        MoveInput = input.Get<Vector2>();
        //
        if (MoveInput == Vector2.zero)
        {
            animator.SetBool("IsRunning", false);
            
            animator.SetBool("IsIdleonClimb", false);
            
        }
        else if (MoveInput == Vector2.right || MoveInput == Vector2.left)
        {
            animator.SetBool("IsRunning", true);
            
        }
        animator.SetBool("IsClimbing", false);
        
        

    }

    void ClimbLadder()
    {
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            if (MoveInput == Vector2.up || MoveInput == Vector2.down)
            {
                animator.SetBool("IsClimbing", true);
                animator.SetBool("IsRunning", false);
                
                animator.SetBool("IsIdleonClimb",false);
            }
            else
            {
                animator.SetBool("IsClimbing", false);
                animator.SetBool("IsIdleonClimb",true);
            }

            Vector2 climb = new Vector2(Rigidbody.velocity.x, MoveInput.y * MoveSpeed);
            
            Rigidbody.velocity = climb;
            Rigidbody.gravityScale = 0;
        }
        else
        {
            animator.SetBool("IsClimbing", false);
            animator.SetBool("IsIdleonClimb", false);
            Rigidbody.gravityScale = gravity;
            return;
        }

        
       
    }

    void OnJump(InputValue input)
    {

        if (input.isPressed && boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 jumpvelocity = new Vector2(Rigidbody.velocity.x, jumpforce);
            Rigidbody.velocity = jumpvelocity;
        }
    }

    void OnFire(InputValue input)
    {
        if (IsAlive)
        {
            animator.SetBool("IsFiring", true);
            Instantiate(arrow, Bow.transform.position, transform.rotation);
        }
    }

    void Run()
    {
        Vector2 PlayerVelocity = new Vector2(MoveInput.x * MoveSpeed,Rigidbody.velocity.y);
        Rigidbody.velocity = PlayerVelocity;
    }

    void Flipsprite()
    {
        if(Rigidbody.velocity.x < 0)
        {
            transform.localScale = new(-1, 1, 1);
        }
        else if(Rigidbody.velocity.x > 0)
        {
            transform.localScale = new(1, 1, 1);
        }
    }

    [System.Obsolete]
    void Die()
    {
        IsAlive = false;
        Rigidbody.velocity = deathforce;
        animator.SetTrigger("NotAlive");
        Destroy(capsuleCollider);

        ShowAfterlevel();
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            CoinCount++;
            Destroy(collision.gameObject);
            
        }
    }*/

    public int GetCoinCount()
    { 
        return CoinCount; 
    }

    [System.Obsolete]
    void ShowAfterlevel()
    {
        afterlevel.active = true;
    }

}
