using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour
{
    public GameObject textPanel;
    public Text textToDisplay;
    public Animator myAnimator1;
    public float timeLeft;

    public bool trigger;
    public bool finishedTuto;

    // Use this for initialization
    void Start ()
    {
    }

    private void FixedUpdate()
    {
        if (!trigger&& Input.anyKeyDown)
        {
            myAnimator1.SetBool("isTalking", true);
            textPanel.SetActive(true);
            trigger = true;
        }
        if (trigger && !finishedTuto && timeLeft < 0)
        {
            Masktext(); finishedTuto = true;
            return;
        }
        else if(trigger)
        {
            timeLeft -= Time.deltaTime;
        }


    }
    

    public void Masktext()
    {
        myAnimator1.SetBool("isTalking", false);
        textPanel.SetActive(false);
    }
}
