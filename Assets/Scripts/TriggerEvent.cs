using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEvent : MonoBehaviour
{
    public GameObject textPanel;
    public bool goodAlert;
    public Text textToDisplay;

    [HideInInspector]
    public static TriggerEvent instance = null;
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
    void Start () {
        textPanel.SetActive(false);
    }


    void Update() {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        goodAlert = true;
        if (goodAlert &&!CharacterManager.instance.blockaction && CharacterManager.instance.wistleInterraction)
        {
            if(LevelManager.instance)
            Invoke("DisplayText", 0.50f);
            textToDisplay.text = "Good Alert";
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        goodAlert = false;
    }

    public void DisplayText()
    {
        textPanel.SetActive(true);
        Invoke("MasktextPanel", 0.5f);
    }

    public void DisplayFalseAlertText()
    {
        Invoke("DisplayText", 0.75f);
        textToDisplay.text = "False Alert";
    }

    public void MasktextPanel()
    {
        goodAlert = false;
        textPanel.SetActive(false);
    }
}
