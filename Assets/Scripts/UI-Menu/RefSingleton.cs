using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Returns reference to singletons
public class RefSingleton : MonoBehaviour {

    public AudioManager audioManager;
    public GameManager gameManager;
    public XMLCheckpointManager checkpointManager;

    public GameObject startMenu;
    public GameObject mainMenu;

    private void Start()
    {
        audioManager = GetAudioManager();
        gameManager = GetGameManager();
        checkpointManager = GetCheckpointManager();

        if(gameManager.toMenu)
        {
            gameManager.toMenu = false;
            startMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    private void Update()
    {
        if(!gameManager)
        {
            gameManager = GetGameManager();
        }
        if(!audioManager)
        {
            audioManager = GetAudioManager();
        }
        if(!checkpointManager)
        {
            checkpointManager = GetCheckpointManager();
        }
    }
    public AudioManager GetAudioManager()
    {
        //return AudioManager.instance;
        Debug.LogError("Not Setup: Once audio manager is singleton, change this function");
        return null;
    }

    public GameManager GetGameManager()
    {
        return GameManager.instance;
    }

    public XMLCheckpointManager GetCheckpointManager()
    {
        return XMLCheckpointManager.instance;
    }

    public void LoadScene()
    {
        checkpointManager.loadGame();
    }

    public void newGame()
    {
        checkpointManager.newGame();
    }

    public void quitGame()
    {
        gameManager.QuitGame();
    }

    public void toMenu()
    {

    }
}
