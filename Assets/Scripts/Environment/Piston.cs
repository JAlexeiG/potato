﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : Power {

    [SerializeField]
    GameObject piston;
    [SerializeField]
    GameObject killingObject;

    [SerializeField]
    Transform position1;
    [SerializeField]
    Transform position2;
    [SerializeField]
    Transform position3;

    Transform newPosition;

    float toPos1Speed;
    float toPos2Speed;
    float toPos3Speed;
    float newSpeed;

    int state;

	// Use this for initialization
	void Start () 
    {
        toPos1Speed = 2.5f;
        toPos2Speed = 0.75f;
        toPos3Speed = 14f;
        state = 1;

        MoveToFirstPosition();
	}

	void FixedUpdate()
	{
        if (state == 1)
        {
            newPosition = position1;
            newSpeed = toPos1Speed;
        }
            
        else if (state == 2)
        {
            newPosition = position2;
            newSpeed = toPos2Speed;
        }
        else if (state == 3)
        {
            newPosition = position3;
            newSpeed = toPos3Speed;
        }

        if (isPowered)
        {
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, newPosition.position, newSpeed * Time.fixedDeltaTime);
            if (state == 3)
                killingObject.SetActive(true);
            else
                killingObject.SetActive(false);
        }

        else
        {
            killingObject.SetActive(false);
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, position1.position, toPos1Speed * Time.deltaTime);
        }
            
	}

	void MoveToFirstPosition()
    {
        state = 1;
        Invoke("MovetoSecondPosition", 5f);
    }

    void MovetoSecondPosition()
    {
        state = 2;
        Invoke("MoveToThirdPosition", 2f);
    }

    void MoveToThirdPosition()
    {
        state = 3;
        Invoke("MoveToFirstPosition", 2f);
    }
}
