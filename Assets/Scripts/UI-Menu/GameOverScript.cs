using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {
    private Chara player;

    private void Start()
    {
        player = FindObjectOfType<Chara>();
    }

    public void restarted()
    {
        FindObjectOfType<PauseMenu>().Resume();
    }
}
