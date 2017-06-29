﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinCollisionScript : MonoBehaviour {

    //The maximum number of possible garbages that can be placed in the bin
    public int maxGarbageNumber = 4;
    public GameObject garbageType;
    public float explosionForce = 10;
    public GameObject clonesDir;
    public GameObject truckObj;

    //The garbage counter
    [SerializeField]
    private int nGarbageInside = 0;

    private Transform binTransorm;

    private void Awake()
    {
        binTransorm = GetComponent<Transform>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER");
        if (collision.gameObject.tag.Contains("Garbage"))
        {
            if (collision.gameObject.tag == garbageType.tag)
            {
                Debug.Log("CORRECT!");
                //Here the bin and the bin are the same. 
                if (nGarbageInside < maxGarbageNumber)
                {
                    nGarbageInside++;
                    Destroy(collision.gameObject);
                }
                else
                {

                    Debug.Log("FULL");
                }
            }
            else
            {
                //Oh, the player has placed the garbage in the wrong bin..
                //Prepare to the explosion in 3,2,1..
                Explode(collision);

            }
        }
        else if (collision.gameObject.tag == truckObj.tag) {
            //Empty the bin with it is trigger by the truck
            nGarbageInside = 0;
        }
    }



    void Explode(Collider2D collision)
    {
        Debug.Log("EXPLOSION!");
        

        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.nearClipPlane));
        screenPosition = new Vector3(screenPosition.x * Random.Range(3,7), screenPosition.y * Random.Range(3, 7), 0);
        GameObject wrongClone = Instantiate(collision.gameObject, screenPosition, Quaternion.identity,clonesDir.transform);
        Destroy(collision.gameObject);
        //  clone.transform.position = screenPosition;

        for (int i = 0; i < nGarbageInside; i++)
        {
            screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.nearClipPlane));
            screenPosition = new Vector3(screenPosition.x * Random.Range(3, 7), screenPosition.y * Random.Range(3, 7), 0);
            GameObject clone = Instantiate(garbageType, screenPosition, Quaternion.identity, clonesDir.transform);
        }

        nGarbageInside = 0;

    }



  /*  void Explode(Collider2D collision)
    {
        //Here is implemented the bin explosion
        Debug.Log("EXPLOSION!!");

        //This is the direction of the wrong garbage
        Vector3 garbageDirection = collision.gameObject.transform.position - binTransorm.position;
        //and I apply a little strong of the item
        Rigidbody2D worngGarbage = collision.GetComponent<Rigidbody2D>();

        worngGarbage.gravityScale = 1;
        worngGarbage.AddForce(garbageDirection * explosionForce);
        worngGarbage.gravityScale = 0;
     //   Destroy(collision.gameObject);

        for (int i = 0; i < nGarbageInside; i++)
        {
            GameObject clone = Instantiate(garbageType, binTransorm);
            Vector3 direction = new Vector3(Random.Range(0, 1), garbageDirection.y, garbageDirection.z);
            clone.GetComponent<Rigidbody2D>().AddForce(direction * explosionForce);
        }

        nGarbageInside = 0;
    }
    */
    
}
