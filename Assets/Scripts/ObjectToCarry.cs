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
            this.transform.position += new Vector3(0f,1f,0f);
        }
    }
}
