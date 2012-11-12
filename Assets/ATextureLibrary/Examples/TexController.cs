using UnityEngine;
using System.Collections;

public class TexController : MonoBehaviour {
	
	public GameObject monster;

	void Start () {
		TextureLoader.MakeNewTexture(monster, "Images/Monster");
	}
}
