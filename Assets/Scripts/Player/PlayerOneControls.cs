using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneControls : MonoBehaviour
{

    public float moveSpeed = 5.0f;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        //UP
        if (Input.GetKey("w"))
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);

        }
        //DOWN
        else if (Input.GetKey("s"))
        {

            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);

        }
        //LEFT
        else if (Input.GetKey("a"))
        {

            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);

        }
        else if (Input.GetKey("d"))
        {

            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
        
        }
        else
        {

        }


    }

}
