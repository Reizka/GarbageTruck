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
        if ((player1.tag == collision.gameObject.tag)|| player2.tag == collision.gameObject.tag) 
        {
            Debug.Log("TriggeredAvatar");
            Transform garbage = this.GetComponent<Transform>();
            garbage.parent = collision.gameObject.transform;
        }
    }



}
