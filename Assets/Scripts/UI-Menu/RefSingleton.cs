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
        audioManager = AudioManager.instance;
        gameManager = GameManager.instance;
        checkpointManager = XMLCheckpointManager.instance;
        
    }

    private void Update()
    {
        if(!gameManager)
        {
            gameManager = GameManager.instance;
        }
        if(!audioManager)
        {
            audioManager = AudioManager.instance;
        }
        if(!checkpointManager)
        {
            checkpointManager = XMLCheckpointManager.instance;
        }
    }
    
    

    public void LoadScene()
    {
        audioManager.setLastVolume();
        checkpointManager.loadGame();
    }

    public void newGame()
    {
        audioManager.setLastVolume();
        checkpointManager.newGame();
    }

    public void quitGame()
    {
        gameManager.QuitGame();
    }

    public void toMenu()
    {
        audioManager.setLastVolume();
        if (gameManager.toMenu)
        {
            gameManager.toMenu = false;
            startMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
    
}
