using OutOfTheBarn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    
    public int level;
    public enum Type { key, waterBucket };

    public GameObject pauseUI;
    [SerializeField]
    private string nextScene;

    public bool pauseState;
    public bool inFinishedCollider;
    
    public GameObject textPanel;
    public Text txtElement;
    public string finishedText;
    
    [Header("[Level 2 Variables]")]
    #region Level2
    private int levelStep; // 1 Get water into box collider
    private bool hasWistle;
    public Animator myAnimatorBear;
    public Animator myAnimatorSheep;
    #endregion


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
        levelStep = 0;
    }


    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }*/
        //Cheking Level envent
        switch (level)
        {
            case 1:
                if (inFinishedCollider)
                {
                    if (CharacterManager.instance.objectTocarry != null && CharacterManager.instance.objectTocarry.GetComponent<ObjectToCarry>().type == Type.waterBucket)
                    {
                        textPanel.SetActive(true);
                        txtElement.text = finishedText;
                        Invoke("LoadNextScene", 2f);
                    }
                }
                break;
            case 2:
                // Step 1 : Get water into box collider
                if (levelStep==0&&CharacterManager.instance.collisionName.Equals("Lvl1Collider1")&& CharacterManager.instance.objectTocarry!=null && CharacterManager.instance.objectTocarry.GetComponent<ObjectToCarry>().type == Type.waterBucket)
                {
                    levelStep++;
                    myAnimatorSheep.SetBool("Is_Dead", true);
                    myAnimatorBear.SetBool("IsThere", true);
                    Debug.Log("Ok");
                }
                // Step 2 : 
                if (levelStep==1)
                {
                    // hasWistle = true
                }
                break;
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