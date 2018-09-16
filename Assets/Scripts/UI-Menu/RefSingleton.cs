using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Returns reference to singletons
public class RefSingleton : MonoBehaviour {

    public AudioManager audioManager;
    public XMLCheckpointManager checkpointManager;

    public GameObject titlescreen;
    public GameObject mainmenuUI;
    public GameObject instructions;
    public GameObject settings;

    private Scene currentScene;
    private bool hasloaded;

    private void Start()
    {
        audioManager = AudioManager.instance;
        checkpointManager = XMLCheckpointManager.instance;
        hasloaded = false;
    }

    private void Update()
    {
        if(!audioManager)
        {
            audioManager = AudioManager.instance;
        }
        if(!checkpointManager)
        {
            checkpointManager = XMLCheckpointManager.instance;
        }
        if(currentScene.buildIndex == 0 && GameManager.instance && !hasloaded)
        {
            if (GameManager.instance.menu)
            {
                titlescreen.SetActive(false);
                mainmenuUI.SetActive(true);
                instructions.SetActive(false);
                settings.SetActive(false);
                
            }
            else if(!GameManager.instance.menu)
            {
                titlescreen.SetActive(true);
                mainmenuUI.SetActive(false);
                instructions.SetActive(false);
                settings.SetActive(false);
                GameManager.instance.menu = true;
            }
            hasloaded = true;
        }
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene;
    }


    public void LoadScene()
    {
        audioManager.setLastVolume();
        checkpointManager.loadGame();
    }

    public void newGame()
    {
        audioManager.setLastVolume();
        SceneManager.LoadScene(2);
    }


    public void start()
    {
        checkpointManager.newGame();
    }

    public void quitGame()
    {
        GameManager.instance.QuitGame();
    }

    public void toMenu()
    {
        audioManager.setLastVolume();
    }
    
    public void playClick()
    {
        audioManager.GetComponent<AudioSource>().Play();
    }
}
