using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftManager : MonoBehaviour
{
    public int min;
    public int max;
    public int currentLvl;

    public float offsetY;
    public bool liftActivated;
    public bool movingLiftUp;
    public bool movingLiftDown;
    public bool buttonUp;
    private Vector3 targetPosition;
    public float animationSpeed;

    
    // Use this for initialization
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            buttonUp = true;
        }
        else
        {
            buttonUp = false;
        }


        if (liftActivated && buttonUp)
        {
            CharacterManager.instance.StopWalkingAnim();
            CharacterManager.instance.player.transform.SetParent(this.transform);
            movingLiftUp = true;
            CharacterManager.instance.blockaction = true;
            targetPosition = this.transform.position + new Vector3(0f, offsetY, 0f);
        }

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // The step size is equal to speed times frame time.
        float step = animationSpeed * Time.deltaTime;

        if (movingLiftUp)
        {
            Debug.Log("On coll enter");
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, step);
        }
        if (movingLiftDown)
        {
            Debug.Log("On coll enter");
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, step);
        }


        if ((Vector2.Distance(this.transform.position, targetPosition) <= 0.1f))
        {
            this.transform.position = targetPosition;
            CharacterManager.instance.blockaction = false;
            movingLiftUp = false;
            // movingLiftDown = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            liftActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            liftActivated = false;
        }
    }
}
