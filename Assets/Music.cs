using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	
	private static Music instance = null;
	
	public static Music Instance {
		get { return instance; }
	}
	
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	public static void Stop() {
		if (instance) {
			AudioSource src = instance.gameObject.GetComponent<AudioSource> ();
			src.Stop ();
		}
	}
	
	public static void Play() {
		if (instance) {
			AudioSource src = instance.gameObject.GetComponent<AudioSource> ();
			if (!src.isPlaying) {
				src.Play ();
			}
		}
	}
}
