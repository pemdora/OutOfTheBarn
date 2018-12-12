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
    public bool buttonDown;
    private Vector3 targetPosition;
    public float animationSpeed;
  

    // Use this for initialization
    void Update ()
    {
        if (!buttonDown && Input.GetKeyDown(KeyCode.UpArrow) && !movingLiftUp && !movingLiftDown)
        {
            buttonUp = true;
        }
        else
        {
            buttonUp = false;
        }

        if (!buttonUp && Input.GetKeyDown(KeyCode.DownArrow) && !movingLiftUp && !movingLiftDown)
        {
            buttonDown = true;
        }
        else
        {
            buttonDown = false;
        }

        if (liftActivated && buttonUp && currentLvl< max)
        {
            Debug.Log("lift up");
            currentLvl++;
            CharacterManager.instance.StopWalkingAnim();
            CharacterManager.instance.blockaction = true;
            CharacterManager.instance.player.transform.SetParent(this.transform);
            movingLiftUp = true;
            targetPosition = this.transform.position + new Vector3(0f, offsetY, 0f);
        }
        else if (liftActivated && buttonDown && currentLvl > min)
        {
            Debug.Log("lift down");
            currentLvl--;
            CharacterManager.instance.StopWalkingAnim();
            CharacterManager.instance.blockaction = true;
            CharacterManager.instance.player.transform.SetParent(this.transform);
            movingLiftDown = true;
            targetPosition = this.transform.position - new Vector3(0f, offsetY, 0f);
        }

        // The step size is equal to speed times frame time.
        float step = animationSpeed * Time.deltaTime;

        if (movingLiftUp && !movingLiftDown)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, step);
            Debug.Log("this.transform.position "+ this.transform.position);
            Debug.Log("targetPosition "+ targetPosition);
        }
        if (movingLiftDown && !movingLiftUp)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, step);
        }

        // STOP LIFT
        if ((movingLiftUp || movingLiftDown)&& (Vector2.Distance(this.transform.position, targetPosition) <= 0.1f))
        {
            Debug.Log("stop lift");
            this.transform.position = targetPosition;
            // CharacterManager.instance.player.transform.parent = null;
            CharacterManager.instance.blockaction = false;
            movingLiftUp = false;
            movingLiftDown = false;
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
