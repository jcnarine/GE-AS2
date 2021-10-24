using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{

    //Implement Observer pattern action
    // Code referenced from Parisa's Lecture 4 Videos: https://drive.google.com/file/d/1mKuH4BzcJgqX2wQFOKWYbX6r7i3cS7mQ/view
    public static event Action shoot;

    //Create a variable to store audio clip
    protected AudioSource _audioSource;

    private void Awake()
    {
        //_audioSource gets the 'AudioSource'  component attached to the 'Music' gameobject.
        _audioSource = GetComponent<AudioSource>();

        //This section of code was referenced: https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html
        //Create an array of the GameObject that looks for gameobjects with the tag "Music"
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        //This if statement will destroy the music game object if it has already been created
        //When switching from the lose screen back to the game screen, the 'objs' variable will be greater then 1.Therefore, we destroy the object so the '_audioSource' will be re-invoked without a null value
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //If the amount of game objects is less then or equal to one, the object with the music tag is not destroyed
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }


      //Audio is played when the shoot functions is called and the 'shoot' action is invoked
      MusicManager.shoot += PlayAudio;

    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Invoking the Observer pattern
            //If the player press the spacebar to shoot,
            // the Shoot action becomes true and is now invoked
            #region observer
            shoot?.Invoke();
            #endregion

            //Audio is played when the shoot functions is called and the 'shoot' action is invoked
            MusicManager.shoot += PlayAudio;


        }
    }


    //Playaduio function which is called when the 'shoot' action is true
    private void PlayAudio()
        {
            //The audiosource variable calls the play function. This function will play the audio attached to the audio source component
            _audioSource.Play();

    }
}
