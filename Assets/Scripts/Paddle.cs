//from https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/creating-a-breakout-game

using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;
	private Vector3 playerPos = new Vector3 (0, 0f, 0);

	
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);
		transform.position = playerPos;
	}
}





