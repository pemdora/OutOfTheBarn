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
    }

    // Update is called once per frame
    void Update() {
        distancePlayer = TargetPlayer.transform.position.x - transform.position.x;
        if (is_awake && Mathf.Abs(distancePlayer) > follow_distance)
        {
            rigidBody.velocity = new Vector2(Mathf.Min(distancePlayer/10 , 1) * speed, 0);
            myAnimator.SetBool("Walking",true);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, 0);
            myAnimator.SetBool("Walking",false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other == TargetPlayer)
        {
            myAnimator.SetTrigger("CubAwake");
            is_awake = true;
        }
    }



}
