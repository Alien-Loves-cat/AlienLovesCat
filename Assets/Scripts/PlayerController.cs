using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    public string upAnime = "PlayerUp";
    public string downAnime = "PlayerDown";
    public string rightAnime = "PlayerRight";
    public string leftAnime = "PlayerLeft";
    string nowAnimation = "";
    string oldAnimation = "";

    float axisH;
    float axisV;
    public float angleZ = -90.0f;

    Animator animator;
    Rigidbody2D rbody;
    
    

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();   
    }

    void Update()
    {
        
        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");

        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);

        if (angleZ >= -45 && angleZ < 45)
        {
            nowAnimation = rightAnime;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            nowAnimation = upAnime;
        }
        else if (angleZ >= -135 && angleZ <= -45)
        {
            nowAnimation = downAnime;
        }
        else
        {
            nowAnimation = leftAnime;
        }

        if(axisH == 0 && axisV == 0)
        {
            animator.Play(null);
        }

        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            animator.Play(nowAnimation);
        }
        

    }

    void FixedUpdate()
    {
        rbody.velocity = new Vector2(axisH, axisV) * speed;
    }

    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if(axisH != 0 || axisV != 0)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;

            float rad = Mathf.Atan2(dy, dx);

            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }

        return angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("인벤토리에 넣어야하는데,,,");
        }

    }

}




