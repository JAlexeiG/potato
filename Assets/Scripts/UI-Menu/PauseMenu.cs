using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsPanel;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Escape is pressed.");
            if (GameIsPaused)
            {
                
                //audioManager.Play("Click");     pause sound
            }
            else
            {
                Pause();
                //audioManager.Play("Click");     pause sound
            }

        }
	}
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void Pause2()
    {
        FindObjectOfType<Chara>().pause(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Pause()
    {
        FindObjectOfType<Chara>().pause(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Unpause()
    {
        Debug.Log("unpausing");
        Resume();
    }
    public void Restart()
    {
        Resume();
        XMLCheckpointManager.instance.load();
        //SceneManager.LoadSceneAsync(1);

        
    }


    public void Menu()
    {
        Resume();
        AudioManager.instance.setLastVolume();
        SceneManager.LoadSceneAsync(0);
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
    }
    public void Back()
    {
        settingsPanel.SetActive(false);
    }
}
