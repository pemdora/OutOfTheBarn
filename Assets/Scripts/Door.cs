using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Animator myAnimator;
    private BoxCollider2D collider;
    public int id;
    private bool locked;

    // Use this for initialization
    void Start ()
    {
        myAnimator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        locked = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.N))
        {
            myAnimator.SetBool("DoorOpen", false);
            collider.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (CharacterManager.instance.objectTocarry != null && CharacterManager.instance.objectTocarry.GetComponent<ObjectToCarry>().id == this.id)
        {
            Debug.Log("Unlocked");
            locked = false;
            myAnimator.SetBool("DoorOpen", true);
            collider.enabled = false;
        }
        else if(locked)
        {
            Debug.Log("Locked");
        }
    }
}
