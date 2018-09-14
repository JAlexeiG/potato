using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAnimation : MonoBehaviour {
    
    public void fire()
    {
        GetComponent<RangedEnemy>().Attack();
    }
}
