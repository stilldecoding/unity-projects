using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    GameObject Player;

    Vector2 Dir;

    Rigidbody2D Rbody;
  
    [SerializeField] float ArrowSpeed = 10;
    void Start()
    {     
        Player = GameObject.FindWithTag("Player");
        Rbody = GetComponent<Rigidbody2D>();
        Dir = new Vector2(Player.transform.localScale.x, Dir.y);
        transform.localScale = new Vector2(Dir.x,1f);
        
    }

    void Update()
    {
        Rbody.velocity = Dir * ArrowSpeed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

}
