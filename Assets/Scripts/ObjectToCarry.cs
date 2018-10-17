using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToCarry : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (CharacterManager.instance.objectInteraction)
            CharacterManager.instance.CarryObject(this.gameObject);
    }
    
}
