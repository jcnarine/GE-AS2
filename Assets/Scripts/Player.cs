using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Player : Spaceship
	{

	public int bounce;
	public TextMeshProUGUI livesText;


	//Implement Observer pattern action
	// Code referenced from Parisa's Lecture 4 Videos: https://drive.google.com/file/d/1mKuH4BzcJgqX2wQFOKWYbX6r7i3cS7mQ/view
	public static event Action shoot;

	//Create a variable to store audio clip
	private AudioSource _audioSource;

	//Awake function used to initalize audio upon loading the game
	private void Awake()
    {
		_audioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	public void Update()
		{

     
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
			{
		
		  //Invoking the Observer pattern
		  //If the player press the spacebar to shoot,
		  // the Shoot action becomes true and is now invoked
		  #region observer
		  shoot?.Invoke();
		  #endregion

		  Shoot();

		  //Audio is played when the shoot functions is called and the 'shoot' action is invoked
		  Player.shoot += PlayAudio;

			}
		}

	public void FixedUpdate()
		{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
			rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
			}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
			rb.AddForce(Vector3.down * speed, ForceMode.Impulse);
			}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
			rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
			}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
			rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
			}

		Vector3 temp = rb.velocity;

		if (temp.sqrMagnitude > sqrMaxVelocity)
			{
			rb.velocity = temp.normalized * maxVelocity;
			}
		}
	public void OnTriggerEnter(Collider other)
		{
		if (other.gameObject.tag == "Asteroid"|| other.gameObject.tag == "Enemy")
			{
			lives -= 1;
			if (lives==0) {
				SceneManager.LoadScene("YouLose");
				}
			livesText.text = "Lives: " + lives;
			}
		if (other.gameObject.tag == "Boundary")
			{
			rb.AddForce(rb.velocity * -1 * bounce, ForceMode.Impulse);
			}
		}

		//Playaduio function which is called when the 'shoot' action is true
		private void PlayAudio()
		{
			//The audiosource variable calls the play function. This function will play the audio attached to the audio source component
			_audioSource.Play();

		}

	}
