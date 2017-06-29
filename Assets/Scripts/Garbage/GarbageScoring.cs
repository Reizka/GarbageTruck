using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageScoring : MonoBehaviour
{

    private GameManager gameMng;

    [SerializeField]
    private int scoreMissed;

	// Use this for initialization
	void Start ()
    {
        gameMng = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("trigger enter "+ col.gameObject.tag);

        if (col.gameObject.tag == "MainCamera")
        {
            if (this.transform.position.x < col.transform.position.x+col.gameObject.GetComponent<CameraScroller>().xOffset)
            {
                gameMng.ManipulateScore(scoreMissed);
            }
        }

    }
}
