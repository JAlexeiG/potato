using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu : MonoBehaviour {

    public GameObject titlescreen;
    public GameObject mainmenuUI;
    public GameObject instructions;
    public GameObject settings;
   
    public void turneverythingoff()
    {
        titlescreen.SetActive(true);
        mainmenuUI.SetActive(false);
        instructions.SetActive(false);
        settings.SetActive(false);
    }
}
