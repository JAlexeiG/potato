using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainController : MonoBehaviour {

    private void Start()
    {
        if(GameManager.instance.toMenu)
        {
            GameManager.instance.toMenu = false;
            gameObject.SetActive(false);
        }
    }
}
