using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    [SerializeField]
    private float horizontalMove = 0f;
    private bool rightDirection;
    [SerializeField]
    private SpriteRenderer mysprite1;
    [SerializeField]
    private Animator myAnimator1;
    [SerializeField]
    private SpriteRenderer mysprite2;
    [SerializeField]
    private Animator myAnimator2;

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
                myAnimator1.SetBool("Walk", false);
                myAnimator2.SetBool("Walk", false);
            }
            else
            {
                myAnimator1.SetBool("Walk", true);
                myAnimator2.SetBool("Walk", false);
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
            mysprite1.flipX = !rightDirection; // flip if facing left
            mysprite2.flipX = !rightDirection; // flip if facing left
        }
    }

    public void StopWalkingAnim()
    {
        myAnimator1.SetBool("Walk", true);
        myAnimator2.SetBool("Walk", true);
    }
}
