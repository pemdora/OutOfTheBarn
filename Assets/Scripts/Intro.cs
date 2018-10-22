using OutOfTheBarn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public float timeLeft;
    public string nextScene;
    public Text timerTxt;

    private void FixedUpdate()
    {
        if (timeLeft < 0)
        {
            timerTxt.text = "Press Any button";
            if (Input.anyKeyDown)
                SceneManager.LoadScene(nextScene);
        }
        else
        {
            timeLeft -= Time.deltaTime;
            timerTxt.text = Mathf.Round(timeLeft).ToString();
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}