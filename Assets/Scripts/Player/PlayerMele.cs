using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMele : MonoBehaviour
{
    [SerializeField]
    private float hitForce;
    [SerializeField]
    private Transform playerTrans;

    [SerializeField]
    private AudioSource clips;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MeleeEnemy")
        {
            other.GetComponent<MeleeEnemy>().DoDamage();
            //other.GetComponent<MeleeEnemy>().getHit(true);
            other.GetComponent<Rigidbody>().AddExplosionForce(hitForce, playerTrans.position, 300,2);
            Debug.Log("MeleEnemyhit");
            clips.Play();
        }

        else if (other.tag == "RangedEnemy")
        {
            other.GetComponent<RangedEnemy>().DoDamage();
            clips.Play();
        }
    }
}
