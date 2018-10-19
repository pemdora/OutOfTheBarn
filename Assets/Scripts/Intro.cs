using OutOfTheBarn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
    public string nextScene;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}