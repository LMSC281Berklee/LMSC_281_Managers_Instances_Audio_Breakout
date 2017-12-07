using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//include the Audio library
using UnityEngine.Audio;

public class AudioVolumes : MonoBehaviour {

	public AudioMixer myAM;

	public void SetMasterVolume (float masterLvl) {
		myAM.SetFloat ("MasterVolume", masterLvl);
	}

	public void SetSFXVolume (float sfxLvl) {
		myAM.SetFloat ("SFXVolume", sfxLvl);
	}

	public void SetMusicVolume (float musicLvl) {
		myAM.SetFloat ("MusicVolume", musicLvl);
	}

	public void SetDiaVolume (float diaLvl) {
		myAM.SetFloat ("DialogueVolume", diaLvl);
	}

}
