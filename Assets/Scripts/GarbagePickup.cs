using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePickup : MonoBehaviour {

    public GameObject players1;
    public GameObject players2;

    private void Awake()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("gargageTrig");
        if (players1 == collision.gameObject || players2 == collision.gameObject) 
        {
            Debug.Log("TriggeredAvatar");
            Transform garbage = this.GetComponent<Transform>();
            garbage.parent = collision.gameObject.transform;
        }
    }

}
