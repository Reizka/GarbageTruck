using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    
    private Camera mainCam;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool rolling;


    const float xOffset = 7f;

    const float yOffset = 3f;

    const float safeOffset = 0.2f;


	// Use this for initialization
	void Start ()
    {
        mainCam = this.gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (rolling)
            mainCam.transform.Translate(Vector3.left * Time.deltaTime * speed);
    }


    public void SetRolling(bool isRolling)
    {
        rolling = isRolling;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if (col.transform.gameObject.tag == "Player")
       {
            if (col.transform.position.y < -yOffset)
            {
                col.transform.position = new Vector3(col.transform.position.x , col.transform.position.y - 0.05f, col.transform.position.z);
            }
            else if (col.transform.position.y > yOffset)
            {
                col.transform.position = new Vector3(col.transform.position.x, col.transform.position.y - 0.05f, col.transform.position.z);
            }
            else 
                col.transform.position = new Vector3(col.transform.position.x - 0.05f, col.transform.position.y, col.transform.position.z);
            
       }
    }
}
