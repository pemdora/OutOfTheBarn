using OutOfTheBarn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public static LevelManager instance = null;
    public GameObject levelFinishedUI;
    public GameObject canvasReceipe;
    public GameObject pauseUI;

    public bool pauseState;

    void Awake()
    {
        pauseState = false;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    { }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /*
    public void LoadMenu()
    {
        pauseState = false;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        GameManager.instance.ChangeMenuState(false);
        SceneManager.LoadScene("Menu");
    }*/

    public void ReloadScene()
    {
        pauseState = false;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinishedLevel()
    {
        levelFinishedUI.SetActive(true);
        canvasReceipe.SetActive(false);
    }

    public void Pause()
    {
        if (!pauseState)
        {
            pauseState = true;
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
        else
        {
            pauseState = false;
            Time.timeScale = 1;
            pauseUI.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}