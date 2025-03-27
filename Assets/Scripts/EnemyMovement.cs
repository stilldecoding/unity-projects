using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D RB;
    float Dir = 1;
    float speed = 2.5f;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();   
    }

    
    void Update()
    { 
        RB.velocity = new Vector2(Dir * speed, RB.velocity.y);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        Dir = -Dir;
        transform.localScale = new Vector2(-(transform.localScale.x), 1);
    }




}
