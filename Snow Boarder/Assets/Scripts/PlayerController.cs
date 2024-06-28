using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostAmount = 1f;
    [SerializeField] float baseAmount = 1f;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondOnBoost();
        }
       
    }

    public void DisableControls()
    {
        canMove = false;
    }

     void RespondOnBoost()
    {
       if(Input.GetKey(KeyCode.W)) 
        {
            surfaceEffector2D.speed = boostAmount;
        } else 
        {
            surfaceEffector2D.speed = baseAmount;
        }
    }

    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.A)) 
        {
            rb2d.AddTorque(torqueAmount);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
     
}
