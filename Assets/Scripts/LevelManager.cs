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
    [SerializeField]
    private bool hasWistled;
    private int levelEnding;
    public Animator myAnimatorBear;
    public Animator myAnimatorSheep;
    public GameObject pnjArrestGroup;
    public Animator pnjSheep0;
    public Animator pnjSheep1;
    public Animator pnjSheep2;
    public Animator pnjSheep3;
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
        levelEnding = 0;
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
                // Step 2 : Wistle in frame or not
                if (levelStep==1)
                {
                    if (!hasWistled && TriggerEvent.instance.goodAlert)
                    {
                        hasWistled = true;
                        TriggerEvent.instance.DisplayGoodAlertText();
                    }
                    if(TriggerEvent.instance.hasleftTrigger)
                    {
                        levelStep++;
                    }
                }
                if (levelStep == 2)
                {
                    if (hasWistled)
                    {
                        levelEnding = 1;
                        pnjArrestGroup.transform.position = new Vector3(51.5f, -0.78f, 0f);
                        levelStep++;
                    }
                    else
                    {
                        pnjSheep2.SetBool("Is_Dead", true);
                        pnjSheep3.SetBool("Is_Dead", true);
                        GameObject door = GameObject.Find("door1Level2");
                        if (door.GetComponent<Door>().locked)
                        {
                            levelEnding = 2;
                            pnjArrestGroup.transform.position = new Vector3(34.5f, -0.78f, 0f);
                            levelStep++;
                        }
                        else
                        {
                            levelEnding = 3;
                            pnjArrestGroup.transform.position = new Vector3(0.7f, -0.78f, 0f);
                            pnjSheep1.SetBool("Is_Dead", true);
                            pnjSheep0.SetBool("Is_Dead", true);
                            levelStep++;
                        }
                    }
                }

                // Finished level
                if (levelStep==3 &&inFinishedCollider)
                {
                    if (CharacterManager.instance.objectTocarry != null && CharacterManager.instance.objectTocarry.GetComponent<ObjectToCarry>().type == Type.waterBucket)
                    {
                        txtElement.text = finishedText;
                        switch (levelEnding)
                        {
                            case 1:
                                txtElement.text = "You did good, we stopped that bear thanks to you";
                                break;
                            case 2:
                                txtElement.text = "There was a bear attack but it got stopped by our closed door.";
                                break;
                            case 3:
                                txtElement.text = "There was a bear attack, it was a slaughter... Someone left the door opened";
                                break;
                        }
                        textPanel.SetActive(true);
                        Invoke("LoadNextScene", 5f);
                    }
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