﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEvent : MonoBehaviour
{
    public GameObject textPanel;
    public bool goodAlert;
    public Text textToDisplay;
    public bool hasleftTrigger;
    

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
        goodAlert = false;
        textPanel.SetActive(false);
    }


    void Update() {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            hasleftTrigger = false;
            if (!goodAlert && !CharacterManager.instance.blockaction && CharacterManager.instance.wistleInterraction && other.name == "Player")
            {
                goodAlert = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            goodAlert = false;
            hasleftTrigger = true;
        }
    }

    public void DisplayText()
    {
        textPanel.SetActive(true);
        Invoke("MasktextPanel", 2f);
    }

    public void DisplayGoodAlertText()
    {
        Invoke("DisplayText", 0.50f);
        textToDisplay.text = "Alert !! There is a bear in sector 6";
    }

    public void DisplayFalseAlertText()
    {
        Invoke("DisplayText", 1.25f);
        textToDisplay.text = "Stop playing with the whistle please !";
    }

    public void MasktextPanel()
    {
        goodAlert = false;
        textPanel.SetActive(false);
    }
}
