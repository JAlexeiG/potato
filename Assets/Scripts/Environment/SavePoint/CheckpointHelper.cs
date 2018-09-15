using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHelper : MonoBehaviour {

    [SerializeField]
    private GameObject[] checkpoints;

	// Use this for initialization
	void Start () {
        XMLCheckpointManager.instance.setCheckpoints(checkpoints);
	}
}
