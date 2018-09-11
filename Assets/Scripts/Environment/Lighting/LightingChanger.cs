using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingChanger : MonoBehaviour {

    [SerializeField]
    private bool lightSwitch;

    [SerializeField]
    private Animator anim;


    // Update is called once per frame
    void Update()
    {
        if (lightSwitch)
        {
            anim.SetTrigger("lightOn");
            Destroy(gameObject);
            lightSwitch = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            anim.SetTrigger("lightOn");
        }
    }
}
