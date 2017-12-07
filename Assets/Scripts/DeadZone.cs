//from https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/creating-a-breakout-game

using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {


	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
		GM.instance.LoseLife();
		SoundManager.instance.Feedback(this.name);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
