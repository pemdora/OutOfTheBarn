using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepRandomAnim : MonoBehaviour {
    private Animator anim;
	// Use this for initialization

	void Start () {
        anim = this.GetComponent<Animator>();
        anim.speed = Random.Range(0.7f, 1.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
