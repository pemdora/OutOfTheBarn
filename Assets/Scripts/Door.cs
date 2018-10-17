using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Animator myAnimator;
    private BoxCollider2D collider;
    public int id;

    // Use this for initialization
    void Start ()
    {
        myAnimator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.B))
        {
            myAnimator.SetBool("DoorOpen", true);
            collider.enabled = false;
        }

        if (Input.GetKey(KeyCode.N))
        {
            myAnimator.SetBool("DoorOpen", false);
            collider.enabled = true;
        }
    }
}
