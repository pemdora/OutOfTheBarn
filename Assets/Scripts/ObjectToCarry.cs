using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToCarry : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CharacterManager.instance.CarryObject(this.gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter2D");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("OnCollisionEnter2D");
    }
}
