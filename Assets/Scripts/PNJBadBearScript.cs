using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJBadBearScript : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BadBearWalk"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
		
        if (GetComponent<Transform>().position.x < 48)
        {
            this.gameObject.SetActive(false);
        }
	}
}
