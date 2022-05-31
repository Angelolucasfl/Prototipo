using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private Rigidbody2D rig;
    public bool IsJumping;
    public bool IsDead;
    public int change;
    public string fase1;
    public string fase0;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        move();
        rig.velocity = new Vector2(speed * change, rig.velocity.y);
        if(Input.GetMouseButtonDown(0) && !IsJumping)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsJumping = true;
        }
    }

    void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if(colisor.gameObject.layer==8){
            IsJumping = false;
            speed = 3;
            jumpForce = 4;  
        }

        if(colisor.gameObject.layer==9){
            IsJumping = false;
            speed = 6;
            jumpForce = 8;
        }

        if(colisor.gameObject.tag == "change"){
            change = -1; 
        }

        if(colisor.gameObject.tag == "2p"){
            IsJumping = false;
            speed = 5;
            jumpForce = 6;
        }

        if(colisor.gameObject.tag == "change2"){
            change = 1;
        }

        if(colisor.gameObject.tag == "3p"){
            IsJumping = false;
            speed = 7;
            jumpForce = 10;
        }

        if(colisor.gameObject.tag == "boost2"){
            IsJumping = false;
            speed = 7;
            jumpForce = 35;
        }

        
        if(colisor.gameObject.tag == "win"){
            SceneManager.LoadScene(fase1);
        }
        else if(colisor.gameObject.tag == "death"){
            SceneManager.LoadScene(fase0);
        }
    }
}
