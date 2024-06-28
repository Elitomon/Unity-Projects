using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoardEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem boardEffect;

    void OnCollisionStay2D(Collision2D other) 
    {
        boardEffect.Play();
    }
}
