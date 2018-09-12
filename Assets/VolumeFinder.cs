using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeFinder : MonoBehaviour {
    public VolumeFinder volumeFinder;
    public AudioSource source;


    private void Awake()
    {
        volumeFinder = this;
        source = GetComponent<AudioSource>();
    }

    public AudioSource getSource()
    {
        return source;
    }
}
