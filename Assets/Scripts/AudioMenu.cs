using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour {

	Canvas audioMenuCanvas;

	//public GameObject myCanvas;

	void Start () {
		audioMenuCanvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				Time.timeScale = 0.001f;
				audioMenuCanvas.GetComponent<CanvasGroup>().alpha = 1;
				audioMenuCanvas.GetComponent<CanvasGroup> ().interactable = true;
				audioMenuCanvas.GetComponent<CanvasGroup> ().blocksRaycasts = true;

			} else 
			{
				audioMenuCanvas.GetComponent<CanvasGroup>().alpha = 0;
				audioMenuCanvas.GetComponent<CanvasGroup> ().interactable = false;
				audioMenuCanvas.GetComponent<CanvasGroup> ().blocksRaycasts = false;	
				Time.timeScale = 1;
			}
		}
	}
}
