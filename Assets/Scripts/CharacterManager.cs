using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    [SerializeField]
    private float horizontalMove = 0f;
    private bool rightDirection;
    private SpriteRenderer mysprite;

    private Animator myAnimator;

    [SerializeField]
    private float speed;

    public static CharacterManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        mysprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        rightDirection = true;
    }

    // Update is called once per frame => not good because besed on computer fps
    //void Update () {}

    // Dedicated for physics, Called a fixed amount (fixed amount of time per second) 
    public void FixedUpdate()
    {
        if (!CameraManager.instance.cameraTransition) // cant move player when a cinematic is playing
        {
            horizontalMove = Input.GetAxis("Horizontal");
            if (horizontalMove > -0.04f && horizontalMove < 0.04f)
            {
                myAnimator.SetBool("Walk", false);
            }
            else
            {
                myAnimator.SetBool("Walk", true);
            }
            rigidBody.velocity = new Vector2(horizontalMove * speed, rigidBody.velocity.y); // x--
            Flip();
        }
    }

    public void Flip()
    {
        if (horizontalMove > 0 && !rightDirection || horizontalMove < 0 && rightDirection)
        {
            rightDirection = !rightDirection;
            mysprite.flipX = !rightDirection; // flip if facing left
        }
    }

    public void StopWalkingAnim()
    {
        myAnimator.SetBool("Walk", true);
    }
}
