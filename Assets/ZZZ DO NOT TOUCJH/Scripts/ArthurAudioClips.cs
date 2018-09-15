using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArthurAudioClips : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> audioClips;

    [SerializeField]
    private AudioManager audioManager;
    [SerializeField]
    private AudioSource audioSource;

    private void Start()
    {
        audioManager = AudioManager.instance;
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
        if (scene.buildIndex != 0)
        {

            audioSource = FindObjectOfType<Chara>().GetComponent<AudioSource>();
        }
    }

    public void playSound(int clipIndex)
    {
        audioManager.Play(audioClips[clipIndex], audioSource);
        Debug.Log(audioClips[clipIndex] + " " + audioSource.name);
    }

    public void playHit(int clipIndex)
    {
        audioManager.Play(audioClips[clipIndex], audioSource);
        Debug.Log(audioClips[clipIndex] + " " + audioSource.name);
    }

    public void playFire(int gunNotSword)
    {
        if (gunNotSword == 1 && GetComponent<Animator>().GetBool("Gun Not Sword"))
        {
            audioManager.Play(audioClips[1], audioSource);
        }
        else if (!(gunNotSword == 1) && !GetComponent<Animator>().GetBool("Gun Not Sword"))
        {
            audioManager.Play(audioClips[2], audioSource);
        }
        Debug.Log("playFire");
    }
}
