using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilemaTextBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text;
    public AudioSource audio;
    private bool option;
    void Start()
    {
        text.SetActive(false);
        option = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying&&option)
        {
            text.SetActive (true);
        }
        if(Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Mouse0))
        {
            option = false;
            text.SetActive (false); 
        }

    }
}
