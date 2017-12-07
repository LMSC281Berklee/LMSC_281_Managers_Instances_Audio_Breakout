//from https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/creating-a-breakout-game

using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 600f;
	private Rigidbody rb;
	private bool ballInPlay;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown("Fire1") && ballInPlay == false) {
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}
	}

	//jmc - added function to create sound on collision

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.GetComponent<AudioSource>() != null) { //jmc if the object that was collided with has an audiosource
			other.gameObject.GetComponent<AudioSource>().Play(); 	//we play the audiosource
		}

		if (other.gameObject.name == "Brick") {
			SoundManager.instance.Feedback(this.name);
		}
	}
}
