using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    // how fast the car moves and turns
    [SerializeField] float moveSpeed = .01f;
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float slowSpeed = 15f;


    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            Debug.Log("Boost");
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Slow");
        moveSpeed = slowSpeed;
    }

    // making the movement of the car relative to peoples frames and input of keys
    // GetAxis already had the WASD keys as a part of the function
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed* Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, -steerAmount);

    }

}
