using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePickup : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    public bool isPoo = false;

    private void Start()
    {
        player1 = GameObject.FindWithTag("player1");
        player2 = GameObject.FindWithTag("player2");
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("gargageTrig");
        if ((player1.tag == collision.gameObject.tag && !player1.GetComponent<AvatarPoo>().poo)|| (player2.tag == collision.gameObject.tag && !player2.GetComponent<AvatarPoo>().poo)) 
        {
            Debug.Log("TriggeredAvatar");
            Transform garbage = this.GetComponent<Transform>();
            garbage.parent = collision.gameObject.transform;

            if (isPoo)
            {
                collision.gameObject.GetComponent<AvatarPoo>().SetPoo(true);
            }
        }
    }



}
