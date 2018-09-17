using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRenderer : MonoBehaviour {

    [SerializeField]
    private GameObject[] gameBullets;

    public void changeBullets(int bullets)
    {
        for (int i = gameBullets.Length - 1; i > 0; i--)
        {
            if (i < bullets)
            {
                gameBullets[i].SetActive(true);
            }
            else
            {
                gameBullets[i].SetActive(false);
            }
        }
    }
}
