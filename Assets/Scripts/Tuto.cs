using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour
{
    public GameObject textPanel;
    public Text textToDisplay;
    public Animator myAnimator1;
    public float time;

    // Use this for initialization
    void Start ()
    {
        myAnimator1.SetBool("isTalking",true);
        textPanel.SetActive(true);
        DisplayTextTuto();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayTextTuto()
    {
        Invoke("Masktext", time);
    }

    public void Masktext()
    {
        myAnimator1.SetBool("isTalking", false);
        textPanel.SetActive(false);
    }
}
