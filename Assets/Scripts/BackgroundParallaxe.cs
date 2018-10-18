using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallaxe : MonoBehaviour {
    public GameObject Camera;
    private Vector2 oldposition;
    private Vector2 newposition;
    private Vector2 diffposition;
    public Vector2 Parallax;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        newposition = Camera.GetComponent<Transform>().position;
        diffposition = newposition - oldposition;
        
        this.gameObject.transform.position = Vector2.Scale(diffposition, Parallax) + new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        oldposition = newposition;

        if(oldposition.x- this.gameObject.transform.position.x > 16)
        {
            this.gameObject.transform.position += new Vector3(16, 0, 0);
        }
        else if(oldposition.x - this.gameObject.transform.position.x < -16)
        {
            this.gameObject.transform.position += new Vector3(-16, 0, 0);
        }
    }
}
