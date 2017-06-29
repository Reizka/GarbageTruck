using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageScoring : MonoBehaviour
{

    private GameManager gameMng;

    [SerializeField]
    private int scoreMissed;

    [SerializeField]
    private float missedLine = 6.3f;


	// Use this for initialization
	void Start ()
    {
        gameMng = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("trigger enter "+ col.gameObject.tag);

        if (col.gameObject.tag == "MainCamera")
        {
            
            //if (this.transform.position.x < (col.transform.position.x-col.gameObject.GetComponent<CameraScroller>().xOffset)+(1.5*this.GetComponent<BoxCollider2D>().size.x))
            Vector3 distance = this.transform.position - col.gameObject.transform.position;
            Debug.Log("distance is " + distance);
            if (distance.x >= 6.3f )
            {
                gameMng.ManipulateScore(scoreMissed);
                Destroy(this.gameObject);
            }
            else if (distance.x < -4.2f)
            {
                this.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }

    }
}
