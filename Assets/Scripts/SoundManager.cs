using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioClip[] positiveExp;
	public AudioClip[] negativeExp;
	public AudioClip[] positiveCom;
	public AudioClip[] negativeCom;
	public AudioClip[] positiveTag;
	public AudioClip[] negativeTag;

	enum Commentator {PositiveExp, NegativeExp, PositiveCom, NegativeCom, PositiveTag, NegativeTag};
	Commentator smallVoice;

	bool moreAudio = true;

	AudioSource myAudio;

	public static SoundManager instance = null;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		myAudio = this.GetComponent<AudioSource>();
	}

	//method to call feedback during gameplay
	public void Feedback (string whoCalled) {
		if (whoCalled == "Ball") {
			Debug.Log ("the ball called feedback");
			smallVoice = Commentator.PositiveExp;
		}
		else if (whoCalled == "Water") {
			Debug.Log ("the water called feedback");
			smallVoice = Commentator.NegativeExp;
		}
		if (!myAudio.isPlaying) {
			PlayFeedback();
		}
	}

	void PlayFeedback () {
		Debug.Log("playfeedback was called");

		moreAudio = (Random.value < 0.5f);


		//JC based on our current dialogue state, we can load and play another audioclip
		switch(smallVoice) {
		case Commentator.PositiveExp:
			myAudio.clip = positiveExp[Random.Range(0, positiveExp.Length)];
			if (moreAudio) {
				smallVoice = Commentator.PositiveCom;
			}
			break;
		case Commentator.NegativeExp:
			myAudio.clip = negativeExp[Random.Range(0, negativeExp.Length)];
			if (moreAudio) {
				smallVoice = Commentator.NegativeCom;
			}
			break;
		case Commentator.PositiveCom:
			myAudio.clip = positiveCom[Random.Range(0, positiveCom.Length)];
			if (moreAudio) {
				smallVoice = Commentator.PositiveTag;
			}
			break;
		case Commentator.NegativeCom:
			myAudio.clip = negativeCom[Random.Range(0, negativeCom.Length)];
			if (moreAudio) {
				smallVoice = Commentator.NegativeTag;
			}
			break;
		case Commentator.PositiveTag:
			myAudio.clip = positiveTag[Random.Range(0, positiveTag.Length)];
			moreAudio = false;
			break;
		case Commentator.NegativeTag:
			myAudio.clip = negativeTag[Random.Range(0, negativeTag.Length)];
			moreAudio = false;
			break;
		default:
			myAudio.clip = positiveExp[Random.Range(0, positiveExp.Length)];
			moreAudio = false;
			break;
		}

		if (!myAudio.isPlaying) {
			myAudio.Play();
			if (moreAudio) {
				Invoke ("PlayFeedback", myAudio.clip.length);
			}
		}
	}
}
