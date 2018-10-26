using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInterractionOutside : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;
    [SerializeField] private BoxCollider2D doorCollider;
    private BoxCollider2D doorColliderInteraction;
    public int id;
    public bool doorInterraction;
    public bool locked;
    private bool blockaction;
    private bool isInDoorColliderInteraction;

    // Use this for initialization
    void Start()
    {
        doorColliderInteraction = GetComponent<BoxCollider2D>();
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            doorInterraction = true;
        }
        else
        {
            doorInterraction = false;
        }

        if (!blockaction && isInDoorColliderInteraction)
        {
            if (doorInterraction && locked)
            {
                //Debug.Log("Unlocked");
                blockaction = true;
                locked = false;
                myAnimator.SetBool("DoorOpen", true);
                doorCollider.isTrigger = true;
                Invoke("Blockaction", 0.25f); ;
            }
            else if (locked && isInDoorColliderInteraction)
            {
                //Debug.Log("Locked");
            }
            else
            if (isInDoorColliderInteraction && doorInterraction && !locked)
            {
                doorCollider.isTrigger = false;
                //Debug.Log("ReLocked");
                blockaction = true;
                locked = true;
                myAnimator.SetBool("DoorOpen", false);
                Invoke("Blockaction", 0.25f); ;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        isInDoorColliderInteraction = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInDoorColliderInteraction = false;
    }

    private void Blockaction()
    {
        blockaction = false;
    }

}
