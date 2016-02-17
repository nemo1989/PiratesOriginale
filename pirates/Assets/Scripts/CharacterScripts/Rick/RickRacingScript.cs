﻿using UnityEngine;
using System.Collections;

public class RickRacingScript : MonoBehaviour 
{
    public GameController controller;
    Animator anim;
    Rigidbody2D _rigibody2d;
    float speed;
    public float Boost;
    public float actualSpeed;
    GameObject hitBox;
    AudioSource source;
    public AudioClip auidoWalkingSound;
    bool left, right,down, up;
    public bool isWalking;
    public float accleration;
    bool isBreakActive;
    public float VerticalMovement;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        _rigibody2d = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        hitBox = transform.Find("hitBoxRight").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
       
        WalkingSound();

    }

    void FixedUpdate()
    {

        MoveCharacter();
    }

    public void Crashed()
    {
        speed -= 100;
        if (speed < 0)
        {
            speed = 0;
        }
    }
    void MoveCharacter()
    {
        WalkAnimation(0, 1, true);
        if (Input.GetKey(KeyCode.DownArrow) || down)
        {
            speed -= 5;
            isBreakActive = true;
            if (speed <= 0)
            {
                speed = 0;
            }
        }
        else
        {
            isBreakActive = false;
        }
        if (!isBreakActive)
        {
            if (speed < actualSpeed)
            {
                speed += accleration;
                _rigibody2d.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
            }
            else
            {

                _rigibody2d.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) || up == true)
        {
            speed = Boost;
            _rigibody2d.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
        }

        else

        {
            
            _rigibody2d.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
        }
      
            if (Input.GetKey(KeyCode.LeftArrow) || left == true)
            {
                _rigibody2d.velocity = new Vector2(-VerticalMovement * Time.fixedDeltaTime, speed * Time.fixedDeltaTime);
                
    
            }

             if (Input.GetKey(KeyCode.RightArrow) || right == true)
            {
               
                 _rigibody2d.velocity = new Vector2(VerticalMovement * Time.fixedDeltaTime, speed * Time.fixedDeltaTime);

             
            }

             
    }

    void WalkAnimation(float x, float y, bool walking)
    {
        anim.SetFloat("speedx", x);
        anim.SetFloat("speedy", y);
        anim.SetBool("isWalking", walking);
    }

  

    void WalkingSound()
    {
        if (anim.GetBool("isWalking") == true)
        {
            isWalking = true;
            if (!source.isPlaying)
            {
                if (!controller.win && !controller.gameOver)
                {
                    source.PlayOneShot(auidoWalkingSound, 0.05f);
                }
            }
        }
    }
    public void upPressed()
    {
        up = true;
    }
    public void upReleased()
    {
        up = false;
    }
    public void downPressed()
    {
        down = true;
    }
    public void downReleased()
    {
        down = false;
    }
   
    public void leftPressed()
    {
        left = true;
        Debug.Log(left);
    }
    public void leftReleased()
    {
        left = false;
    }
    public void rightPressed()
    {
        right = true;
        Debug.Log(right);
    }
    public void rightReleased()
    {
        right = false;
    }
    public void ReleaseAll()
    {
        right = false;
        left = false;
        up = false;
      
    }
}
