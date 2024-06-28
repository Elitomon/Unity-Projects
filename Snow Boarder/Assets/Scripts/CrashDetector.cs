using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasPlayed = false;

    //aligning a particle system to crash effect through the game engine
    //when unity detects collision with a trigger use the param other to get the tag of the trigger
    void OnTriggerEnter2D(Collider2D other) 
    {

        // if the tag of the item collided with doesnt equal ground then its not crashing

        if (other.tag == "Ground" && !hasPlayed)
        {
            // Invoke works with calling a method thats why we made reload scene so that we'd be able to use invoke
            // Invoke pauses the reloading of the scene for 'delay' seconds
            // playing the crash effect when the player hits his head on the ground
            // using PlayOneShot() to be able to assign the sound effect instead of just one with audiosources
            hasPlayed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene" , delay);
            
            
            



        }
    }

    // the method that does the reloading
    void ReloadScene() 
    {
        SceneManager.LoadScene(0);
    }

}
