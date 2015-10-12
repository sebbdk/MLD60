using UnityEngine;
using System.Collections;

using UnityEngine;
using SpriteTile;

public class Test : MonoBehaviour {

	public TextAsset test;
	
	void Awake () {
		Tile.SetCamera(GetComponent<Camera>());
		Tile.LoadLevel (test);
	}
}
