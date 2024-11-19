using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndSong : MonoBehaviour
{
    public AudioSource song;  // Reference to the AudioSource that will play the song
    public GameObject screen;

    void Start()
    {
        screen.SetActive(false);    
        if (song != null)
        {
            song.Stop();  // Ensure the song is not playing at the start
        }
    }

    // This function is called when another object enters the trigger collider attached to this object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the object entering the trigger is the player
        {
            if (song != null && !song.isPlaying)
            {
                song.Play();  // Play the song when the player enters the trigger zone
                screen.SetActive(true);
            }
        }
    }
}
