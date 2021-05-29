using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public int damage;
	public float life_time, speed;
	public bool playerAbs = false;

	character chara;
	private void Start() {
		chara = FindObjectOfType<character>();
		Invoke("destroy", life_time);
	}

	void destroy() => Destroy(gameObject);
}
