//from https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/creating-a-breakout-game

using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public GameObject brickParticle;

	void OnCollisionEnter () {
		Instantiate (brickParticle, transform.position, Quaternion.identity);
		GM.instance.DestroyBrick();
		gameObject.GetComponent<MeshRenderer> ().enabled = false; 	//jmc - by deactivating the renderer the object disppears on collision
		gameObject.GetComponent<BoxCollider> ().enabled = false;	//combined with deactivating the collider this allows time for the audio to play
		Destroy(gameObject, 1.0f);									//we do finally destroy the object after a delay
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
