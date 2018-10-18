using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedLevelCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        LevelManager.instance.SetInFinishedCollider(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        LevelManager.instance.SetInFinishedCollider(false);
    }
}
