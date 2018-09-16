using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

    XMLCheckpointManager manager;

    
    [SerializeField]
    Checkpoints nextCheckpoint;

    private bool hasNextPoint;


    [SerializeField]
    public int queueClips;

    public CheckpointHelper helper;

    // Use this for initialization
    void Start () {
        manager = XMLCheckpointManager.instance;
        if (nextCheckpoint)
        {
            hasNextPoint = true;
        }
	}

    private void Update()
    {
        if(!nextCheckpoint && hasNextPoint)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            helper.queueClip(queueClips);
            XMLCheckpointManager.instance.setCheckpoint(gameObject);
            manager.save();
            if (HealthManager.instance.health + 20 < HealthManager.instance.maxHealth)
            {
                HealthManager.instance.health += 20;
            }
            else
            {
                HealthManager.instance.health = HealthManager.instance.maxHealth;
            }
            AudioManager.instance.setLastVolume();
            Destroy(gameObject);
        }
    }
}
