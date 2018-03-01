using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewal : MonoBehaviour {

	Animator anim;

	void OnCollisionEnter(Collision coll) {
		anim = coll.collider.gameObject.GetComponentInParent<Animator>();
		if (coll.collider.gameObject.tag == "Player" && anim.GetBool ("Sliding") == false) {
			anim.SetBool("Death", true);
		}
		Debug.Log ("weeha");
	}
}
