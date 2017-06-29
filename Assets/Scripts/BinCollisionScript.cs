using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinCollisionScript : MonoBehaviour {

    //The maximum number of possible garbages that can be placed in the bin
    public int maxGarbageNumber = 4;
    public GameObject garbageType;
    public GameObject player1;
    public GameObject player2;
    public float explosionForce = 10;
    public GameObject clonesDir;
    public GameObject truckObj;

    //The garbage counter
    [SerializeField]
    private int nGarbageInside = 0;

    private Transform binTransorm;

    private Transform startingPosition;
    private float binX;
    private float binY;

    private void Awake()
    {
        binTransorm = GetComponent<Transform>();
        startingPosition = this.transform;
        binX = startingPosition.position.x;
        binY = startingPosition.position.y;
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
            Debug.Log("YUPPI, I'AM ON THE TRUCK");
            nGarbageInside = 0;
            Transform bin = this.GetComponent<Transform>();
            bin.parent = clonesDir.transform;
            Vector3 newPos = new Vector3(binX, binY, 0);
            bin.position = newPos;
//            bin.position = startingPosition.position;
            
        } else if(nGarbageInside == maxGarbageNumber && (collision.gameObject == player1 || collision.gameObject == player2))
        {
            Transform bin = this.GetComponent<Transform>();
            bin.parent = collision.gameObject.transform;

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

    
    
}
