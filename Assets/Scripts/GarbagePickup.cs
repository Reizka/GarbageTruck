using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePickup : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public bool isPoo = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("gargageTrig");
        if ((player1.tag == collision.gameObject.tag && !player1.GetComponent<AvatarPoo>().poo)|| (player2.tag == collision.gameObject.tag && player2.GetComponent<AvatarPoo>().poo)) 
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
