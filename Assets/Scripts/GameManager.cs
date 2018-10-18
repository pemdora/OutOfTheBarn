using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OutOfTheBarn
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;

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
            DontDestroyOnLoad(this.gameObject);
        }
        
        void Start()
        {}

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}