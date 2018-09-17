using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHelper : MonoBehaviour {

    [SerializeField]
    private GameObject[] checkpoints;

    [SerializeField]
    private AudioClip[] checkpointClip;

    [SerializeField]
    private Stack<AudioClip> clipQueue;

    [SerializeField]
    private int queuedClips;

    [SerializeField]
    private AudioSource audioSource;

    private XMLCheckpointManager check;

    // Use this for initialization
    void Start () {

        check = XMLCheckpointManager.instance;

        clipQueue = new Stack<AudioClip>();
        check.setCheckpoints(checkpoints);
        
        for (int i = 0; i < checkpointClip.Length; i++)
        {
            clipQueue.Push(checkpointClip[checkpointClip.Length - 1 - i]);
        }
        for(int i = check.dialogueNumber - 1; i > 0; i--)
        {
            clipQueue.Pop();
        }
        
	}

    private void Update()
    {

        if(queuedClips > 0)
        {
            if (!audioSource.isPlaying)
            {
                if (checkpointClip.Length > 0)
                {
                    audioSource.clip = clipQueue.Pop();
                    queuedClips--;
                    playClip();
                }
            }
        }
    }

    public void queueClip(int clips)
    {
        queuedClips += clips;
        XMLCheckpointManager.instance.dialogueNumber += 1;
    }

    public void playClip()
    {
        audioSource.Play();
    }
}
