using OutOfTheBarn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private int level;
    public enum Type { key, waterBucket };

    public GameObject pauseUI;
    [SerializeField]
    private string nextScene;

    public bool pauseState;
    public bool inFinishedCollider;
    
    public GameObject textPanel;
    public Text txtElement;
    public string finishedText;

    [HideInInspector]
    public static LevelManager instance = null;
    void Awake()
    {
        pauseState = false;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        inFinishedCollider = false;
    }


    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }*/
        if (inFinishedCollider)
        {
            switch (level)
            {
                case 1:
                    if (CharacterManager.instance.objectTocarry != null && CharacterManager.instance.objectTocarry.GetComponent<ObjectToCarry>().type == Type.waterBucket)
                    {
                        textPanel.SetActive(true);
                        txtElement.text = finishedText;
                        Invoke("LoadNextScene",2f);
                    }
                    break;
                case 2:
                    break;
            }
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
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

    public void SetInFinishedCollider(bool value)
    {
        inFinishedCollider = value;
    }
}