using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJCubController : MonoBehaviour {
    public GameObject TargetPlayer;
    private Animator myAnimator;
    private bool is_awake;
    private Rigidbody2D rigidBody;
    private float distancePlayer;
    public float follow_distance;
    public float speed;
    // Use this for initialization
    void Start() {
        myAnimator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        is_awake = false;
        GetComponent<Transform>().position += new Vector3(0f,-2.6f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        distancePlayer = TargetPlayer.transform.position.x - transform.position.x;
        if (is_awake) { 
            if (Mathf.Abs(distancePlayer) > follow_distance)
            {
                rigidBody.velocity = new Vector2(Mathf.Min(distancePlayer / 20, 1) * speed, 0);
                myAnimator.SetBool("Walking", true);
            }
            else
            {
                rigidBody.velocity = new Vector2(0, 0);
                myAnimator.SetBool("Walking", false);
            }
            if (distancePlayer < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

     void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == TargetPlayer)
        {
            myAnimator.SetBool("Awake", true);
            is_awake = true;
        }
    }



}
