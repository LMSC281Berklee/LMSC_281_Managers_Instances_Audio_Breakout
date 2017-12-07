//provided as a part of an audio tutorial series
//Jeanine Cowen - jmc@jmcmusicinc.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//we need to add the Audio library to code with the AudioMixers
using UnityEngine.Audio;

public class RandomSounds : MonoBehaviour {

	//hold an array of sounds for randomization
	public AudioClip[] randomSounds;

	//holds a reference to the audio mixer
	public AudioMixer myAM;

	//randomly place the sounds as they are played
	float xPos, yPos, zPos;
	Vector3 target;

	//use a random timing parameter to play the sounds
	float offset;

	// Use this for initialization
	void Start () {
		offset = Random.Range (1.0f, 4.0f);
		Invoke ("PlayRandomSound", offset);
	}

	//used to play short bat sound clips throughout the game space
	public void PlayRandomSound () {
		
		//create an empty game object
		GameObject myGO = new GameObject ("Random Sound");
		//give the game object an AudioSource
		AudioSource thisSource = myGO.AddComponent<AudioSource>();

		//we need to find the correct AudioMixer group
		thisSource.outputAudioMixerGroup = myAM.FindMatchingGroups("SFX")[0];

		//give the AudioSource a delay filter
		myGO.AddComponent<AudioEchoFilter>();
		thisSource.GetComponent<AudioEchoFilter> ().delay = 250.0f;
		thisSource.GetComponent<AudioEchoFilter> ().dryMix = 0.5f;
		thisSource.GetComponent<AudioEchoFilter> ().decayRatio = 0.2f;

		//load a random AudioClip and randomize the volume and pitch
		thisSource.clip = randomSounds[(Random.Range(0, randomSounds.Length))];
		thisSource.volume = Random.Range (0.5f, 0.75f);
		thisSource.pitch = Random.Range (0.9f, 1.2f);

		//set the AudioSource to play in 3D
		thisSource.spatialBlend = 1.0f;
		thisSource.reverbZoneMix = 0.5f;

		//randomly place the object around the world
		xPos = Random.Range (-5.0f, 30.0f);
		yPos = Random.Range (5.0f, 20.0f); //we expect to hear flying birds and animals above us
		zPos = Random.Range (-20.0f, 20.0f);
		
		myGO.transform.position = new Vector3 (xPos, yPos, zPos);

		//play the source
		thisSource.Play ();

		//Make sure to destroy this object once it is finished playing the audio
		Destroy (myGO, thisSource.clip.length);

		//setup to play the sounds again at a random interval
		offset = Random.Range (1.0f, 4.0f);
		Invoke ("PlayRandomSound", offset);
	}
}
